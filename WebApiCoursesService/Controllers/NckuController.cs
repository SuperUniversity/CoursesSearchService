using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class NckuController : ApiController
    {
        private IRepository<NckuCourseModel> collection = new Repository<NckuCourseModel>("nckuTest");

        // GET: api/SuccesssCourses
        public IEnumerable<NckuCourseModel> GetBySearchAll(string query)
        {
            var AllCollection = collection.GetAll()
                .Where(c => c.課程名稱 != null && c.教師姓名 != null && c.系所名稱 != null && c.備註 != null);

            var result = AllCollection.Where(c => c.課程名稱.Contains(query) || c.教師姓名.Contains(query) || c.系所名稱.Contains(query) || c.備註.Contains(query));
            return result;
        }

        public IEnumerable<NckuCourseModel> GetBySearchEach(string coursename = null, string teachername = null, string department = null, string weekday = null)
        {
            var AllCollection = collection.GetAll()
                                    .Where(c => (coursename != null) ? c.課程名稱 != null : true)
                                    .Where(c => (teachername != null) ? c.教師姓名 != null : true)
                                    .Where(c => (department != null) ? c.系所名稱 != null : true)
                                    .Where(c => (weekday != null) ? c.時間 != null : true);

            var result = AllCollection.Where(c => (coursename != null) ? c.課程名稱.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.教師姓名.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.系所名稱.Contains(department) : true)
                                    .Where(c => (weekday != null) ? c.時間.Contains(weekday) : true);
            return result;
        }

        // POST: api/SuccesssCourses(insert)
        public void Post(NckuCourseModel coursedata)
        {
            collection.Insert(coursedata);
        }

        //// PUT: api/Ncku/5(Update)
        public void PutComment(string strid, bool iscomment, Comment InputComment)
        {
            NckuCourseModel TargetCourse = collection.GetByID(strid);
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
            NckuCourseModel TargetCourse = collection.GetByID(strid);
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
        

        // DELETE: api/Ncku/5
        public void Delete(string strid)
        {
            collection.Delete(strid);
        }
    }
}
