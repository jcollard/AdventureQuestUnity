using System;
using System.Collections.Generic;

namespace ActionCastle
{

    public class FishingPond : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return "You are at the edge of a small fishing pond.\n\nExits are: North";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Fishing Pond";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("north");
            options.Add("fish");
            options.Add("catch fish");
            options.Add("use fishing pole");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("north"))
            {
                actionCastle.SetRoom(actionCastle.GardenPath);
            }

            if (userInput.Equals("fish") || userInput.Equals("catch fish") || userInput.Equals("use fishing pole"))
            {
                if (adventure.GetInventory().Contains("Fishing Pole"))
                {
                    adventure.Print("You take your fishing pole out of your pocket and cast a line into the pond. You wait");
                    adventure.Print("...", 0.5f);
                    adventure.Print(" and finally");
                    adventure.Print("...", 0.5f);
                    adventure.Print(" finally");
                    adventure.Print("...", 0.5f);
                    adventure.Print("You get a snag!\n\n");
                    adventure.Sleep(1.0f);
                    adventure.Print("Your line bends under the weight!\n\n");
                    adventure.Sleep(1.0f);
                    adventure.Print("This fish must be huge!\n\n");
                    adventure.Sleep(1.0f);
                    adventure.Print("You battle with all your might until the fish flies through the air and lands on the ground!\n\n");
                    adventure.Sleep(1.0f);
                    adventure.Print("You pick up the fish and squish it into your pocket.\n\n");
                    adventure.Sleep(1.0f);
                    adventure.Print("Unfortunately, the Fishing Pole was damaged during the altercation.\n\n");
                    adventure.GetInventory().Remove("Fishing Pole");
                    adventure.GetInventory().Add("Broken Fishing Pole");
                    adventure.GetInventory().Add("Fish");
                } else
                {
                    adventure.Print("You don't have any fishing equipment.\n");
                }
            }

            return actionCastle;
        }
    }
}