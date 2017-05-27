using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class NtpuController : ApiController
    {
        private IRepository<NtpuCoursesModel> collection = new Repository<NtpuCoursesModel>("ntpuTest");

        // GET: api/SuccesssCourses
        public IEnumerable<NtpuCoursesModel> GetBySearchAll(string query)
        {
            var AllCollection = collection.GetAll()
                                .Where(c => c.科目名稱 != null && c.授課教師 != null && c.開課系所 != null && c.備註 != null);
            
            var result = AllCollection.Where(c => c.科目名稱.Contains(query) || c.授課教師.Contains(query) || c.開課系所.Contains(query) || c.備註.Contains(query));
            return result;
        }

        public IEnumerable<NtpuCoursesModel> GetBySearchEach(string coursename=null, string teachername = null, string department = null, string weekday = null)
        {
            var AllCollection = collection.GetAll()
                                    .Where(c => (coursename != null) ? c.科目名稱 != null : true)
                                    .Where(c => (teachername != null) ? c.授課教師 != null : true)
                                    .Where(c => (department != null) ? c.開課系所 != null : true)
                                    .Where(c => (weekday != null) ? c.上課時間教室 != null : true);

            var result = AllCollection.Where(c => (coursename != null) ? c.科目名稱.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.授課教師.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.開課系所.Contains(department) : true)
                                    .Where(c => (weekday != null) ? c.上課時間教室.Contains(weekday) : true);
            return result;
        }

        // POST: api/Ntpu
        public void Post(NtpuCoursesModel coursedata)
        {
            collection.Insert(coursedata);
        }

        // PUT: api/Ntpu/5
        public void PutComment(string strid, bool iscomment, Comment InputComment)
        {
            NtpuCoursesModel TargetCourse = collection.GetByID(strid);
            List<Comment> OrginalCommentData = TargetCourse.commentdata;

            if (OrginalCommentData == null)
            {
                List<Comment> InputCommentData = new List<Comment>();
                InputCommentData.Add(InputComment);
                collection.AddComment(strid, InputCommentData);
            }
            else
            {
                OrginalCommentData.Add(InputComment);
                collection.AddComment(strid, OrginalCommentData);
            }
        }

        public void PutRanking(string strid, bool isranking, Ranking InputRanking)
        {
            ObjectId id = new ObjectId(strid);
            NtpuCoursesModel TargetCourse = collection.GetByID(strid);
            List<Ranking> OriginalRankingData = TargetCourse.rankingdata;

            if (OriginalRankingData == null)
            {
                List<Ranking> NewRankingData = new List<Ranking>();
                NewRankingData.Add(InputRanking);
                collection.AddRanking(strid, NewRankingData);
            }
            else
            {
                OriginalRankingData.Add(InputRanking);
                collection.AddRanking(strid, OriginalRankingData);
            }
        }

        // DELETE: api/Ntpu/5
        public void Delete(string strid)
        {
            collection.Delete(strid);
        }
    }
}
