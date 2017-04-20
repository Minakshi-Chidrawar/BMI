using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using BMI.Models;

namespace BMI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // POST: BMICalculator
        [HttpPost]
        public ActionResult BMIResult(CalculateBMI bmi)
        {
            ViewBag.Title = "Results ";


            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var weightUnit = bmi.WtUnit.ToString();
            ViewBag.Message = weightUnit;

            var heightUnit = bmi.HtUnit.ToString();

            double weight = bmi.Weight;
            double height = bmi.Height;

            var wtLbsToKg = weight;
            var htinchesToCm = height;

            if (weightUnit == "kg")
                weight = bmi.Weight * 2.2;
            else
                wtLbsToKg = weight / 2.2;

            if (heightUnit == "cm")
                height = bmi.Height / 2.54;
            else
                htinchesToCm = height * 2.54;

            bmi.BMI = weight * 703 / (height * height);

            //Find Ideal body weight
            switch (bmi.Gender.ToString())
            {
                case "Man":
                    bmi.IdealBodyWt = (htinchesToCm - 100) - ((htinchesToCm - 100) * 0.1);
                    break;
                case "Woman":
                    bmi.IdealBodyWt = bmi.IdealBodyWt = (htinchesToCm - 100) - ((htinchesToCm - 100) * 0.15);
                    break;
            }

            return View(bmi);
        }

    }
}
