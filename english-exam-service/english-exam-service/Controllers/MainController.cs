using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Confluent.Kafka;
using englishexamservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnglishExamService.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private ProducerConfig config = new ProducerConfig
        { BootstrapServers = "51.222.85.96:9092" };
        private readonly string emailTopic = "simpletalk_topic";
        private readonly string generateTopic = "generate_english_topic";

        [HttpGet("sendResult")] 
        public bool sendResultByEmail(string name, string email, int score, int correctAnswer, int totalAnswer)
        {
            if( Created(string.Empty, SendMessageToKafka(emailTopic, new EmailMessage(name, email, score, correctAnswer, totalAnswer)))!=null)
            {
                return true;
            }
            return false;
        }

        private Object SendMessageToKafka(string topic, EmailMessage message)
        {
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var messageJson = JsonConvert.SerializeObject(message);
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = messageJson })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Oops, something went wrong: {e}");
                }
            }
            return null;
        }

        [HttpGet("generateTopic")]
        public bool generateEnglishTopic()
        {
            return false;
        }
    }
}
