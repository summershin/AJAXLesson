using AJAXLesson.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXLesson.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(User user)
        {
            //System.Threading.Thread.Sleep(5000);
            if (String.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            //return Content("Hello World!!");
            //return Content("<h2>Hello World!!</h2>");   
            //return Content("<h2>Hello World!!</h2>","text/html");  讓瀏覽器能編譯html標籤
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html");   
            //return Content("<h2>Hello World!! 你好!</h2>", "text/html",System.Text.Encoding.UTF8);   //讓瀏覽器能編譯中文
            return Content($"{user.name}你好,你的年齡是{user.age}!!", "text/html", System.Text.Encoding.UTF8);
        }
    }
}
