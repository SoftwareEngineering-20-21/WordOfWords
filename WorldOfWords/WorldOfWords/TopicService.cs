using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldOfWords
{
    class TopicService
    {
        public List<Topic> GetAllTopics()
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                return db.Topic.ToList();
            }
        }
    }
}
