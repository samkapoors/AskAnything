using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using askAnything.Models;
using System.Data.SqlClient;
using System.Data;

namespace askAnything.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(UserModel user)
        {           
            if (ModelState.IsValidField("Email_id") && ModelState.IsValidField("Password"))
            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();
                sqlParam.Add(new SqlParameter("Email_id", user.Email_id));
                

                DataTable dtUserDetails = DAL.ExecSP("UserDetails", sqlParam);                

               // if (dtUserDetails.Rows[0][0].ToString() == user.Email)

                if (dtUserDetails.Rows.Count == 1)
                    {
                    // User is exist in the database

                    List<SqlParameter> sqlParam1 = new List<SqlParameter>();
                    sqlParam1.Add(new SqlParameter("Email_id", user.Email_id));
                    sqlParam1.Add(new SqlParameter("Password", user.Password));

                    DataTable dtLoginResults = DAL.ExecSP("ValidateLogin", sqlParam1);

                    if (dtLoginResults.Rows.Count == 1)
                    {
                        // we know login is valid
                        //Tempdata for alert message to user.
                      
                        Session["Name"] = dtLoginResults.Rows[0][2];
                        Session["Userid"] = dtLoginResults.Rows[0][0];
                        TempData["testmsg"] = " Login Successfully...! ";                        
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        // Invalid login
                        TempData["testmsg"] = " Wrong Password...! ";
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    // User not Exist
                    TempData["testmsg"] = " E-mail not Registered. Please Register First...! ";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //status variable for login error msg.
                ViewBag.Status = "Login_error";
                return View("Index");
            }
        }
        
        [HttpPost]
        public ActionResult Register(UserModel user)
        {                       

            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password") && ModelState.IsValidField("Confirm_Password") && ModelState.IsValidField("First_Name"))

            {
                List<SqlParameter> sqlParam = new List<SqlParameter>();
                sqlParam.Add(new SqlParameter("Email_id", user.Email_id));               

                DataTable dtUserDetails = DAL.ExecSP("UserDetails", sqlParam);

                if (dtUserDetails.Rows.Count != 0)
                {
                    // User is exist in the database                    
                    TempData["testmsg"] = " E-mail Already Exist...! ";
                    return RedirectToAction("Index");
                }
                else
                {
                    List<SqlParameter> sqlParam1 = new List<SqlParameter>();
                    sqlParam1.Add(new SqlParameter("Email_id", user.Email_id));
                    sqlParam1.Add(new SqlParameter("Password", user.Password));
                    sqlParam1.Add(new SqlParameter("First_Name", user.First_Name));

                    DAL.ExecSP("RegisterUser", sqlParam1);
                    Session["Name"] = user.First_Name;
                    Session["Userid"] = user.User_id;
                    TempData["testmsg"] = " Register Successfully...! ";
                    return PartialView("Dashboard");
                }
            }
            else
            {
                // status variable for registeration error msg.
                ViewBag.Status = "Register_error";
                return View("Index");
            }
        }
        
        public ActionResult Logout()
        {
            Session.Remove("Name");
            Session.RemoveAll();
            return View("Index");
        }        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your Dashboard page.";
            return View();
        }
    }
}