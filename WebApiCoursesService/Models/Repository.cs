using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApiCoursesService.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        IMongoDatabase _database = null;
        IMongoCollection<T> collection = null;

        public Repository(string collectionname)
        {
            MongoCredential credential = MongoCredential.CreateCredential("superuniversitycourses", ConfigurationManager.AppSettings["MongoUserName"].ToString(), ConfigurationManager.AppSettings["MongoPassword"].ToString());
            MongoClientSettings mongoClientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress("ds155841.mlab.com", 55841),
                Credentials = new List<MongoCredential> { credential }
            };
            MongoClient _client = new MongoClient(mongoClientSettings);
            _database = _client.GetDatabase("superuniversitycourses");

            //MongoClient _client = new MongoClient();
            //_database = _client.GetDatabase("SuperUniversityCourses");
            collection = _database.GetCollection<T>(collectionname);
        }

        //Todo
        //public async Task<T> GetByID(string strid)
        //{
        //    ObjectId id = new ObjectId(strid);
        //    var filter = Builders<T>.Filter.Eq("_id", id);
            
        //    return await collection.Find(filter).FirstOrDefaultAsync();
        //}

        public T GetByID(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    var result = collection.AsQueryable<T>().ToListAsync();
        //    return await result;
        //}

        public IQueryable<T> GetAll()
        {
            var result = collection.AsQueryable<T>().ToList();
            return result.AsQueryable<T>();
        }


        public void Insert(T coursedata)
        {
            collection.InsertOne(coursedata);
        }

        //public void Insert(T coursedata)
        //{
        //    collection.InsertOne(coursedata);
        //}

        public void UpdateComment(string strid, List<Comment> InputCommentData)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);

            UpdateDefinition<T> update = Builders<T>.Update
                                                    .Set("commentdata", InputCommentData)
                                                    .CurrentDate("lastModified");
            var result = collection.UpdateOneAsync(filter, update);
        }

        public void UpdateRanking(string strid, List<Ranking> InputRankingData)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);

            UpdateDefinition<T> update = Builders<T>.Update
                                                    .Set("rankingdata", InputRankingData)
                                                    .CurrentDate("lastModified");
            var result = collection.UpdateOneAsync(filter, update);
        }

        public void UpdateQuestion(string strid, List<Question> InputQuestionData)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);

            UpdateDefinition<T> update = Builders<T>.Update
                                                    .Set("questiondata", InputQuestionData)
                                                    .CurrentDate("lastModified");
            var result = collection.UpdateOneAsync(filter, update);
        }

        public void Update(string strid, T UpdatedCoursedata)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.ReplaceOneAsync(filter, UpdatedCoursedata);
        }

        public async void Delete(string strid)
        {
            ObjectId id = new ObjectId(strid);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await collection.DeleteOneAsync(filter);
        }
    }
}