using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDU_Management.Models;

namespace BDU_Management.Filters
{
    public class AdminLoginFilter : ActionFilterAttribute
    {
        BDU_ManagementEntities db = new BDU_ManagementEntities();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Əgər sessionlar null'dursa...
            if (HttpContext.Current.Session["Authorized_Person_Id"] == null || HttpContext.Current.Session["Authorized_Person_Email"] == null || HttpContext.Current.Session["Authorized_Person_Password"] == null)
            {
                RedirectToLoginPage(filterContext);
            }
            else
            {
                try
                {
                    //Giriş etmiş istifadəçinin id,email və password məlumatlarını al
                    int Authorized_Person_Id = Convert.ToInt32(HttpContext.Current.Session["Authorized_Person_Id"]);
                    string Authorized_Person_Email = HttpContext.Current.Session["Authorized_Person_Email"].ToString();
                    string Authorized_Person_Password = HttpContext.Current.Session["Authorized_Person_Password"].ToString();

                    var role = (from ap in db.Authorized_Persons
                                join r in db.User_Roles on ap.authorized_person_role_id equals r.user_role_id
                                where ap.authorized_person_id == Authorized_Person_Id && ap.authorized_person_email == Authorized_Person_Email && ap.authorized_person_password == Authorized_Person_Password
                                select r.user_role_name).FirstOrDefault();

                    //Normalda bu üsulla user authorization etmək düzgün deyil. (Flexible Authorization istifadə edilmədiyinə görə)
                    //Lakin layihə üçün verilən vaxt müddəti az olduğundan dərinliyinə getmirəm.
                    if (role == null)
                    {
                        RedirectToLoginPage(filterContext);
                    }
                }
                catch
                {
                    RedirectToLoginPage(filterContext);
                }
            }
            base.OnActionExecuting(filterContext);
        }
        private void RedirectToLoginPage(ActionExecutingContext filterContext)
        {
            var Url = new UrlHelper(filterContext.RequestContext);
            var url = Url.Action("Index", "Login", new { Area = "" });
            filterContext.Result = new RedirectResult(url);
            return;
        }
    }
}