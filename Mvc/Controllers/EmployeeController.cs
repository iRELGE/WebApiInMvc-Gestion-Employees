using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{

    public class EmployeeController : Controller
    {
        // GET: Employee
      
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> listEmployees;
            HttpResponseMessage response = GlobalsVariables.webApiClient.GetAsync("Employees").Result;
            listEmployees = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
            return View(listEmployees);
        }
        
        
        public ActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new MvcEmployeeModel());
            }
            else
            {
                MvcEmployeeModel emp = new MvcEmployeeModel();
                HttpResponseMessage response = GlobalsVariables.webApiClient.GetAsync("Employees/"+id.ToString()).Result;
                emp = response.Content.ReadAsAsync<MvcEmployeeModel>().Result;
                return View(emp);
            }
           
        }
        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployeeModel emp)
        {
            if(emp.EmployeeId==0)
            {
                HttpResponseMessage response = GlobalsVariables.webApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";

                return RedirectToAction("index");
            }
            else
            {
                HttpResponseMessage response = GlobalsVariables.webApiClient.PutAsJsonAsync("Employees/"+emp.EmployeeId, emp).Result;
                TempData["SuccessMessage"] = "Your item has been updated Successfully";

                return RedirectToAction("index");
            }
           
               
       
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalsVariables.webApiClient.DeleteAsync
                ("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Your item has been deleted Successfully";
            return RedirectToAction("index");
        }

       
        

      
    }
}