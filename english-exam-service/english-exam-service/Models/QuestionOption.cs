using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionOption
    {
        public long id { set; get; }
        public string content { set; get; }

        public QuestionOption(long id, string content)
        {
            this.id = id;
            this.content = content;
        }
    }
}
