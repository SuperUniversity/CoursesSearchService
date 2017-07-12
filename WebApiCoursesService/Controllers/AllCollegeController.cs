using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class AllCollegeController : ApiController
    {
        private IRepository<AllCollegeCourseModel> collection = new Repository<AllCollegeCourseModel>("allcourses");
        //private IRepository<User_Comment> UserCommentCollection = new Repository<User_Comment>("userComment");
        //private IRepository<User_Ranking> UserRankingCollection = new Repository<User_Ranking>("userRanking");

        // GET: api/SuccesssCourses
        public IQueryable<AllCollegeCourseModel> GetBySearchAll(string college, string query, string semester=null, string query2 = null, string query3 = null, string exclude = null, int topn = -1)
        {
            
            var AllCollection = collection.GetAll()
                                    .Where(c => c.College == college)
                                    .Where(c => c.CourseName != null && c.Teacher != null && c.Major != null);

            if(semester != null)
            {
                AllCollection = AllCollection.Where(c => c.Semester == semester);
            }

            var result = AllCollection.Where(c => c.CourseName.Contains(query) || c.Teacher.Contains(query) || c.Major.Contains(query));
            result = (query2 != null) ? result.Where(c => c.CourseName.Contains(query2) || c.Teacher.Contains(query2) || c.Major.Contains(query2)) : result;
            result = (query3 != null) ? result.Where(c => c.CourseName.Contains(query3) || c.Teacher.Contains(query3) || c.Major.Contains(query3)) : result;
            result = (exclude != null) ? result.Where(c => !c.CourseName.Contains(exclude) && !c.Teacher.Contains(exclude) && !c.Major.Contains(exclude)) : result;


            result = CourseUtl.TopnFilter<AllCollegeCourseModel>(result.AsQueryable<AllCollegeCourseModel>(), topn);

            return result.AsQueryable< AllCollegeCourseModel>();
        }

        public IQueryable<AllCollegeCourseModel> GetBySearchEach(string college, string semester = null, string coursename = null, string teachername = null, string department = null, string weekday = null, int topn = -1)
        {
            var AllCollection = collection.GetAll()
                                    .Where(c => c.College == college)
                                    .Where(c => (coursename != null) ? c.CourseName != null : true)
                                    .Where(c => (teachername != null) ? c.Teacher != null : true)
                                    .Where(c => (department != null) ? c.Major != null : true)
                                    .Where(c => (weekday != null) ? c.TimeAndClassroom != null : true);

            if (semester != null)
            {
                AllCollection = AllCollection.Where(c => c.Semester == semester);
            }


            var result = AllCollection.Where(c => (coursename != null) ? c.CourseName.Contains(coursename) : true)
                                    .Where(c => (teachername != null) ? c.Teacher.Contains(teachername) : true)
                                    .Where(c => (department != null) ? c.Major.Contains(department) : true)
                                    .Where(c => (weekday != null) ? c.TimeAndClassroom.Contains(weekday) : true);

            result = CourseUtl.TopnFilter<AllCollegeCourseModel>(result.AsQueryable<AllCollegeCourseModel>(), topn);


            return result.AsQueryable<AllCollegeCourseModel>();
        }

        public AllCollegeCourseModel GetByID(string strid)
        {
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
            //InputComment.commentID = Guid.NewGuid().ToString();
            InputComment.lastModified = DateTime.Now.AddHours(8);
            InputComment.likes = 0;
            InputComment.dislikes = 0;
            InputComment.hidden = false;
            //InputComment.commentstring = HttpUtility.HtmlDecode(InputComment.commentstring);
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            List<Comment> OrginalCommentData = TargetCourse.commentdata;

            if (OrginalCommentData == null)
            {
                List<Comment> InputCommentData = new List<Comment>();
                InputCommentData.Add(InputComment);
                collection.UpdateComment(strid, InputCommentData);
            }
            else
            {
                OrginalCommentData = OrginalCommentData.ToList();
                OrginalCommentData.Add(InputComment);
                collection.UpdateComment(strid, OrginalCommentData);
            }
        }

        public void PutRanking(string strid, bool isranking, Ranking InputRanking)
        {
            //InputRanking.rankingID = Guid.NewGuid().ToString();
            InputRanking.lastModified = DateTime.Now.AddHours(8);
            ObjectId id = new ObjectId(strid);
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            List<Ranking> OriginalRankingData = TargetCourse.rankingdata;

            if (OriginalRankingData == null)
            {
                List<Ranking> NewRankingData = new List<Ranking>();
                NewRankingData.Add(InputRanking);
                collection.UpdateRanking(strid, NewRankingData);
            }
            else
            {
                OriginalRankingData = OriginalRankingData.ToList();
                OriginalRankingData.Add(InputRanking);
                collection.UpdateRanking(strid, OriginalRankingData);
            }
        }

        public void PutQuestion(string strid, bool isquestion, Question InputQuestion)
        {
            //InputComment.commentID = Guid.NewGuid().ToString();
            InputQuestion.lastModified = DateTime.Now.AddHours(8);
            InputQuestion.hidden = false;

            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            List<Question> OrginalQuestionData = TargetCourse.questiondata;

            if (OrginalQuestionData == null)
            {
                List<Question> InputQuestionData = new List<Question>();
                InputQuestionData.Add(InputQuestion);
                collection.UpdateQuestion(strid, InputQuestionData);
            }
            else
            {
                OrginalQuestionData = OrginalQuestionData.ToList();
                OrginalQuestionData.Add(InputQuestion);
                collection.UpdateQuestion(strid, OrginalQuestionData);
            }
        }

        public void PutResponse(string strid, string questionid, bool isreponse, Response InputResponse)
        {
            //InputComment.commentID = Guid.NewGuid().ToString();
            InputResponse.lastModified = DateTime.Now.AddHours(8);
            InputResponse.hidden = false;

            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            Question TargetQuestion = TargetCourse.questiondata.Where(q => q.questionID == questionid).FirstOrDefault();
            List<Response> OriginalResponseData = TargetQuestion.responsedata;

            if (OriginalResponseData == null)
            {
                List<Response> InputResponseData = new List<Response>();
                InputResponseData.Add(InputResponse);
                TargetCourse.questiondata.Where(q => q.questionID == questionid).FirstOrDefault().responsedata = InputResponseData;
                collection.UpdateQuestion(strid, TargetCourse.questiondata);
            }
            else
            {
                OriginalResponseData = OriginalResponseData.ToList();
                OriginalResponseData.Add(InputResponse);
                TargetCourse.questiondata.Where(q => q.questionID == questionid).FirstOrDefault().responsedata = OriginalResponseData;
                collection.UpdateQuestion(strid, TargetCourse.questiondata);
            }
        }

        //public void PutFavorite(string strid,bool isfavorite, string userId)
        //{

        //    AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
        //    TargetCourse.favoritedata.Add(userId);
        //}

        //public void DeleteFavorite(string strid, bool isfavorite, string userId)
        //{
        //    AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
        //    TargetCourse.favoritedata.Remove(userId);
        //}

        // Delete: api/Ntpu/5
        public void DeleteComment(string strid, string commentId)
        {
            //InputComment.commentstring = HttpUtility.HtmlDecode(InputComment.commentstring);
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            Comment TargetComment = (from c in TargetCourse.commentdata
                                     where c.commentID == commentId
                                     select c).FirstOrDefault();
            TargetCourse.commentdata.Remove(TargetComment);
            var updatedCommentData = TargetCourse.commentdata;
            collection.UpdateComment(strid, updatedCommentData);
        }


        // Delete: api/Ntpu/5
        public void DeleteRnking(string strid, string rankingId)
        {
            //InputComment.commentstring = HttpUtility.HtmlDecode(InputComment.commentstring);
            AllCollegeCourseModel TargetCourse = collection.GetByID(strid);
            Ranking TargetRanking = (from r in TargetCourse.rankingdata
                                     where r.rankingID == rankingId
                                     select r).FirstOrDefault();
            TargetCourse.rankingdata.Remove(TargetRanking);
            var updatedRankingData = TargetCourse.rankingdata;

            collection.UpdateRanking(strid, updatedRankingData);
        }

        // DELETE: api/Ntpu/5
        public void Delete(string strid)
        {
            collection.Delete(strid);
        }
    }
}
