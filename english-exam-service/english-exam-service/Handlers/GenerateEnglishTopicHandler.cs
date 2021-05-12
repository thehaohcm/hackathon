using englishexamservice.Models;
using System;
using System.Collections.Generic;

namespace englishexamservice.Handlers
{
    public class GenerateEnglishTopicHandler
    {

        public List<Part> partListDump { get; set; }
        public GenerateEnglishTopicHandler()
        {

            partListDump = new List<Part>();

            List<Question> questions1 = new List<Question>();

            List<QuestionOption> options1 = new List<QuestionOption>();
            options1.Add(new QuestionOption(1));
            options1.Add(new QuestionOption(2));
            options1.Add(new QuestionOption(3));
            options1.Add(new QuestionOption(4));

            List<QuestionContent> questionContents1 = new List<QuestionContent>();
            questionContents1.Add(new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE
                , "https://toeic24.vn/upload/img/resized/1619417704.jpg"));
            questions1.Add(new Question(1, questionContents1, "Select the answer", options1, 1));

            questionContents1.Add(new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE
                , "https://toeic24.vn/upload/img/resized/1619418257.PNG"));
            questions1.Add(new Question(2, questionContents1, "Select the answer", options1, 2));

            questionContents1.Add(new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE
                , "https://toeic24.vn/upload/img/resized/1619418420.PNG"));
            questions1.Add(new Question(3, questionContents1, "Select the answer", options1, 3));

            questionContents1.Add(new QuestionContent(Models.Enums.QuestionTypeEnum.IMAGE
                , "https://toeic24.vn/upload/img/resized/1619418568.PNG"));
            questions1.Add(new Question(4, questionContents1, "Select the answer", options1, 4));

            List<QuestionGroupContent> questionGroupContents1 = new List<QuestionGroupContent>();
            questionGroupContents1.Add(new QuestionGroupContent(Models.Enums.QuestionTypeEnum.AUDIO
                , "https://toeic24.vn/upload/audio/1619407464/1619417665.mp3"));

            List<QuestionGroup> questionGroups1 = new List<QuestionGroup>();
            questionGroups1.Add(new QuestionGroup(questionGroupContents1, questions1));

            Part part1 = new Part(1, "Picture Description", questionGroups1);
            partListDump.Add(part1);
        }

        public Topic generateEnglishTopic()
        {
            //Connect to database

            //Generate
            Random radom = new Random();
            Topic newTopic = new Topic("123");

            //generate part
            for (int partNumber = 1; partNumber <= 4; partNumber++) {
                int questionCount = 0;
                int desiredQuestionCount = 1;
                int[] compareQuestionIndexs = new int[desiredQuestionCount];

                List<QuestionGroup> originalPartQuestionGroups = this.partListDump.Find(x => x.partNumber == partNumber).questionGroups;
                List<QuestionGroup> generatedPartQuestonGroups = new List<QuestionGroup>();
                while (questionCount < desiredQuestionCount)
                {
                    int index = radom.Next(generatedPartQuestonGroups.Count);
                    if (!compareQuestionIndexs.Equals(index))
                    {
                        generatedPartQuestonGroups.Add(originalPartQuestionGroups[index]);
                        questionCount++;
                    }
                }

                //add new part into topic
                if (originalPartQuestionGroups.Count == desiredQuestionCount)
                {
                    string partName = "Picture Description";
                    newTopic.parts.Add(new Part(partNumber, partName, originalPartQuestionGroups));
                }
            }

            //Compare with olds

            //return
            return newTopic;
        }
    }
}
