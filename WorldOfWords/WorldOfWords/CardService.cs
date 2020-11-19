using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldOfWords
{
    class CardService
    {
        public List<Card> GetCardsByTopic(int topic_id)
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                List<Card> records;
                try
                {
                    records = db.Card.Where(card => card.TopicId == topic_id).ToList();
                }
                catch (Exception e)
                {
                    records = new List<Card>();
                }
                return records;
            }
        }
    }
}
