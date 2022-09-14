using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UserR.Models;

namespace UserR.Controllers
{
    public class UserMvcController : Controller
    {
        //
        // GET: /UserMvc/
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<User> userlist = new List<User>();
            client.BaseAddress = new Uri("http://localhost:57352/api/UserApi");
            var response = client.GetAsync("UserApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<User>>();
                display.Wait();
                userlist = display.Result;
            }
            return View(userlist); 
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            client.BaseAddress = new Uri("http://localhost:57352/api/UserApi");
            var response = client.PostAsJsonAsync("UserApi", u);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Create");
        }
        public ActionResult Details(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("http://localhost:57352/api/UserApi");
            var response = client.GetAsync("UserApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                u = display.Result;
            }
            return View(u);
        }
        public ActionResult Edit(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("http://localhost:57352/api/UserApi");
            var response = client.GetAsync("UserApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                u = display.Result;
            }
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            client.BaseAddress = new Uri("http://localhost:57352/api/UserApi");
            var response = client.PutAsJsonAsync("UserApi", u);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Edit");
        }

	}
}