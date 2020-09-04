using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blogNenakhov.Controllers
    { 
    /// <summary>  
    /// Контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        // <summary>
        // GET: Возвращает страницу блога
        // </summary>
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
