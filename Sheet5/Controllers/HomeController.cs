using Sheet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet5.Controllers
{
    public class HomeController : Controller
    {
        const double TPS = 0.095;
        const double TVQ = 0.09975;
        public Double arraySearch(String[,] arr, String name)
        {
            Double price = 0.0;
            for (int i = 0;i<arr.GetLength(0); i++)
            {
                if (arr[i, 0] == name)
                {
                    price = Convert.ToDouble(arr[i, 1]);
                }
            }
            return price;
        }
        public Double getTypePrice(string type)
        {
            Double price = 0.0;
            String[,] typeArray = new string[,]{
                {"TheEiffel","4.99"},
                { "TheExtraChicken","5.99"},
                {"TheBigBoy","9.99"},
                { "TheBest","14.99"}
            };
            price = arraySearch(typeArray, type);
            return price;
        }
        public Double getSizePrice(String size)
        {
            double sizePrice = 0;
            string[,] sizeArray = new string[,] {
                {"Small","1.15" },
                { "Medium","1.50"},
                { "Large","1.99"},
                { "XXL","2.50"}

            };
            sizePrice = arraySearch(sizeArray, size);
            return sizePrice;
        }
        public Double getDealPrice(String dealName)
        {
            double dealPrice = 0.0;
            string[,] dealArray = new string[,] {
            { "none","0.00"},
            { "Drink and Chips","0.98"},
            {"Drink and Cookies","0.99"}
        };

            dealPrice = arraySearch(dealArray, dealName);
            return dealPrice;
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index() {
           return View();
        }
        [HttpPost]

        public ActionResult Index(myModel order)
        {
            String selectedType = Enum.GetName(typeof(myModel.SubType), order.subType);
            String selectedSize = Enum.GetName(typeof(myModel.SubSize), order.subSize);
            String selectedDeal = Enum.GetName(typeof(myModel.Deals), order.mealDeals);
            Double typePrice = getTypePrice(selectedType);
            Double sizePrice = getSizePrice(selectedSize);
            Double dealPrice = getDealPrice(selectedDeal);
            Double subPrice = typePrice * sizePrice;
            double beforeTax = subPrice + dealPrice;
            double afterTax = beforeTax *(1+ (TPS + TVQ));
            double taxAmount = afterTax - beforeTax;
            ViewBag.type = selectedType;
            ViewBag.size = selectedSize;
            ViewBag.subPrice = subPrice;
            ViewBag.deal = selectedDeal;
            ViewBag.dealPrice = dealPrice;
            ViewBag.beforeTax = beforeTax;
            ViewBag.taxAmount = taxAmount;
            ViewBag.afterTax = afterTax;
            return View("Receipt");
        }

    }
}
