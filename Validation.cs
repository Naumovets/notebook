using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Validation
    {
        public bool Required { set; get; }
        public int MinLength { set; get; }
        public int MaxLength { set; get; }
        public char[] ValidSymbols { set; get; }

        public Validation(bool required, int min, int max, char[] symbpols)
        {
            Required = required;
            MinLength = min;
            MaxLength = max;
            ValidSymbols = symbpols;
        }

        public bool TryValidate(string input, out string output)
        {
            output = null;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                if (Required)
                {
                    output = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    output = null;
                    return true;
                }
            }
            if (input.Length < MinLength)
            {
                output = $"Минимальная длина: {MinLength}!";
                return false;
            }

            if (input.Length > MaxLength)
            {
                output = $"Максимальная длина: {MaxLength}!";
                return false;
            }

            foreach (var item in input)
            {

                if (!ValidSymbols.Contains(item))
                {
                    output = $"Используйте только: {new string(ValidSymbols)}!";
                    return false;
                }
            }


            return true;
        }
    }
}
