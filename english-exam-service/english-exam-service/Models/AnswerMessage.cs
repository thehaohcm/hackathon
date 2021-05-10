using System;
using System.Collections.Generic;

namespace englishexamservice.Models
{
    public enum AnswerOptionEnum
    {
        A=1, B=2, C=3, D=4
    }
    public class Answer
    {
        public int id { get; set; }
        public AnswerOptionEnum answerOptionEnum { get; set; }

        public Answer(int id, AnswerOptionEnum answer)
        {
            this.id = id;
            this.answerOptionEnum = answer;
        }
    }
    public class AnswerMessage
    {
        
        public string email { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Answer[] answers { get; set; }

        public AnswerMessage(int questionNum, string email, string name, string code)
        {
            this.answers = new Answer[questionNum];
            this.email = email;
            this.name = name;
            this.code = code;
        }

        public void addAnswer(int id, AnswerOptionEnum option)
        {
            
        }
    }
}
