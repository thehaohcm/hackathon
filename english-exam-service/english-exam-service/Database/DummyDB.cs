using System.Collections.Generic;
using System;
using englishexamservice.Models;

namespace englishexamservice.Database
{
    public class DummyDB
    {
        public static DummyDB instance;
        public List<Part> partListDump { get; set; }
        private DummyDB()
        {
            List<QuestionOption> options1 = new List<QuestionOption>(){
                new QuestionOption(1),
                new QuestionOption(2),
                new QuestionOption(3),
                new QuestionOption(4)
            };

            List<QuestionContent> questionContents1 = new List<QuestionContent>(){
                new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE, "https://toeic24.vn/upload/img/resized/1619417704.jpg"),
                new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE, "https://toeic24.vn/upload/img/resized/1619418257.PNG"),
                new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE, "https://toeic24.vn/upload/img/resized/1619418420.PNG"),
                new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE, "https://toeic24.vn/upload/img/resized/1619418568.PNG"),

            };

            List<Question> questions1 = new List<Question>() {
                new Question(1, questionContents1, "Select the answer", options1, 1),
                new Question(2, questionContents1, "Select the answer", options1, 2),
                new Question(3, questionContents1, "Select the answer", options1, 3),
                new Question(4, questionContents1, "Select the answer", options1, 4)
            };

            List<QuestionGroupContent> questionGroupContents1 = new List<QuestionGroupContent>(){
                new QuestionGroupContent(Models.Enums.QuestionTypeEnum.AUDIO, "https://toeic24.vn/upload/audio/1619407464/1619417665.mp3")
            };

            List<QuestionGroup> questionGroups1 = new List<QuestionGroup>() {
                new QuestionGroup(questionGroupContents1, questions1)
            };

            partListDump = new List<Part>() {
                new Part(1, "Picture Description", questionGroups1)
            };
        }

        public static DummyDB getInstance()
        {
            if (instance == null)
            {
                instance = new DummyDB();
            }
            return instance;
        }
    }
}
