using englishexamservice.Database;
using englishexamservice.Models;
using System;
using System.Collections.Generic;

namespace englishexamservice.Handlers
{
    public class GenerateEnglishTopicHandler
    {

        public GenerateEnglishTopicHandler()
        {
            
        }

        public Topic generateEnglishTopic(string topicName)
        {
            //Connect to database
            List<Part> dummyPart = DummyDB.getInstance().partListDump;

            //Generate
            Random radom = new Random();
            Topic newTopic = new Topic(topicName);

            //generate from part 1 to part ...
            for (int partNumber = 1; partNumber <= 4; partNumber++) {
                int questionCount = 0;
                int desiredQuestionCount = 1;
                int[] compareQuestionIndexs = new int[desiredQuestionCount];

                List<QuestionGroup> originalPartQuestionGroups = dummyPart.Find(x => x.partNumber == partNumber).questionGroups;
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
