using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class QuestionGroup
    {
        public List<QuestionGroupContent> questionGroupContents { get; set; }
        public List<Question> questions { set; get; }

        public QuestionGroup(List<QuestionGroupContent> questionGroupContents, List<Question> questions)
        {
            this.questionGroupContents = questionGroupContents;
            this.questions = questions;
        }
    }
}
