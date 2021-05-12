using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace englishexamservice.Models
{
    public class Part
    {
        public int partNumber { set; get; }
        public string partName { set; get; }
        public List<QuestionGroup> questionGroups { set; get; }

        public Part(int partNumber, string partName, List<QuestionGroup> questionGroups)
        {
            this.partNumber = partNumber;
            this.partName = partName;
            this.questionGroups = questionGroups;
        }
    }
}
