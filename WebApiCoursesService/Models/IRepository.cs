using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoursesService.Models
{
    public interface IRepository<T>
    {
        Task<T> GetByID(string strid);

        // GET: api/SuccesssCourses
        Task<IEnumerable<T>> GetAll();

        //IEnumerable<T> GetBySearchAll(string query);

        //IEnumerable<T> GetByCourseName(string coursename);

        //IEnumerable<T> GetByTeacherName(string teachername);

        //IEnumerable<T> GetByDepartment(string department);

        //IEnumerable<T> GetByWeekday(string Weekday);


        // POST: api/SuccesssCourses(insert)
        void Insert(T coursedata);

        //// PUT: api/Ncku/5(Update)
        ////void PutComment(string strid, T.comment comment);
        //void AddComment(string strid, Comment comment);

        //void AddRanking(string strid, bool isranking, Ranking ranking);
        //void Update(string strid, T coursedata);
        void AddComment(string strid, List<Comment> InputCommentData);
        void AddRanking(string strid, List<Ranking> InputRankingData);



        // DELETE: api/Ncku/5
        void Delete(string strid);
    }
}
