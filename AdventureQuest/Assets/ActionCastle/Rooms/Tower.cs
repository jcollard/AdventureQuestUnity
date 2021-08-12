using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class Tower : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return "You are inside the tower. The princess is here.\n\nExits are: Down";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Tower";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("down");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("down"))
            {
                adventure.SetRoom(actionCastle.CourtYard);
            }
            return adventure;
        }
    }
}