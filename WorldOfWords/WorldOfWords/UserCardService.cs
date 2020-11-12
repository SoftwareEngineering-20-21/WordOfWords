using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WorldOfWords
{
    class UserCardService
    {
        private bool cardIsShown(int userId, int cardId)
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                bool us = (from a in db.UserCard
                           where a.UserId == userId && a.CardId == cardId
                           select a).Any();
                if (us)
                {
                    return true;
                }
                return false;

            }

        }
    }
}
