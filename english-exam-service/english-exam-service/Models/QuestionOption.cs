using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionOption
    {
        long id { set; get; }
        string content { set; get; }

        public QuestionOption(long id, string content)
        {
            this.id = id;
            this.content = content;
        }

        public QuestionOption(long id)
        {
            this.id = id;
        }
    }
}
