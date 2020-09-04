using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blogNenakhov.Models;

namespace blogNenakhov.Controllers
{
    /// <summary>  
    /// Контроллер для работы с главной страницей и политикой конфедициальности
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Поле класса - логгер
        /// </summary>
        /// <param name="ILogger">Логгер</param>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Констурктор класса <see cref="HomeController"/>
        /// </summary>
        /// <param name="logger">Логгер ……</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        // <summary>
        // GET: Возвращает страницу Главная
        // </summary>
        public IActionResult Index()
        {
            return View();
        }
        
        // <summary>
        // GET: Возвращает страницу политики конфединциальности
        // </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        // <summary>
        // GET: Возвращает страницу ошибки 
        // </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
