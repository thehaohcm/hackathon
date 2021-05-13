using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Confluent.Kafka;
using englishexamservice.Handlers;
using englishexamservice.Models;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
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
        public bool sendResultByEmail([FromBody] EmailMessage emailMessage)
        {
            //if( emailMessage!=null && Created(string.Empty, SendMessageToKafka(emailTopic, emailMessage))!=null)
            //{
            //    return true;
            //}
            return false;
        }

        private Object SendMessageToKafka(string topic, EmailMessage message)
        {
            //using (var producer = new ProducerBuilder<Null, string>(config).Build())
            //{
            //    try
            //    {
            //        var messageJson = JsonConvert.SerializeObject(message);
            //        return producer.ProduceAsync(topic, new Message<Null, string> { Value = messageJson })
            //            .GetAwaiter()
            //            .GetResult();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"Oops, something went wrong: {e}");
            //    }
            //}
            //return null;


            Message msg = new Message(JsonConvert.SerializeObject(message));
            Uri uri = new Uri("51.222.85.96:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var client = new Producer(router);
            client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
            Console.ReadLine();
            return null;
        }

        [HttpGet("generateTopic")]
        public englishexamservice.Models.Topic generateEnglishTopic()
        {
            return new GenerateEnglishTopicHandler().generateEnglishTopic("123");
        }
    }
}
