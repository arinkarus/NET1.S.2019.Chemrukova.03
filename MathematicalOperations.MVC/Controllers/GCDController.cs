using MathematicalOperations.MVC.Models;
using System.Web.Mvc;
using System;

namespace MathematicalOperations.MVC.Controllers
{
    public class GCDController : Controller
    {
        public ActionResult Algorithm(int[] numbers, string algorithmType)
        {
            var gcdAlgorithm = new GcdAlgorithm
            {
                Name = algorithmType
            };
            try
            {
                gcdAlgorithm.Gcd = GetGcd(numbers, algorithmType);
            }
            catch(ArgumentException)
            {
                return RedirectToAction("CalculationError");
            }
            gcdAlgorithm.InputNumbers = numbers;         
            return View(gcdAlgorithm);
        }

        private int GetGcd(int[] numbers, string algorithmType)
        {
            if (algorithmType == "euclidiean")
            {
                return GCDAlgorithms.GetEuclidieanGcd(numbers);
            }
            else
            {
                return GCDAlgorithms.GetSteinGcd(numbers);
            }
        }

        public ActionResult CalculationError()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}