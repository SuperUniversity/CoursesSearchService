using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiCoursesService.Models;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = (from c in collection.AsQueryable<NtuCourseModel>()
                     select c).GroupBy(c => c.課號)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var  file = File.CreateText("TestFile/NtuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");
            //MessageBox.Show(q.Count().ToString());
            //MessageBox.Show(a);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("nckuTest");

            var q = (from c in collection.AsQueryable<NckuCourseModel>()
                     select c).GroupBy(c => c.課程碼)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var file = File.CreateText("TestFile/NckuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");
        }



        private void button3_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = (from c in collection.AsQueryable<NtpuCoursesModel>()

                     select c).GroupBy(c => c.課程流水號)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var file = File.CreateText("TestFile/NtpuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = (from c in collection.AsQueryable<NtuCourseModel>()
                     select c).GroupBy(c => c.課號)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var file = File.CreateText("TestFile/NtuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");
            //MessageBox.Show(q.Count().ToString());
            //MessageBox.Show(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
                        var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("nckuTest");

            var q = from c in collection.AsQueryable<NckuCourseModel>()
                    group c by new { c.課程碼, c.課程名稱, c.時間, c.教師姓名, c.系所名稱, c.教室, c.組別, c.分班碼, c.班別, c.系號, c.屬性碼 } into g
                    where g.Count() > 1
                    select g.Key;

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var file = File.CreateText("TestFile/NckuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = (from c in collection.AsQueryable<NtpuCoursesModel>()

                     select c).GroupBy(c => c.課程流水號)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);

            string a = "";
            foreach (var item in q.ToList())
            {
                a += item + "\n";
            }


            var file = File.CreateText("TestFile/NtpuDuplicateList.txt");
            file.Write(a);
            file.Close();
            MessageBox.Show("done!");


        }

        private void Find_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");


            ObjectId id = new ObjectId("5925025299eff624342895d5");
            var filter = Builders<NckuCourseModel>.Filter.Eq("_id", id);
            //var filter = Builders<NckuCourseModel>.Filter.Eq("教師姓名", "施光隆");
            var cursor = collection.Find(filter);

            //string name = cursor.FirstOrDefault().教師姓名;
            List<Comment> comments = cursor.FirstOrDefault().commentdata;
            //bool exist = comments == null;
            //MessageBox.Show( comments + " " + exist);

            List<string> InputComments = new List<string>();
            InputComments.Add("Good!!!");
            var update = Builders<NckuCourseModel>.Update
                        .Set("comment", InputComments)
                        .CurrentDate("lastModified");
            MessageBox.Show("Done!");

            var result =  collection.UpdateOne(filter, update);

            MessageBox.Show("Done!");

            //else
            //{
            //    comments.Add();
            //}

        }

        private void GetAll_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");


            collection.ToJson().ToList();

        }

        private void Mlab_Click(object sender, EventArgs e)
        {
            //MongoUrl url = new MongoUrl("mongodb://jeremy4555:P@ssw0rd@ds155841.mlab.com:55841/superuniversitycourses");
            //MongoClient _client = new MongoClient(url);

            var credential = MongoCredential.CreateCredential("superuniversitycourses", "jeremy4555", "P@ssw0rd");
            var mongoClientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress("ds155841.mlab.com", 55841),
                Credentials = new List<MongoCredential> { credential }
            };

            MongoClient _client = new MongoClient(mongoClientSettings);
            IMongoDatabase _database = _client.GetDatabase("superuniversitycourses");
            IMongoCollection<NtpuCoursesModel> collection = _database.GetCollection<NtpuCoursesModel>("ntpuTest");

            ObjectId id = new ObjectId("59253ad699eff6165cead28d");
            string teststring = collection.AsQueryable<NtpuCoursesModel>().Where(c => c._id==id).FirstOrDefault().開課系所;
            MessageBox.Show(teststring);



        }
    }
}
