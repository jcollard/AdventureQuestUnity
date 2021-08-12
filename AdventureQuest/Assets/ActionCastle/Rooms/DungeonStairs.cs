using System;
using System.Collections.Generic;

namespace ActionCastle
{
    public class DungeonStairs : Room
    {
       

        public string GetDescription(TextAdventure adventure)
        {
            return "You are climbing the stairs down to the dungeon.It is too dark to see!\n\n Exits are: Up";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Dungeon Stairs";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            List<string> options = new List<string>();
            options.Add("up");
            options.Add("down");
            return options;
        }

        public TextAdventure HandleInput(TextAdventure state, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)state;
            if (userInput.Equals("up"))
            {
                state.SetRoom(actionCastle.CourtYard);
            }

            if (userInput.Equals("down"))
            {
                state.SetRoom(actionCastle.Dungeon);
            }
            return state;
        }
    }
}