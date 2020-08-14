using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FactElectronicaV1.Entities;

namespace FactElectronicaV1.Controllers
{
    public class LoginController : Controller
    {

        readonly IServiceProxyClient proxy;

        public LoginController() { }
        public LoginController(IServiceProxyClient proxy)
        {
            this.proxy = proxy;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            ObservableCollection<Admin> model = proxy.GetAllAdmin();
            Session["INTENTOS"] = 0;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Login(Admin model)
        {
            bool response = true;
            if (model.ADMUSUARIO == null)
            {
                response = false;
            }
            else
            {
                Admin admin = proxy.GetOneAdmin(model.ADMUSUARIO);
                switch (admin.ADMTIPO)
                {
                    case Constants.ADMINISTRADOR:
                        response = true;
                        break;

                    case Constants.USUARIO:
                        response = false;
                        break;
                }

            }
            //if (ModelState.IsValid)
            //{
            //    //    switch (model.ADMTIPO)
            //    //    {
            //    //        case Constants.ADMINISTRADOR:
            //    //            break;
            //    //    }
            //}
            return Json(response);
        }

        [HttpPost]
        public JsonResult ValidarUsuario(string Usuario)
        {
            Admin admin = proxy.GetOneAdmin(Usuario);
            if (admin != null)
            {
                if (admin.ADMUSUARIO == "NO")
                    return new JsonResult { Data = false };
                else
                    return new JsonResult { Data = true };
            }
            else
                return new JsonResult { Data = false };
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}