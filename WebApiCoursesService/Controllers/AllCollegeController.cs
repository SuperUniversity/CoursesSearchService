using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class AllCollegeController : ApiController
    {
        private IRepository<AllCollegeCourseModel> collection = new Repository<AllCollegeCourseModel>("allcourses");

        // GET: api/SuccesssCourses
        public IQueryable<AllCollegeCourseModel> GetBySearchAll(string college, string query, string query2 = null, string query3 = null, string exclude = null, int topn = -1)
        {
            var AllCollection = collection.GetAll()
                                    .Where(c => c.College == college)
                                    .Where(c => c.CourseName != null && c.Teacher != null && c.Major != null);

            var result = AllCollection.Where(c => c.CourseName.Contains(query) || c.Teacher.Contains(query) || c.Major.Contains(query));
            result = (query2 != null) ? result.Where(c => c.CourseName.Contains(query2) || c.Teacher.Contains(query2) || c.Major.Contains(query2)) : result;
            result = (query3 != null) ? result.Where(c => c.CourseName.Contains(query3) || c.Teacher.Contains(query3) || c.Major.Contains(query3)) : result;
            result = (exclude != null) ? result.Where(c => !c.CourseName.Contains(exclude) && !c.Teacher.Contains(exclude) && !c.Major.Contains(exclude)) : result;

            result = CourseUtl.TopnFilter<AllCollegeCourseModel>(result.AsQueryable< AllCollegeCourseModel>(), topn);

            return result.AsQueryable< AllCollegeCourseModel>();
        }

        public IQueryable<AllCollegeCourseModel> GetBySearchEach(string college, string coursename = null, string teachername = null, string department = null, string weekday = null, int topn = -1)
        {
            var AllCollection = collection.GetAll()
                                    .Where(c => c.College == college)
                                    .Where(c => (coursename != null) ? c.CourseName != null : true)
                                    .Where(c => (teachername != null) ? c.Teacher != null : true)
                                    .Where(c => (department != null) ? c.Major != null : true)
                                    .Where(c => (weekday != null) ? c.TimeAndClassroom != null : true);

            var result = AllCollection.Where(c => (coursename != null) ? c.CourseName.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.Teacher.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.Major.Contains(department) : true)
                                    .Where(c => (weekday != null) ? c.TimeAndClassroom.Contains(weekday) : true);

            result = CourseUtl.TopnFilter<AllCollegeCourseModel>(result.AsQueryable<AllCollegeCourseModel>(), topn);

            return result.AsQueryable<AllCollegeCourseModel>();
        }

        public AllCollegeCourseModel GetByID(string strid)
        {
            ObjectId id = new ObjectId(strid);
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            return TargetCourse;
        }

        // POST: api/Ntpu
        public void Post(AllCollegeCourseModel coursedata)
        {
            collection.Insert(coursedata);
        }

        // PUT: api/Ntpu/5
        public void PutComment(string strid, bool iscomment, Comment InputComment)
        {
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
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
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
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
