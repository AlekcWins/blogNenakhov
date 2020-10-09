using blogNenakhov.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace blogNenakhov.Domain.DB
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Employee Employee { get; set; }
    }
}