namespace CouseReportEmailer.Models
{
    class EnrollmentReportDetailModel
    {
        private string _connString;

        public int EnrollmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }

        
    }
}
