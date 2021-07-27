using System.Net;
using System.Net.Mail;

namespace CourseReportEmailer.Workers
{
    class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            NetworkCredential credentials = new NetworkCredential("bozidar.bralic@gmail.com", "password");
            client.EnableSsl = true;
            client.Credentials = credentials;

            MailMessage message = new MailMessage("bozidar.bralic@gmail.com", "bozidar.bralic1987@yahoo.com");

            message.Subject = "Enrollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hi,<br><br>Attached please find the enrollment details report.<br><br>Please let me know if there are any questions.<br><br>Best,<br><br>Avetis";


            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);
            client.Send(message);
        }
    }
}
