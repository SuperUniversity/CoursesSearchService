using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {

        MongoClient _client = new MongoClient();
        IMongoDatabase _database = null;
        IMongoCollection<T> collection = null;

        public Repository(string collectionname)
        {
            _database = _client.GetDatabase("SuperUniversityCourses");
            collection = _database.GetCollection<T>(collectionname);
        }

        public T GetByID(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            
            return collection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return collection.AsQueryable<T>().ToList();
        }

        //public IEnumerable<T> GetBySearchAll(string query)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> GetByCourseName(string coursename)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> GetByTeacherName(string teachername)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> GetByDepartment(string department)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<T> GetByWeekday(string Weekday)
        //{
        //    throw new NotImplementedException();
        //}

        public async void Insert(T coursedata)
        {
            await collection.InsertOneAsync(coursedata);
        }

        //public void AddComment(string strid, bool iscomment, Comment comment)
        //{

        //}

        //public void AddRanking(string strid, bool isranking, Ranking ranking)
        //{
        //    throw new NotImplementedException();
        //}

        public async void Update(string strid, T UpdatedCoursedata)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await collection.ReplaceOneAsync(filter, UpdatedCoursedata);
        }

        public async void Delete(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await collection.DeleteOneAsync(filter);
        }
    }
}