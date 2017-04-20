using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BMI.Models
{
    public class CalculateBMI
    {
        [Required(ErrorMessage = "Weight is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Weight must be a number")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Height must be a number")]
        public double Height { get; set; }

        [DisplayFormat(DataFormatString = "{0:n1}")]
        public double BMI { get; set; }

        [DisplayFormat(DataFormatString = "{0:n1}")]
        public double IdealBodyWt { get; set; }

        public WeightUnit WtUnit { get; set; }

        public HeightUnit HtUnit { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(0, 100, ErrorMessage = "Age must be a number")]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public static IEnumerable<SelectListItem> GetWtUnitSelectItems()
        {
            yield return new SelectListItem { Text = "kg", Value = "kg" };
            yield return new SelectListItem { Text = "lbs", Value = "lbs" };
        }

        public static IEnumerable<SelectListItem> GetHtUnitSelectItems()
        {
            yield return new SelectListItem { Text = "cm", Value = "cm" };
            yield return new SelectListItem { Text = "inches", Value = "inches" };
        }

        public static IEnumerable<SelectListItem> GetGenderSelectItems()
        {
            yield return new SelectListItem { Text = "Man", Value = "Man" };
            yield return new SelectListItem { Text = "Woman", Value = "Woman" };
        }
    }
}