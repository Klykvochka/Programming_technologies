using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ1_классы.Class
{

        class Human
        {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Human()
        {
            
            Height = 0;
            Weight = 0;
            Birthday = DateTime.Now;
            FirstName = "Name";
            LastName = "No";
        }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="Height_">Рост человека.</param>
        /// <param name="Weight_">Вес человека.</param>
        /// <param name="Birthday_">Дата рождения человека.</param>
        /// <param name="FirstName_">Имя человека.</param>
        /// <param name="LastName_">Фамилия человека.</param>
        public Human(int Height_, int Weight_, DateTime Birthday_, string FirstName_, string LastName_)
            {
            bool flag = IntValidator.Validate(Height_);
            if (!flag) 
                throw new ArgumentOutOfRangeException(nameof(flag), "Вы указали с ошибкой параметр Heght"); 
            Height = Height_; 
            
            flag = IntValidator.Validate(Weight_); 
            if (!flag) 
                throw new ArgumentOutOfRangeException(nameof(flag), "Вы указали с ошибкой параметр Weght"); 
            Weight = Weight_; 
            
            if (Birthday_ > DateTime.Now) 
                throw new ArgumentOutOfRangeException(nameof(flag), "Вы указали с ошибкой параметр Birthday"); 
            Birthday = Birthday_; 
            
            flag = StringValidator.Validate(FirstName_); 
            if (flag) 
                throw new ArgumentException("Вы указали с ошибкой параметр FirstName", nameof(flag)); 
            FirstName = FirstName_; 
            
            flag = StringValidator.Validate(LastName_); 
            if (flag) 
                throw new ArgumentException("Вы указали с ошибкой параметр LastName", nameof(flag) ); 
            LastName = LastName_;

        }
        // если нужно изменить объеты в классе нужна static
        // { get; private set; } - автоматическое свойство
        // get - можно получить | private set - изменить
        
        /// <summary>
        /// Рост человека.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Вес человека.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Дата рождения человека.
        /// </summary>
        public DateTime Birthday { get; }

        /// <summary>
        /// Имя человека.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия человека.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Полное имя человека.
        /// </summary>
        public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            }
        /// <summary>
        /// Изменяет рост человека, если указанное значение проходит валидацию.
        /// </summary>
        /// <param name="Height">Новый рост человека.</param>
        
        public bool ChangeHeight(int Height)
        {
            bool flag = IntValidator.Validate(Height);
            if (flag)
            {
                this.Height = Height;
            }
            else { Console.WriteLine("Указан некорректный рост."); }
            return flag;

        }

        /// <summary>
        /// Изменяет вес человека, если указанное значение проходит валидацию.
        /// </summary>
        /// <param name="weight">Новый вес человека.</param>
      
        public bool ChangeWeight(int weight)
        {
            bool flag = IntValidator.Validate(weight);
            if (flag)
            {
                this.Weight = weight;
            }
            else { Console.WriteLine("Указан некорректный вес."); }
            return flag;
        }

        /// <summary>
        /// Изменяет имя человека, если указанное значение проходит валидацию.
        /// </summary>
        /// <param name="FirstName">Новое имя человека.</param>
     
        public bool ChangeFirstName(string FirstName)
        {
            bool flag = StringValidator.Validate(FirstName);
            if (flag)
            {
                this.FirstName = FirstName;
            }
            else { Console.WriteLine("Указано некорректное имя."); }
            return flag;
        }

        /// <summary>
        /// Изменяет фамилию человека, если указанное значение проходит валидацию.
        /// </summary>
        /// <param name="LastName">Новая фамилия человека.</param>
      
        public bool ChangeLastName(string LastName)
        {
            bool flag = StringValidator.Validate(LastName);
            if (flag)
            {
                this.LastName = LastName;
            }
            else { Console.WriteLine("Указана некорректная фамилия."); }
            return flag;
        }

    }
}

