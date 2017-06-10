using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Controllers
{
    public class CourseUtl
    {
        //TODO
        public static IEnumerable<T> TopnFilter<T>(IEnumerable<T> inputResult, int topN)
        {
            IEnumerable<T> result = inputResult;
            if (topN != -1)
            {
                topN = (topN > result.Count()) ? result.Count() : topN;
                topN = (topN <= 0) ? 1 : topN;
                result = result.Take(topN);
            }
            return result;
        }
    }
}