using englishexamservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionContent : QuestionGroupContent
    {
        public QuestionContent(QuestionTypeEnum type, string source):base(type,source)
        {
            
        }
    }
}
