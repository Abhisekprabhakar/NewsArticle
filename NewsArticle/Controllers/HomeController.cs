using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using businessLogic;
using System.Dynamic;
using NewsArticle.App_Start;

namespace NewsArticle.Controllers
{
    
    public class HomeController : Controller
    {
        articleLogic artLogic;
        userLogic useLogic;
        public HomeController()
        {
            artLogic = new articleLogic();
            useLogic = new userLogic();
        }
        [CustomAuthentication]
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.articles = artLogic.getAll();
            return View(model);
        }
        [CustomAuthentication]
        public ActionResult Article(int id)
        {
            var model = artLogic.getArticleById(id);
            if (model == null)
            {
                return View("notfound");
            }
            return View(model);
        }
        [CustomAuthorize("admin")]
        [CustomAuthentication]
        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize("admin")]
        [CustomAuthentication]
        public ActionResult AddArticle(article ar)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(ar.article1);
                Console.WriteLine(ar.title);
                artLogic.AddArticle(ar);
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        //registeration page
        [AllowAnonymous]
        public ActionResult Register()
        {
            var logged = Session["userId"];
            if (logged != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                string res = useLogic.AddUser(u);
                if (res != "True")
                {
                    TempData["Invalid-Register"] = res;
                    return View();
                }
                else
                {
                    TempData["Registered-Username"] = u.username;
                    return Redirect("/Home/Login");
                }
            }
            else
            {
                return View();
            }

        }

        //login page
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["userId"] != null)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            int userId = useLogic.CheckUser(username, password);
            if (userId != 0)
            {
                Session["userId"] = userId;
                Session["userName"] = username;
                Session["usertype"] = useLogic.getUserType(userId);

                return Redirect("/Home/Index");
            }
            else
            {
                TempData["Invalid"] = "Invalid Credentials !!!";
                return View();
            }
        }

        //logout
        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["username"] = null;
            Session["usertype"] = null;
            return Redirect("/Home/Index");
        }
    }
}