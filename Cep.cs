using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public struct Cep
    {
        private static string _value;
        public static string _onlyDigitsCep;
        public readonly bool IsValid;

        private Cep(string value)
        {
            _onlyDigitsCep = string.Empty;

            if (value == null)
            {
                IsValid = false;
                return;
            }

            foreach (var c in value)
            {
                if (char.IsDigit(c))
                {
                    _onlyDigitsCep += c;
                }
            }

            if (_onlyDigitsCep.Length != 8)
            {
                IsValid = false;
                return;
            }

            _value = Convert.ToInt32(_onlyDigitsCep).ToString(@"00000\-000");


            IsValid = Regex.IsMatch(_value, @"^\d{5}-\d{3}");

            if (!IsValid)
            {
                return;
            }
        }

        public static implicit operator Cep(string value)
            => new Cep(value);

        public string OnlyDigitsCep => _onlyDigitsCep;

        public string FormatedCep => _value;
    }
}
