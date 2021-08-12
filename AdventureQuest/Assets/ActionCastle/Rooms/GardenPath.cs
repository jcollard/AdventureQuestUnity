using System;
using System.Collections.Generic;
namespace ActionCastle
{

    public class GardenPath : Room
    {

        private List<string> options = new List<string>();

        public GardenPath()
        {
            options.Add("north");
            options.Add("south");
            options.Add("in");
            options.Add("rosebush");
            options.Add("rose");
        }

        public string GetDescription(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            string description = "You are standing on a garden path.";
            if (!actionCastle.pickedRose)
            {
                description += " There is a [rosebush] here.";
            } else
            {
                description += " There is an ordinary bush here.";
            }
            description += " There is a cottage here.\n\n";
            description += "Exits are: North, South, In";
            return description;
        }

        public string GetName(TextAdventure adventure)
        {
            return "Garden Path";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("rosebush"))
            {
                if (!actionCastle.pickedRose)
                {
                    adventure.Print("There is a single red [rose] on this bush.\n\n");
                }else
                {
                    adventure.Print("It is an ordinary bush.\n\n");
                }
            }

            if (userInput.Equals("rose"))
            {
                if (!actionCastle.pickedRose)
                {
                    adventure.Print("You bend down and pluck the rose");
                    adventure.Print("...", 0.5f);
                    adventure.Print(" It smells wonderful!\n");
                    adventure.GetInventory().Add("Red Rose");
                    actionCastle.pickedRose = true;
                }
                else
                {
                    adventure.Print("You search for a rose but cannot find one.\n");
                }
            }

            if (userInput.Equals("in"))
            {
                adventure.Print("You enter the cottage.");
                adventure.SetRoom(actionCastle.Cottage);
            }

            if (userInput.Equals("north"))
            {
                adventure.Print("You walk along the path to the north.");
                adventure.SetRoom(actionCastle.WindingPath);
            }

            if (userInput.Equals("south"))
            {
                adventure.Print("You walk along the path to the south.");
                adventure.SetRoom(actionCastle.FishingPond);
            }

            return adventure;
        }
    }
}