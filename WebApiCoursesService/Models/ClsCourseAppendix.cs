﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Models
{
    public class Comment
    {
        public string commentstring { get; set; }
        public string name { get; set; }
    }
    public class Ranking
    {
        public int deepness { get; set; }
        public int relaxing { get; set; }
        public int sweetness { get; set; }
    }
}