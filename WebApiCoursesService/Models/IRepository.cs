using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoursesService.Models
{
    public interface IRepository<T>
    {
        //Todo
        //Task<T> GetByID(string strid);
        T GetByID(string strid);

        //Todo
        //Task<IEnumerable<T>> GetAll()
        IQueryable<T> GetAll();


        // POST: api/SuccesssCourses(insert)
        void Insert(T coursedata);

        //// PUT: api/Ncku/5(Update)
        ////void PutComment(string strid, T.comment comment);
        //void AddComment(string strid, Comment comment);

        //void AddRanking(string strid, bool isranking, Ranking ranking);
        void Update(string strid, T coursedata);
        void UpdateComment(string strid, List<Comment> InputCommentData);
        void UpdateRanking(string strid, List<Ranking> InputRankingData);
        void UpdateQuestion(string strid, List<Question> InputQuestionData);



        // DELETE: api/Ncku/5
        void Delete(string strid);
    }
}
