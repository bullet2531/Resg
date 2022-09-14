using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserR.Models;

namespace UserR.Controllers
{
    public class UserApiController : ApiController
    {
        UserDBEntities db = new UserDBEntities();
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            List<User> Usr = db.Users.ToList();
            return Ok(Usr);
        }
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var usr = db.Users.Where(model => model.UserId == id).FirstOrDefault();
            return Ok(usr);
        }

        [HttpPost]
        public IHttpActionResult AddUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult UpdateUser(User u)
        {
            var usr = db.Users.Where(model => model.UserId == u.UserId).FirstOrDefault();
            if (usr != null)
            {
                usr.UserId = u.UserId;
                usr.FullName = u.FullName;
                usr.Email = u.Email;
                usr.Location = u.Location;
                usr.Language = u.Language;
                usr.Password = u.Password;
                usr.Role = u.Role;
                usr.Userpin = u.Userpin;
                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
