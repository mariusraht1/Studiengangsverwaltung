using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Universitätsverwaltung.controller
{
    public class Validation
    {
        private static Validation instance;

        public static Validation Instance
        {
            get { return instance ?? (instance = new Validation()); }
        }


    }

    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime result = new DateTime();
            return DateTime.TryParse(value.ToString(), out result);
        }
    }

    public class IntegerAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int result = -1;
            return int.TryParse(value.ToString(), out result);
        }
    }
}
