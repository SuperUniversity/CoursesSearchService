using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Controllers
{
    public class CourseUtl
    {
        //TODO
        public static IEnumerable<T> TopnFilter<T>(IEnumerable<T> inputResult, int topn)
        {
            IEnumerable<T> result = inputResult;
            if (topn != -1)
            {
                topn = (topn > result.Count()) ? result.Count() : topn;
                topn = (topn <= 0) ? 1 : topn;
                result = result.Take(topn);
            }
            return result;
        }
    }
}