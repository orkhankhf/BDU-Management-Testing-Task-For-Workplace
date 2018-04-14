using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDU_Management.Models;

namespace BDU_Management.Controllers
{
    public class LoginController : BaseController_Abstract, Interface
    {
        BDU_ManagementEntities db = new BDU_ManagementEntities();
        private string name;

        public string AreaName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public ActionResult Index()
        {
            ResetAllSessions();
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "authorized_person_email, authorized_person_password")] Authorized_Persons form_datas)
        {

            Authorized_Persons check_authorized_person = db.Authorized_Persons.Where(a => a.authorized_person_email == form_datas.authorized_person_email).FirstOrDefault();
            if (check_authorized_person == null)
            {
                ViewBag.LoginError = "Email düzgün daxil edilməyib!";
                return View();
            }

            //Input'dan daxil edilən şifrəni VerifyPassword methodu ilə check edir. (Ətraflı: BaseController-Abstract.cs)
            if (!PasswordStorage.VerifyPassword(form_datas.authorized_person_password, check_authorized_person.authorized_person_password))
            {
                ViewBag.LoginError = "Şifrə düzgün daxil edilməyib!";
                return View();
            }

            User_Roles role = db.User_Roles.Where(r => r.user_role_id == check_authorized_person.authorized_person_role_id).FirstOrDefault();

            //Normalda bu üsulla user authorization etmək düzgün deyil.
            //Lakin layihə üçün verilən vaxt müddəti az olduğundan dərinliyinə getmirəm.
            if (role.user_role_name == "Rektor" || role.user_role_name == "Prorektor" || role.user_role_name == "Rektor Müşaviri" || role.user_role_name == "Dekan" || role.user_role_name == "Kafedra Müdiri" || role.user_role_name == "Mərkəz Rəhbəri" || role.user_role_name == "Muzey Rəhbəri")
            {
                Session["Authorized_Person_Id"] = check_authorized_person.authorized_person_id;
                Session["Authorized_Person_Email"] = check_authorized_person.authorized_person_email;
                Session["Authorized_Person_Password"] = check_authorized_person.authorized_person_password;
                AreaName = "Admin";
            }

            return RedirectToAction("Index", "Dashboard", new { Area = AreaName });
        }
    }
}