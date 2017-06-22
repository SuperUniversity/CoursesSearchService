using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class UserCommentController : ApiController
    {
        private IRepository<User_Comment> collection = new Repository<User_Comment>("userComment");


        public IQueryable<User_Comment> GetByUserID(string userID)
        {
            return collection.GetAll().Where(u => u.UserID == userID);
        }
    }
}
