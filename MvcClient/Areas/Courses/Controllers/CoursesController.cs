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

        public async Task<ActionResult> GetNtpuAll(string query)
        {
            if(query == null)
            {
                List<NtpuCourseModel> ntpuCourses = null;
                queryString = @"api/Ntpu?topn=100";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(domain);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //GET Method  
                    HttpResponseMessage response = await client.GetAsync(queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        ntpuCourses = await response.Content.ReadAsAsync<List<NtpuCourseModel>>();
                    }
                }
            }


            return PartialView(ntpuCourses);
        }
    }
}