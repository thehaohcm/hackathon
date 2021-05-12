using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class Topic
    {
        public string code { get; set; }
        public int questionSize { get; set; }
        public List<Part> parts { get; set; }

        public Topic(string code, int questionSize, List<Part> parts)
        {
            this.code = code;
            this.questionSize = questionSize;
            this.parts = parts;
        }

        public Topic(string code)
        {
            this.code = code;
        }
    }   
}
