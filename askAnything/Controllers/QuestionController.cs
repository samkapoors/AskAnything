using askAnything.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace askAnything.Controllers
{
    public class QuestionController : Controller
    {        
        [HttpPost]
        public ActionResult AddQuestion(QuestionModel question)
        {
            if (Session["Userid"] != null)
            {
                if (ModelState.IsValidField("Info_file"))
                {
                    question.User_id = int.Parse(Session["Userid"].ToString());

                    List<SqlParameter> sqlParam = new List<SqlParameter>();
                    sqlParam.Add(new SqlParameter("User_id", question.User_id));
                    sqlParam.Add(new SqlParameter("Info_file", question.Info_file));

                    DAL.ExecSP("AddQuestion", sqlParam);

                    TempData["testmsg"] = " Question Added Successfully...! ";
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    TempData["testmsg"] = " Question Field is Empty...! ";
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                TempData["testmsg"] = " PLEASE LOGIN FIRST...! ";
                return RedirectToAction("Index","Home");
            }
            
        }
    }
}