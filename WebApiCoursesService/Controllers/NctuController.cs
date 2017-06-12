using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class NctuController : ApiController
    {
        private IRepository<NctuCourseModel> collection = new Repository<NctuCourseModel>("nctuTest");

        // GET: api/SuccesssCourses
        public IQueryable<NctuCourseModel> GetBySearchAll(string query, string query2 = null, string query3 = null, string exclude = null, int topn = -1)
        {

            //Todo 拿掉備註
            var AllCollection = collection.GetAll().Where(c => c.課程名稱 != null && c.開課教師 != null);
            var result = AllCollection.Where(c => c.課程名稱.Contains(query) || c.開課教師.Contains(query));
            result = (query2 != null) ? result.Where(c => c.課程名稱.Contains(query2) || c.開課教師.Contains(query2)) : result;
            result = (query3 != null) ? result.Where(c => c.課程名稱.Contains(query3) || c.開課教師.Contains(query3)) : result;
            result = (exclude != null) ? result.Where(c => !c.課程名稱.Contains(exclude) && !c.開課教師.Contains(exclude)) : result;

            result = CourseUtl.TopnFilter<NctuCourseModel>(result.AsQueryable< NctuCourseModel>(), topn);

            return result.AsQueryable< NctuCourseModel>();
        }

        public IQueryable<NctuCourseModel> GetBySearchEach(string coursename = null, string teachername = null, string department = null, string weekday = null, int topn = -1)
        {
            //Todo 沒有開課系所這個欄位
            var AllCollection = collection.GetAll()
                                    .Where(c => (coursename != null) ? c.課程名稱 != null : true)
                                    .Where(c => (teachername != null) ? c.開課教師 != null : true)
                                    .Where(c => (weekday != null) ? c.上課時間及教室 != null : true);

            var result = AllCollection.Where(c => (coursename != null) ? c.課程名稱.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.開課教師.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.上課時間及教室.Contains(department) : true);

            result = CourseUtl.TopnFilter<NctuCourseModel>(result.AsQueryable< NctuCourseModel>(), topn);

            return result.AsQueryable<NctuCourseModel>();
        }

        public NctuCourseModel GetByID(string strid)
        {
            ObjectId id = new ObjectId(strid);
            NctuCourseModel TargetCourse = collection.GetByID(strid);
            return TargetCourse;
        }

        // POST: api/Ntpu
        public void Post(NctuCourseModel coursedata)
        {
            collection.Insert(coursedata);
        }

        // PUT: api/Ntpu/5
        public void PutComment(string strid, bool iscomment, Comment InputComment)
        {
            NctuCourseModel TargetCourse = collection.GetByID(strid);
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
            NctuCourseModel TargetCourse = collection.GetByID(strid);
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