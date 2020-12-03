using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WorldOfWords
{
    class UserCardService
    {
        public bool cardIsShown(int userId, int cardId)
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                var us = (from a in db.UserCard
                           where a.UserId == userId && a.CardId == cardId && a.Answer == true
                           select a).Any();
                if (us)
                {
                    return true;
                }
                return false;

            }

        }
        public void addAnswer(int userId, int cardId, bool answer)
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                UserCard userCard = new UserCard() { UserId = userId, CardId = cardId, Answer = answer, AnswerDate = DateTime.Now };
                db.UserCard.Add(userCard);
                db.SaveChanges();
            }
        }
        public int getCountRightAnswers(List<Card> cards, int userId)
        {
            int cnt = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (this.cardIsShown(userId, cards[i].Id))
                {
                    ++cnt;
                }
            }
            return cnt;
        }

        public int getNext(List<Card> cards, int userId, int current)
        {
            current = (current + 1) % cards.Count;
            while(this.cardIsShown(userId, cards[current].Id))
            {
                current = (current + 1) % cards.Count;
            }
            return current;
        }
    }
}
