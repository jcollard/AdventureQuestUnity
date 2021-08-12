using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class ThroneRoom : Room
    {
       
        public string GetDescription(TextAdventure adventure)
        {
            return "This is the throne room of ACTION CASTLE. There is an ornate golden throne here.\n\nExits are: west";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Throne Room";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("west");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("west"))
            {
                adventure.SetRoom(actionCastle.GreatFeastingHall);
            }
            return adventure;
        }
    }
}