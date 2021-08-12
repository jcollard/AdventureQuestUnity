using System;
using System.Collections.Generic;

namespace ActionCastle
{

    public class WindingPath : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return "You are walking along a winding path. " +
                "There is a tall tree here.\n\nExits are: South, East, Up\n\n";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Winding Path";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("south");
            options.Add("east");
            options.Add("up");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("south"))
            {
                adventure.Print("You walk along the path toward your cottage.\n");
                adventure.SetRoom(actionCastle.GardenPath);
            }

            if (userInput.Equals("east"))
            {
                adventure.Print("You follow the path as it curves to the east.\n");
                adventure.SetRoom(actionCastle.DrawBridge);
            }

            if (userInput.Equals("up"))
            {
                adventure.Print("You roll up your sleeves and climb the tree.\n");
                adventure.SetRoom(actionCastle.TopOfTallTree);
            }

            return adventure;
        }
    }
}