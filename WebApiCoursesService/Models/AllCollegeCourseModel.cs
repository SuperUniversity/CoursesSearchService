﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Models
{
    public class AllCollegeCourseModel
    {
        public ObjectId _id { get; set; }
        public string College { get; set; }
        public string Identity { get; set; }
        public string Semester { get; set; }
        public string CourseName { get; set; }
        public string Teacher { get; set; }
        public string TimeAndClassroom { get; set; }
        public string Major { get; set; }
        public string Required { get; set; }
        public string MaxNum { get; set; }
        public string Credit { get; set; }
        public string Limitation { get; set; }
        public string Note { get; set; }

        public List<Comment> commentdata { get; set; }
        public List<Ranking> rankingdata { get; set; }
        public DateTime lastModified { get; set; }
    }

    public class Comment
    {
        public string commentstring { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool anonym { get; set; }
        public DateTime CommentTime { get; set; }

    }
    public class Ranking
    {
        public int deepness { get; set; }
        public int relaxing { get; set; }
        public int sweetness { get; set; }
        public DateTime RankTime { get; set; }
    }
}