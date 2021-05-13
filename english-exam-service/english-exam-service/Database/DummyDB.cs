using System.Collections.Generic;
using System;
using englishexamservice.Models;
using Newtonsoft.Json;
using System.IO;

namespace englishexamservice.Database
{
    public class DummyDB
    {
        public static DummyDB instance;
        public QuestionBank questionBank { get; set; }
        private DummyDB(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                questionBank= JsonConvert.DeserializeObject<QuestionBank>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public static DummyDB getInstanceByJsonPath(string jsonFilePath)
        {
            if (instance == null)
            {
                instance = new DummyDB(jsonFilePath);
                if (instance.questionBank == null)
                {
                    instance = null;
                }
            }
            return instance;
        }
    }
}
