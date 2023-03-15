using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class AddApplications
    {
        public DateTime DateAppointment { get; set; }
        public string targetApplication { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronomyc { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string Division { get; set; }
        public string LFPStaff { get; set; }    
        public string Organizacia { get; set; }
        public string Primechanie { get; set; }
        public DateTime Birthday { get; set; }
        public string SerialPass { get; set; }
        public string NumberPass { get; set; }

    }
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (HranitelPROWSREntities.GetContext().User.Any(u => u.Login == username && u.Password == password))
            {

                
                return Redirect("~/Home/ChangeOper/?login=" + username );
            }
            return Content("Неверные данные");
        }
        [HttpGet]
        public ActionResult View1()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ChangeOper(string login)
        {
            return View();
        }

        [HttpGet]

        public ActionResult PersonalVisit()
        {
            ViewBag.Appointment = new SelectList(HranitelPROWSREntities.GetContext().Appointment, "id", "StaffCode");
            return View();
        }
        [HttpPost]
        public ActionResult PersonalVisit(string firstname)
        {
            return Content(firstname);
        }
        [HttpGet]

        public ActionResult Registration()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string email, string login, string password)
        {
            User newuser = new User();
            newuser.Login = login;
            newuser.Password = password;
            // newuser.Email = email;
            return View();
        }
        [HttpGet]

        public ActionResult AddApplicationPersonal(string username)
        {
            ViewBag.staffcode = new SelectList(HranitelPROWSREntities.GetContext().Appointment, "id", "StaffCode");
            return View();
        }
        [HttpPost]
        public ActionResult AddApplicationPersonal(AddApplications applnew, string staffcode, string username)
        { 
            var user = HranitelPROWSREntities.GetContext().User.Include(u => u.UserGroupVisit).FirstOrDefault(u => u.Login == username);
            user.FirstName = applnew.Firstname;
            user.LastName = applnew.Lastname;
            user.Patronomyc = applnew.Patronomyc;

            user.Phone = applnew.Phone;
            user.Birthday = applnew.Birthday;
            Appointment newAppoint = new Appointment();
            newAppoint.date = applnew.DateAppointment;
            newAppoint.StaffCode = Convert.ToInt32(staffcode);
            Applications newApplication = new Applications();
            newApplication.DateRegistr = DateTime.Now;
            newApplication.Appointment = newAppoint;
            newApplication.StatusCode = 0;
            newApplication.GroupVisit = false;
            UserGroupVisit usergroup = new UserGroupVisit();
            usergroup.Applications = newApplication;
            usergroup.Name = username + " personal visit";
            user.UserGroupVisit.Add(usergroup);
            try
            {
                HranitelPROWSREntities.GetContext().SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Response.Write("Object: " + validationError.Entry.Entity.ToString());
                    Response.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Response.Write(err.ErrorMessage + "");
                        }
                }
            }
            return Content("Успех");
        }
    }
}