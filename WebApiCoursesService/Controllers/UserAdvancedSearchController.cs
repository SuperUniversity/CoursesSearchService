using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class UserAdvancedSearchController : ApiController
    {
        private IRepository<User_AdvancedSearch> collection = new Repository<User_AdvancedSearch>("userAdvancedSearch");
        // GET: api/UserAdvancedSearch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserAdvancedSearch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserAdvancedSearch
        public void PostAdvancedSearch(string CourseNameQuery, string TeacherQuery, string DpartmentQuery, string WeekdayQuery, string strid=null)
        {
            User_AdvancedSearch uas = new User_AdvancedSearch();
            //uas.UserID =HttpUtility.HtmlDecode(strid);
            uas.UserID = strid;
            uas.CourseNameQuery = CourseNameQuery;
            uas.TeacherQuery = TeacherQuery;
            uas.DpartmentQuery = DpartmentQuery;
            uas.WeekdayQuery = WeekdayQuery;
            uas.lastModified = DateTime.Now.AddHours(8);
            //await Task.Run(() => { collection.Insert(uas); });
            //await Task.Factory.StartNew(() => collection.Insert(uas));
            collection.Insert(uas);
        }

        // PUT: api/UserAdvancedSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserAdvancedSearch/5
        public void Delete(int id)
        {
        }
    }
}
