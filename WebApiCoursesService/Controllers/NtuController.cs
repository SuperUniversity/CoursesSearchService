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
    public class NtuController : ApiController
    {
        private IRepository<NtuCourseModel> collection = new Repository<NtuCourseModel>("ntu");

        // GET api/values/5
        public IEnumerable<NtuCourseModel> GetBySearchAll(string query)
        {
            //課程名稱，授課教師，授課對象，備註
            var AllCollection = collection.GetAll();
            var result = AllCollection.Where(c => c.課程名稱.Contains(query) || c.授課教師.Contains(query) || c.授課對象.Contains(query) || c.備註.Contains(query));
            return result;
        }

        public IEnumerable<NtuCourseModel> GetBySearchEach(string coursename = null, string teachername = null, string department = null, string weekday = null)
        {
            var AllCollection = collection.GetAll();
            var result = AllCollection.Where(c => (coursename != null) ? c.課程名稱.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.授課教師.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.授課對象.Contains(department) : true)
                                    .Where(c => (weekday != null) ? c.時間教室.Contains(weekday) : true);
            return result;
        }

        // POST api/values
        public void Post(NtuCourseModel coursedata)
        {
            collection.Insert(coursedata);
        }

        // PUT api/values/5
        public void PutComment(string strid, bool iscomment, Comment InputComment)
        {
            NtuCourseModel TargetCourse = collection.GetByID(strid);
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
            NtuCourseModel TargetCourse = collection.GetByID(strid);
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

        // DELETE api/values/5
        public void Delete(string strid)
        {
            collection.Delete(strid);
        }
    }
}
