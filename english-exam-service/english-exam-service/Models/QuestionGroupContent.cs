using englishexamservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionGroupContent
    {
        public QuestionTypeEnum type { set; get; }
        public string source { set; get; }

        public QuestionGroupContent(QuestionTypeEnum type, string source)
        {
            this.type = type;
            this.source = source;
        }
    }
}
