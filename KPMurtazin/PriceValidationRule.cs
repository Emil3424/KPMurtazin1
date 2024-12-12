using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KPMurtazin
{
    public class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Price is required.");

            if (double.TryParse(value.ToString(), out double price))
            {
                if (price >= 0) //Check if price is non-negative
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Price must be non-negative.");
            }
            else
            {
                return new ValidationResult(false, "Invalid price format.");
            }
        }
    }
}
