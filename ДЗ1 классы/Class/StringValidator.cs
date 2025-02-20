using System;
using System.Text.RegularExpressions;


namespace ДЗ1_классы.Class
{
    /// <summary>
    /// Валидатор строковых значений.
    /// </summary>
    class StringValidator
    {
        /// <summary>
        /// Проверяет, является ли строка допустимой. 
        /// </summary>
        /// <param name="Value">Строка для проверки.</param>
        static public bool Validate(string Value)
        {
          
            if (string.IsNullOrWhiteSpace(Value))
            {
                return false; 
            }

            // Используем регулярное выражение для проверки, что строка содержит только символы a-z, A-Z.
            if (Regex.IsMatch(Value, @"^[a-zA-Z]+$"))
            {
                return false; 
            }

            return true;
        }
    }
}
