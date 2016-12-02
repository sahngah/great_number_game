using Nancy;
using System;

namespace GreatNumberGame
{
    public class GameModule : NancyModule
    {
        public GameModule()
        {
            Get("/", args => 
                {
                if (Session["SomeNumber"] == null)
                    {
                    int RandNum = new Random().Next(1,101);
                    Session["SomeNumber"] = RandNum;
                    }
                ViewBag.random = Session["SomeNumber"];
                if (((string)Session["check"]) == "true")
                {
                    ViewBag.truetrue = true; 
                }
                else if (((string)Session["check"]) == "higher")
                {
                    ViewBag.higherhigher = true;
                } 
                else if (((string)Session["check"]) == "lower")
                {
                    ViewBag.lowerlower = true;
                } 
                return View["home"];
                }); 
            Post("/check", args => 
            { 
                if (((int)Request.Form.number) == ((int)Session["SomeNumber"]))
                {
                    Session["check"] = "true";
                }
                else if (((int)Request.Form.number) > ((int)Session["SomeNumber"]))
                { 
                    Session["check"] = "lower";
                }
                else if (((int)Request.Form.number) < ((int)Session["SomeNumber"]))
                {
                    Session["check"] = "higher";
                }
                return Response.AsRedirect("/");
            }); 
            Get("/refresh", args => 
            {
                Session.DeleteAll();
                return Response.AsRedirect("/");
            });
        }
    } 
}
 