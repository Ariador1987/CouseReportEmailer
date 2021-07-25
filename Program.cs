using CourseReportEmailer.Models;
using Newtonsoft.Json;
using System;

namespace CourseReportEmailer
{
    class Program
    {
        private static string _connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CourseReport;Integrated Security=True";

        static void Main(string[] args)
        {
            var model = new EnrollmentReportDetailModel()
            {
                // init obj so we can return it as Json
                EnrollmentId = 1,
                CourseCode = "CA",
                Description = "desc",
                FirstName = "Mark",
                LastName = "Markins"
            };


            var Json = JsonConvert.SerializeObject(model);

            // turns Json format into a Object
            EnrollmentReportDetailModel objFromJson = (EnrollmentReportDetailModel)JsonConvert.DeserializeObject(Json, typeof(EnrollmentReportDetailModel));
        }
    }
}
