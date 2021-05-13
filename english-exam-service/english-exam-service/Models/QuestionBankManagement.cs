using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionBankManagement
    {
        public QuestionBank questionBank { get; set; }

        public QuestionBankManagement(string jsonPath)
        {
            try
            {
                string json = File.ReadAllText(jsonPath);
                // this gives me a playerList object
                questionBank = JsonConvert.DeserializeObject<QuestionBank>(json);
            }catch(Exception e)
            {

            }
        }
    }
}
