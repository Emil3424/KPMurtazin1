using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;

namespace KPMurtazin.DataBase
{
    public class DB_Operation
    {
        private static readonly string connectionString
            = @"Data Source=ИС121 КП Муртазин котокафе.db;Version=3;";

        public DB_Operation() { }

        public List<T>ExecuteQuery<T>(string query, SQLiteParameter[] parameters = null) where T : new()
        {
            var result = new List<T>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T obj = new T();

                            // Заполняем основные свойства объекта
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.GetValue(i);

                                // Получаем свойство объекта, которое соответствует имени столбца 
                                PropertyInfo property = typeof(T).GetProperty(columnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                                if (property != null && value != DBNull.Value)
                                {
                                    property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                                }
                            }

                            // Обрабатываем связанные объекты динамически
                            foreach (PropertyInfo property in typeof(T).GetProperties())
                            {
                                // Проверяем, что это не строка и что это класс (то есть другой объект)
                                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                                {
                                    object relatedEntity = Activator.CreateInstance(property.PropertyType);
                                    bool hasRelatedData = false;

                                    // Для каждого свойства связанного объекта
                                    foreach (PropertyInfo relatedProperty in property.PropertyType.GetProperties())
                                    {
                                        // Проверяем, есть ли колонка, которая соответствует этому свойству
                                        string relatedColumnName = $"{property.Name}_{relatedProperty.Name}"; // Динамическое создание имени колонки

                                        // Если колонка с именем существует в результате запроса и имеет данные
                                        int relatedOrdinal;
                                        try
                                        {
                                            relatedOrdinal = reader.GetOrdinal(relatedColumnName);
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            continue; // Если столбец не найден, продолжаем к следующему свойству
                                        }

                                        if (relatedOrdinal >= 0 && reader[relatedColumnName] != DBNull.Value)
                                        {
                                            relatedProperty.SetValue(relatedEntity, Convert.ChangeType(reader[relatedColumnName], relatedProperty.PropertyType));
                                            hasRelatedData = true;
                                        }
                                    }

                                    // Если данные для связанного объекта были найдены, устанавливаем его в основной объект
                                    if (hasRelatedData)
                                    {
                                        property.SetValue(obj, relatedEntity);
                                    }
                                }
                            }

                            result.Add(obj);
                        }
                    }
                }
            }

            return result;
        }
    }
}
