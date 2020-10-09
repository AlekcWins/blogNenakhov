using blogNenakhov.Domain.Model.Common;

namespace blogNenakhov.Domain.Model
{ 
/// <summary>
/// Пользоватлеь
/// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        ///  Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///  Адресс проживания пользователя
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        ///  Возвращает полное имя пользователя
        /// </summary>
        public string FullName
        {
            get => FirstName + " " + Surname;
        }
    }
}