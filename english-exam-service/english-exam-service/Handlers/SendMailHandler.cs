using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using englishexamservice.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace englishexamservice.Handlers
{
    public class SendMailHandler : IHostedService
    {
        private readonly string topic = "simpletalk_topic";

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Thread thread = new Thread(new ThreadStart(this.ThreadTask));
            thread.IsBackground = true;
            thread.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void ThreadTask()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "51.222.85.96:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var cancelToken = new CancellationTokenSource();

            using (var builder = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                builder.Subscribe(topic);

                try
                {
                    while (true)
                    {
                        try
                        {
                            var consumer = builder.Consume();
                            Console.WriteLine("received a message");
                            Console.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
                            var emailMessage = JsonConvert.DeserializeObject<EmailMessage>(consumer.Message.Value);
                            this.sendEmail(emailMessage);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (Exception)
                {
                    builder.Close();
                }
            }
        }

        private bool sendEmail(EmailMessage emailMessage)
        {
            try
            {
                string from = "email";
                string password = "password";
                //for working, please make sure you did allow accessing to less secure apps when using gmail
                //string cc = "email";
                string content = "Hi " + emailMessage.name + "<br> This is a result of TOEIC English Examination you just finished:<br><br>"
                    + "Name: " + emailMessage.name + "<br>"
                    + "Email: " + emailMessage.email + "<br>"
                    + "Score: " + emailMessage.score + " (" + emailMessage.correctAnswer + "/" + emailMessage.totalAnswer + ")<br><br>"
                    + "Notice: This is an automated email, please do not reply";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential(from, password);
                // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.Subject = "Result of TOEIC English Examination";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = content;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Priority = MailPriority.High;

                //Setting From , To and CC
                mail.From = new MailAddress(from, "TOEIC English Examination");
                mail.To.Add(new MailAddress(emailMessage.email));
                //mail.CC.Add(new MailAddress(cc));

                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Cannot send email, message: " + e.Message);
                return false;
            }
            System.Diagnostics.Debug.WriteLine("The email has been sent");
            return true;
        }
    }
}
