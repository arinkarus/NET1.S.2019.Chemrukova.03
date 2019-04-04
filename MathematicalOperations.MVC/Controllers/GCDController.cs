using MathematicalOperations.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathematicalOperations.MVC.Controllers
{
    public class GCDController : Controller
    {
        public ActionResult Algorithm(int[] numbers, string algorithmType)
        {
            var gcdAlgorithm = new GcdAlgorithm();
            gcdAlgorithm.Name = algorithmType;
            if (algorithmType == "euclidiean")
            {
                gcdAlgorithm.Gcd = GCDAlgorithms.GetEuclidieanGcd(numbers);
            }
            else
            {
                gcdAlgorithm.Gcd = GCDAlgorithms.GetSteinGcd(numbers);
            }
            gcdAlgorithm.InputNumbers = numbers;         
            return View(gcdAlgorithm);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}