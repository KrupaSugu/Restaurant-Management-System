using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private RestaurantDBEntities objRestaurantDbEntities;
        public HomeController()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
            
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult LogIn() 
        {  
           
            return View(); 
        }
    

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDbEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice,JsonRequestBehavior.AllowGet);
        }
    }
}