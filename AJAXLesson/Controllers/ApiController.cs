using AJAXLesson.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXLesson.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        public ApiController( DemoContext context)
        {
            _context = context;
        }

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
        public IActionResult checkUsername(string name)
        {
            //Debug.WriteLine(1);
            string Name = name;
            
            var q = _context.Members.FirstOrDefault(n => n.Name == name);
            if (q == null)
            {
                return Content(Name + "可使用此暱稱");
            }
            return Content(Name + "暱稱已被使用");
        }
    }
}
