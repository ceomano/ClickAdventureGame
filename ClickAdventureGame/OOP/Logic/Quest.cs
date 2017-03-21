using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Logic
{
    public class Quest : ClickAdventureBase
    {            
        public string questGiver;
        public string questText;
        public string questName;
        public int questId;
        public static List<Quest> quests = new List<Quest>();

        public Quest()
        {
            //questGiver = this.questGiver;
            //questText = this.questText;
            //quests = this.quests;
        }
        public Quest(int id, string qn, string qg, string qt)
        {
            this.questId = id;
            this.questName = qn;
            this.questGiver = qg;
            this.questText = qt;            
        }


        public void InitQuests()
        {
            quests.Add(new Quest(1, "Ugly Ogre, KILL!", "Bengt", "Kill the ogre named Berit!"));
            quests.Add(new Quest(2, "Evil necromancer", "Bengt", "The ogre named Berit has ressurected!! Kill the necromancer named Kalle!"));
            quests.Add(new Quest(3, "Bengt needs stuff.", "Bengt", "Collect tusen grejer. HF lol."));
            quests.Add(new Quest(4, "Bengt needs whisky!", "Bengt", "I need some whisky. Get me some."));
        }

        //public static void adventureQuests(List<string> quests)
        public static void adventureQuests()
        {
            /*
            quests.Add("Quest 1");
            quests.Add("Quest 2");
            quests.Add("Quest 3");
            quests.Add("Quest 4");
            quests.Add("Quest 5");
            */
            // test to see the list print out on label, not in use.
            if (quests != null)
            {
                for (int i = 0; i < quests.Count; i++)
                {
                    Console.WriteLine("    " + quests[i].questName);
                }
            }
           
           
        }
        
        
    }
}
