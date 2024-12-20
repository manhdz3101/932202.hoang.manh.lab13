using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using System.Diagnostics;

namespace Lab3.Controllers
{
    public class QuizController : Controller
    {
        static Result result = new Result();
        static Random rand = new Random();
        string[] ListOperations = { "+", "-", "*", "/" };
        public string curOper;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            if (ModelState.IsValid)
            {
                ViewBag.numb1 = rand.Next(10);
                ViewBag.numb2 = rand.Next(10);
                ViewBag.sign = ListOperations[rand.Next(0, 3)];
                return View();
            }

            return View();
        }

        public IActionResult QuizResult()
        {
            if (ModelState.IsValid)
            {
                ViewBag.ListResult = result.ListResult;
                ViewBag.RightAnswersCount = result.RightAnswersCount;
                ViewBag.AnswersCount = result.AnswersCount;
                return View();
            }

            return View();
        }

        public void QuizLogic(string value1, string value2, string answer, string sign)
        {
            int _value1 = Convert.ToInt32(value1);
            int _value2 = Convert.ToInt32(value2);
            int _answer = Convert.ToInt32(answer);
            curOper = sign;


            switch (curOper)
            {
                case "+":
                    if (_value1 + _value2 == _answer)
                        result.RightAnswersCount++;
                    result.ListResult.Add("" + value1 + " + " + value2 + " = " + answer);
                    result.AnswersCount++;
                    break;
                case "-":
                    if (_value1 - _value2 == _answer)
                        result.RightAnswersCount++;
                    result.ListResult.Add("" + value1 + " - " + value2 + " = " + answer);
                    result.AnswersCount++;
                    break;
                case "*":
                    if (_value1 * _value2 == _answer)
                        result.RightAnswersCount++;
                    result.ListResult.Add("" + value1 + " * " + value2 + " = " + answer);
                    result.AnswersCount++;
                    break;
                case "/":
                    if (_value2 != 0)
                    {
                        if (_value1 / _value2 == _answer)
                            result.RightAnswersCount++;
                        result.ListResult.Add("" + value1 + " / " + value2 + " = " + answer);
                        result.AnswersCount++;
                    }
                    break;
            }

            ViewBag.numb1 = rand.Next(10);
            ViewBag.numb2 = rand.Next(10);
            ViewBag.sign = ListOperations[rand.Next(0, 3)];
        }

        [HttpPost]
        public IActionResult Next(string value1, string value2, string answer, string sign)
        {
            QuizLogic(value1, value2, answer, sign);
            return View("quiz");
        }

        [HttpPost]
        public IActionResult Finish(string value1, string value2, string answer, string sign)
        {
            QuizLogic(value1, value2, answer, sign);
            ViewBag.ListResult = result.ListResult;
            ViewBag.RightAnswersCount = result.RightAnswersCount;
            ViewBag.AnswersCount = result.AnswersCount;
            return View("quizResult");
        }
    }
}