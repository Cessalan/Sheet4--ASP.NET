using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sheet5.Models
{
    public class myModel
    {
        [Display(Name = "Name")]
        public SubType subType { get; set; }
        public SubSize subSize { get; set; }
        public Deals mealDeals { get; set; }

        public enum SubType
        {
          [Display(Name = "The Eiffel")]
            TheEiffel,
          [Display(Name = "The Big Boy")]
            TheBigBoy,
         [Display(Name = "Extra Chiken Sub")]
            TheExtraChicken,
         [Display(Name = "The Absolute Best")]
            TheBest
        }
        public enum SubSize
        {
            Small,
            Medium,
            Large,
            XXL

        }

        public enum Deals {

            none,
            drinkAndChips,
            drinkAndCookies

        }

    }
   

}