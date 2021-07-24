using CouseReportEmailer.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CouseReportEmailer.Repository
{
    class EnrollmentReportDetailCommand
    {
        private string _connString;

        public EnrollmentReportDetailCommand(string connString)
        {
            _connString = connString;
        }

        public IList<EnrollmentReportDetailModel> GetList()
        {
            var enrollmentDetailsReport = new List<EnrollmentReportDetailModel>();
            var sql = "EnrollmentReport_GetList";

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                enrollmentDetailsReport = conn.Query<EnrollmentReportDetailModel>(sql).ToList();
            }


            return enrollmentDetailsReport;
        }
    }
}
