

namespace ДЗ1_классы.Class
{
    /// <summary>
    ///  Валидация целочисленных значений.
    /// </summary>
    class IntValidator
    {
        /// <summary>
        /// Проверяет, является ли заданное целочисленное значение положительным.
        /// </summary>
        /// <param name="Value">Целочисленное значение для проверки.</param>
      
        static public bool Validate(int Value)
        {
            return (Value > 0);
        }
    }
}
