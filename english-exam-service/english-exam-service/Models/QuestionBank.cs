using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionBank
    {
        public List<Part> parts { get; set; }

        public QuestionBank(List<Part> parts)
        {
            this.parts = parts;
        }
    }
}
