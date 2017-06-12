using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using MvcClient.Areas.Courses.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace MvcClient.Areas.Courses.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses/Courses
        public ActionResult Index()
        {
            return View();
        }
        

        public static String domain = "http://taiwanuniversitiescourses.azurewebsites.net/";
        public static String queryString = null;


        public async Task<ActionResult> GetNtuBySearchAll(string query = null)
        {
            IEnumerable<NtuCourseModel> ntuCourses = await CoursesControllerUtl.BySearchAllWholeWork< NtuCourseModel>(domain, "ntu", query);
            return PartialView(ntuCourses);
        }


        public async Task<ActionResult> GetNtpuBySearchAll(string query=null)
        {
            IEnumerable<NtpuCourseModel> ntpuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NtpuCourseModel>(domain, "ntpu", query);
            return PartialView(ntpuCourses);
        }


        public async Task<ActionResult> GetNctuBySearchAll(string query = null)
        {
            IEnumerable<NctuCourseModel> nctuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NctuCourseModel>(domain, "nctu", query);
            return PartialView(nctuCourses);
        }


        public async Task<ActionResult> GetNckuBySearchAll(string query = null)
        {
            IEnumerable<NckuCourseModel> nckuCourses = await CoursesControllerUtl.BySearchAllWholeWork<NckuCourseModel>(domain, "ncku", query);
            return PartialView(nckuCourses);
        }




    }
}