using CourseReportEmailer.Repository;
using CourseReportEmailer.Workers;
using System;

namespace CourseReportEmailer
{
    class Program
    {
        private static string _connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CourseReport;Integrated Security=True";

        static void Main(string[] args)
        {
            try
            {
                var command = new EnrollmentReportDetailCommand(_connString);
                var models = command.GetList();

                var reportFileName = "EnrollmentDetailsReport.xslx";
                EnrollmentDetailReportSpreadSheetCreator enrollmentSheetCreator = new EnrollmentDetailReportSpreadSheetCreator();
                enrollmentSheetCreator.Create(reportFileName, models);

                EnrollmentDetailReportEmailSender emailer = new EnrollmentDetailReportEmailSender();
                emailer.Send(reportFileName);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }
    }
}
