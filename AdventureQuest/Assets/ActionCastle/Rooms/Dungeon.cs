using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class Dungeon : Room
    {
      
        public string GetDescription(TextAdventure adventure )
        {
            return "You are in the dungeon. There is a spooky ghost here.\n\nExits are: Up";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Dungeon";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("up");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("up"))
            {
                adventure.SetRoom(actionCastle.CourtYard);
            }
            return adventure;
        }
    }
}