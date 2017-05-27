using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<T> GetByID(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await collection.AsQueryable<T>().ToListAsync();
            return result;
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

        public async void AddComment(string strid, List<Comment> InputCommentData)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            UpdateDefinition<T> update = Builders<T>.Update
                                                    .Set("commentdata", InputCommentData)
                                                    .CurrentDate("lastModified");
            var result = await collection.UpdateOneAsync(filter, update);
        }

        public async void AddRanking(string strid, List<Ranking> InputRankingData)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            UpdateDefinition<T> update = Builders<T>.Update
                                                    .Set("rankingdata", InputRankingData)
                                                    .CurrentDate("lastModified");
            var result = await collection.UpdateOneAsync(filter, update);
        }

        //public async void Update(string strid, T UpdatedCoursedata)
        //{
        //    ObjectId id = new ObjectId(strid);
        //    var filter = Builders<T>.Filter.Eq("_id", id);
        //    await collection.ReplaceOneAsync(filter, UpdatedCoursedata);
        //}

        public async void Delete(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await collection.DeleteOneAsync(filter);
        }
    }
}