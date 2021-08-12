using System;
using System.Collections.Generic;

namespace ActionCastle
{

    public class Cottage : Room
    {

        public string GetDescription(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            string description = "You are standing in a small cottage.";
            if (!actionCastle.tookFishingPole)
            {
                description += " There is a [fishing pole] here.";
            }
            else
            {
                description += " There is a spot where a fishing pole used to be.";
            }
            description += "\n\nExits are: Out";
            return description;
        }

        public string GetName(TextAdventure adventure)
        {
            return "Cottage";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("out");
            options.Add("fishing pole");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            userInput = userInput.ToLower();
            if (userInput.Equals("fishing pole"))
            {
                if (!actionCastle.tookFishingPole)
                {
                    adventure.Print("You take the fishing pole and jam it into your pocket!\n\n");
                    adventure.GetInventory().Add("Fishing Pole");
                    actionCastle.tookFishingPole = true;
                }
                else
                {
                    adventure.Print("You try to take the fishing pole but there is nothing here.\n\n");
                }
            }

            if (userInput.Equals("out"))
            {
                adventure.Print("You walk out of the cottage.");
                adventure.SetRoom(actionCastle.GardenPath);
            }
            return adventure;
        }
    }

}