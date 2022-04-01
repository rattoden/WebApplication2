using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Task1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task1(string firstnum, string secondnum, string thirdnum)
        {
            ViewBag.H = "";
            double a, b, c;
            bool isNum1 = double.TryParse(firstnum, out a);
            bool isNum2 = double.TryParse(secondnum, out b);
            bool isNum3 = double.TryParse(thirdnum, out c);
            if (isNum1 && isNum2 && isNum3)
            {
                if (firstnum != null && secondnum != null && thirdnum != null)
                {
                    a = Convert.ToDouble(firstnum);
                    b = Convert.ToDouble(secondnum);
                    c = Convert.ToDouble(thirdnum);
                    if (a > -3 && a <= 9 && b > -3 && b <= 9 && c > -3 && c <= 9)
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + a + "; " + b + "; " + c;
                    }
                    else if ((a <= -3 || a > 9) && b > -3 && b <= 9 && c > -3 && c <= 9)
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + b + "; " + c;
                    }
                    else if (a > -3 && a <= 9 && (b <= -3 || b > 9) && c > -3 && c <= 9)
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + a + "; " + c;
                    }
                    else if (a > -3 && a <= 9 && b > -3 && b <= 9 && (c <= -3 || c > 9))
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + a + "; " + b;
                    }
                    else if (a > -3 && a <= 9 && (b <= -3 || b > 9) && (c <= -3 || c > 9))
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + a;
                    }
                    else if ((a <= -3 || a > 9) && b > -3 && b <= 9 && (c <= -3 || c > 9))
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + b;
                    }
                    else if ((a <= -3 || a > 9) && (b <= -3 || b > 9) && c > -3 && c <= 9)
                    {
                        ViewBag.H = "Принадлежат отрезку (-3,9]: " + c;
                    }
                    else if ((a <= -3 || a > 9) && (b <= -3 || b > 9) && (c <= -3 || c > 9))
                    {
                        ViewBag.H = "Ни одно из чисел не принадлежит отрезку (-3,9]";
                    }
                }
                else
                {
                    ViewBag.H = "Ошибка. Введите 3 числа";
                }
            }
            else
            {
                ViewBag.H = "Ошибка. Введите 3 числа";
            }
            return View();
        }

        public IActionResult Task2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task2(string predl)
        {
            ViewBag.A = "";
            ViewBag.B = "";
            char ya = 'я';
            char[] mass = predl.ToCharArray();
            int a = Array.IndexOf(mass, 'я') + 1;
            int b = Array.LastIndexOf(mass, 'я') + 1;
            if (mass.Contains(ya))
            {
                if (a == b)
                {
                    ViewBag.A = "В предложении одна буква 'я' - на " + a + " месте";
                    ViewBag.B = "";
                }
                else
                {
                    ViewBag.A = "Порядковый номер первой 'я':" + a;
                    ViewBag.B = "Порядковый номер последней 'я':" + b;
                }
            }
            else
            {
                ViewBag.A = "В предложении нет бука 'я'";
                ViewBag.B = "";
            }
            return View();
        }

        public IActionResult Task3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task3(string massiv)
        {
            ViewBag.A = "";
            string[] mass = massiv.Split(' ');
            int[] num = Array.ConvertAll(mass, int.Parse);
            int sum = 0;
            for(int i = 0; i < num.Length; i++)
            {
                if(i % 2 == 0)
                {
                    if(num[i] > 0)
                    {
                        sum += num[i];
                    }
                }
            }
            ViewBag.A = "Результат: " + sum;
            return View();
        }
    }
}
