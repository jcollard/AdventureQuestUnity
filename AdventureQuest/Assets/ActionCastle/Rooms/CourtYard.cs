using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class CourtYard : Room
    {

        public string GetDescription(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            string description = "You are standing in the courtyard of ACTION CASTLE. ";
            string directions = "Exists are: ";
            if (actionCastle.isGuardSleeping) {
                description += "There is a guard here blocking the path east.\n\n";
            } else {
                description += "There is a guard taking a nap here.\n\n";
                directions += "East, ";
            }
            directions += "West, Up, Down";
            return description + directions;
        }

        public string GetName(TextAdventure adventure)
        {
            return "Courtyard";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("west");
            options.Add("east");
            options.Add("up");
            options.Add("down");
            options.Add("branch");
            options.Add("guard");
            options.Add("attack");
            options.Add("talk");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("west"))
            {
                adventure.SetRoom(actionCastle.DrawBridge);
            }
            if (userInput.Equals("east"))
            {
                adventure.SetRoom(actionCastle.GreatFeastingHall);
            }
            if (userInput.Equals("up"))
            {
                adventure.SetRoom(actionCastle.TowerStairs);
            }
            if (userInput.Equals("down"))
            {
                adventure.SetRoom(actionCastle.DungeonStairs);
            }
            return adventure;
        }
    }
}