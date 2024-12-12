using KPMurtazin.DataBase;
using KPMurtazin.Message;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddSotrudniki.xaml
    /// </summary>
    public partial class AddSotrudniki : Page
    {
        private readonly Sotrudniki current = null;

        public AddSotrudniki(Sotrudniki sotrudniki)
        {
            InitializeComponent();

            System.Collections.Generic.List<Sotrudniki> res = new DB_Operation().ExecuteQuery<Sotrudniki>(
                @"SELECT *
                FROM Sotrudniki;");

            if (sotrudniki != null)
            {
                current = res
                    .Where(w => w.ID_Sotr == sotrudniki.ID_Sotr)
                    .ToList().LastOrDefault();
            }

            DataContext = current;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (current != null)
                {
                    string sql = "UPDATE Sotrudniki SET FIO = @FIO, Gender = @Gender, " +
                        "Date_B = @Date_B, Adress = @Adres, Job = @Job, Schedule = @Schedule," +
                        "Salary = @Salary, Education = @Education, Telephon = @Telephon " +
                        "WHERE ID_Sotr = @ID_Sotr";
                    SQLiteParameter[] parameters = {
                            new SQLiteParameter("@ID_Sotr",current.ID_Sotr),
                            new SQLiteParameter("@FIO",FIOT.Text),
                            new SQLiteParameter("@Gender",GenderT.Text),
                            new SQLiteParameter("@Date_B","09.12.2024"),
                            new SQLiteParameter("@Adres",AdresT.Text),
                            new SQLiteParameter("@Job",JobT.Text),
                            new SQLiteParameter("@Schedule", "5/2"),
                            new SQLiteParameter("@Salary",SalaryT.Text),
                            new SQLiteParameter("@Education",EducationT.Text),
                            new SQLiteParameter("@Telephon",TelephonT.Text)
                        };
                    new DB_Operation().Query(sql, parameters);
                    var messageWindow = new MessageWindow("Данные успешно изменены." + Environment.NewLine + "Сохранено!");
                    messageWindow.ShowDialog();
                    messageWindow.Close();
                }
                else if (current == null)
                {
                    string sql = "INSERT INTO Sotrudniki(FIO,Gender,Date_B,Adress,Job,Schedule,Salary,Education,Telephon) " +
                        "values(@FIO,@Gender,@Date_B,@Adres,@Job,@Schedule,@Salary,@Education,@Telephon)";
                    SQLiteParameter[] parameters = {
                            new SQLiteParameter("@FIO",FIOT.Text),
                            new SQLiteParameter("@Gender",GenderT.Text),
                            new SQLiteParameter("@Date_B","09.12.2024"),
                            new SQLiteParameter("@Adres",AdresT.Text),
                            new SQLiteParameter("@Job",JobT.Text),
                            new SQLiteParameter("@Schedule", "5/2"),
                            new SQLiteParameter("@Salary",SalaryT.Text),
                            new SQLiteParameter("@Education",EducationT.Text),
                            new SQLiteParameter("@Telephon",TelephonT.Text)
                        };

                    new DB_Operation().Query(sql, parameters);

                    var messageWindow = new MessageWindow("Данные успешно добавлены." + Environment.NewLine + "Сохранено!");
                    messageWindow.ShowDialog();
                    messageWindow.Close();
                };
            }
            catch (Exception ex)
            {
                var messageWindow = new FailMessageWindow("Ошибка: " + ex.Message + Environment.NewLine + "Ошибка!");
                messageWindow.ShowDialog();
            }
        }
    }
}