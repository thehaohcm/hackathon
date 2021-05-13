using englishexamservice.Database;
using englishexamservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
            string appDataPath = Directory.GetCurrentDirectory();
            string dataPath = Path.Combine(appDataPath, "Database");
            string jsonFilePath = Path.Combine(dataPath, "questionbank.json");
            QuestionBank questionBank = DummyDB.getInstanceByJsonPath(jsonFilePath).questionBank;

            if (questionBank != null && questionBank.parts != null)
            {
                List<Part> dummyPart = questionBank.parts;
                //Generate
                Random radom = new Random();
                Topic newTopic = new Topic(topicName);

                //generate from part 1 to part ...
                for (int partNumber = 1; partNumber <= 4; partNumber++)
                {
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
                    string partName = this.getPartName(partNumber);
                    if (originalPartQuestionGroups.Count == desiredQuestionCount&&partName!="")
                    {
                        newTopic.parts.Add(new Part(partNumber, partName, originalPartQuestionGroups));
                    }
                }
                
                if (newTopic != null && newTopic.parts != null)
                {
                    string generatedTopicPath = Path.Combine(appDataPath, "GeneratedTopic");

                    //Compare with olds
                    DirectoryInfo dir = new DirectoryInfo(generatedTopicPath);
                    try
                    {
                        foreach (FileInfo f in dir.GetFiles("*.json"))
                        {
                            try
                            {
                                string comparedTopicText= File.ReadAllText(f.FullName);
                                if (comparedTopicText != "")
                                {
                                    var comparedTopic = JsonConvert.DeserializeObject<Topic>(comparedTopicText);
                                    if (comparedTopic != null && comparedTopic.parts != null)
                                    {
                                        //compare id
                                    }
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Cannot read a file's content, Exception: " + e);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
                    }

                    //persist in json file
                    string newTopicJson =JsonConvert.SerializeObject(newTopic);
                    if (newTopicJson != "")
                    {
                        try
                        {
                            var newTopicJsonFilePath = Path.Combine(generatedTopicPath, "generatedTopic_"+topicName+".json");
                            File.WriteAllText(newTopicJsonFilePath, newTopicJson);
                        }catch(Exception e)
                        {
                            Console.WriteLine("Cannot store new topic " + topicName + " into file, Exception: " + e);
                        }
                    }

                }

                //return
                return newTopic;
            }
            return null;
        }

        private string getPartName(int partNumber)
        {
            string partName="";
            switch (partNumber)
            {
                case 1:
                    partName = "Picture Description";
                    break;
                case 2:
                    partName = "Question - Response";
                    break;
                case 3:
                    partName = "Short Conversation";
                    break;
                case 4:
                    partName = "Short Talks";
                    break;
                case 5:
                    partName = "Incomplete Sentences";
                    break;
                case 6:
                    partName = "Text Completion";
                    break;
                case 7:
                    partName = "Reading  Comprehension";
                    break;
            }
            return partName;
        }
    }
}
