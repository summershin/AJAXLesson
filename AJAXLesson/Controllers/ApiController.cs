using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXLesson.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name,int age=0)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }
            //return Content("Hello World!!");
            //return Content("<h2>Hello World!!</h2>");   
            //return Content("<h2>Hello World!!</h2>","text/html");  讓瀏覽器能編譯html標籤
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html");   
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html",System.Text.Encoding.UTF8);   //讓瀏覽器能編譯中文
            return Content($"{name}你好,你的年齡是{age}!!", "text/html", System.Text.Encoding.UTF8);
        }
    }
}
