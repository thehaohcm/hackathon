using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class Question
    {
        public long id { set; get; }
        public List<QuestionContent> questionContents { set; get; }
        public string question { get; set; }
        public List<QuestionOption> options { get; set; }
        int answer;

        public Question(long id, List<QuestionContent> questionContents, string question, List<QuestionOption> options, int answer)
        {
            this.id = id;
            this.questionContents = questionContents;
            this.question = question;
            this.options = options;
            this.answer = answer;
        }
    }
}
