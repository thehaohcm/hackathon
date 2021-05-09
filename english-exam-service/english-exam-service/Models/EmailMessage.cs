using System;
namespace englishexamservice.Models
{
    [Serializable]
    public class EmailMessage
    {
        public string name { set; get; }
        public string email { set; get; }
        public int score { set; get; }
        public int correctAnswer { set; get; }
        public int totalAnswer { set; get; }

        public EmailMessage(string name, string email, int score, int correctAnswer, int totalAnswer)
        {
            this.name = name;
            this.email = email;
            this.score = score;
            this.correctAnswer = correctAnswer;
            this.totalAnswer = totalAnswer;
        }

        public EmailMessage()
        {

        }
    }
}
