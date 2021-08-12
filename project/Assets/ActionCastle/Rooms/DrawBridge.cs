using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class DrawBridge : Room
    {
        

        public string GetDescription(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            string directions = "";
            string description = "You are standing on one side of a drawbridge leading to ACTION CASTLE.";
            if (!actionCastle.isTrollFed)
            {
                description += " There is a mean looking troll here.";
                if (actionCastle.GetInventory().Contains("Fish"))
                {
                    description += " The troll's stomach growls loudly, their nostrils flair as they sniff the air, and they begin to drool.";
                }

            } else
            {
                description += " You can hear snoring coming from beneath the bridge.";
                directions += "east, ";
            }

            directions += "west";
            description += "\n\nExits are: " + directions;
            return description;
        }

        public string GetName(TextAdventure adventure)
        {
            return "Draw Bridge";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("east");
            options.Add("west");

            options.Add("feed");
            options.Add("feed fish");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if(userInput.Equals("feed") || userInput.Equals("feed fish"))
            {
                if (actionCastle.isTrollFed)
                {
                    actionCastle.Print("You already fed the troll!\n");
                    return adventure;
                }

                if (actionCastle.GetInventory().Contains("Fish"))
                {
                    actionCastle.Print("You take the fish from your pocket and toss it to the troll.");
                    actionCastle.Print(" The troll catches the fish in their mouth and messily devours it!");
                    actionCastle.Print(" The troll lets out a loud belch before climbing over the side of the bridge.\n\n");
                    actionCastle.GetInventory().Remove("Fish");
                    actionCastle.isTrollFed = true;
                }
                else
                {
                    actionCastle.Print("You don't have anything to feed the troll.\n");
                }
            }

            if (userInput.Equals("west"))
            {
                adventure.SetRoom(actionCastle.WindingPath);
            }

            if (userInput.Equals("east"))
            {
                if (actionCastle.isTrollFed)
                {
                    actionCastle.Print("You approach ACTION CASTLE!\n\n");
                    adventure.SetRoom(actionCastle.CourtYard);
                } else
                {
                    actionCastle.Print("The troll is blocking your way!\n\n");
                }
            }
            return adventure;
        }
    }
}