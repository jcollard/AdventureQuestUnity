using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class GreatFeastingHall : Room
    {
      
        public string GetDescription(TextAdventure adventure)
        {
            return "You stand inside the Great Feasting Hall. There is a strange candle here.\n\nExits are: East, West";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Great Feasting Hall";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("east");
            options.Add("west");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("east"))
            {
                adventure.SetRoom(actionCastle.ThroneRoom);
            }
            if (userInput.Equals("west"))
            {
                adventure.SetRoom(actionCastle.CourtYard);
            }
            return adventure;
        }
    }
}