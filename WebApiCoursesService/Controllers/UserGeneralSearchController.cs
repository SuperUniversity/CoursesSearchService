using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class UserGeneralSearchController : ApiController
    {
        private IRepository<User_GeneralSearch> collection = new Repository<User_GeneralSearch>("userGeneralSearch");
        // GET: api/UserGeneralSearch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserGeneralSearch/5
        public string Get(int id)
        {
            return "value";
        }

        //Only This Work
        // POST: api/UserGeneralSearch
        public void PostGeneralSearch(string Query, string strid = null)
        {
            User_GeneralSearch ugs = new User_GeneralSearch();
            //ugs.UserID =HttpUtility.HtmlDecode(strid);
            ugs.UserID = strid;
            ugs.Query = Query;
            ugs.lastModified = DateTime.Now.AddHours(8);
            collection.Insert(ugs);
        }

        // PUT: api/UserGeneralSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserGeneralSearch/5
        public void Delete(int id)
        {
        }
    }
}
