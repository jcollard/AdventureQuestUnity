using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class TowerStairs : Room
    {
      

        public string GetDescription(TextAdventure adventure)
        {
            return "You are climbing the stairs to the tower. There is a locked door here.\n\nExits are: Down, In";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Tower Stairs";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("down");
            options.Add("in");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("in"))
            {
                adventure.SetRoom(actionCastle.Tower);
            }
            if (userInput.Equals("down"))
            {
                adventure.SetRoom(actionCastle.CourtYard);
            }
            return adventure;
        }
    }
}