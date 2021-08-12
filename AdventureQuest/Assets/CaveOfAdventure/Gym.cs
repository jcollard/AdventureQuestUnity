using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.CaveOfAdventure
{
    public class Gym : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return @"You are in a gym filled with exercise equipment. A sign on the wall reads, 'Ye
Olde Gym'. It appears all of the equipment is in use except for some [weights].
On the far wall is an [elevator].";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Ye Olde Gym";
        }

        public TextAdventure HandleInput(TextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            Cave cave = (Cave)adventure;
            if (input.Equals("weights") && cave.Strength < 10)
            {
                cave.Print("You pick up the weights and do a rep!\n");
                cave.Strength = cave.Strength + 6;
                cave.Sleep(1);
                cave.Print($"Your strength is now {cave.Strength}\n");
            } else if (input.Equals("weights") && cave.Strength >= 10)
            {
                cave.Print("You're feeling pretty strong already, maybe you could go lift some boulders!\n");
            } else if (input.Equals("elevator"))
            {
                cave.Print("You enter the elevator and begin to ascend.");
                cave.Sleep(1);
                cave.Print(".");
                cave.Sleep(1);
                cave.Print(".\n");
                cave.Sleep(1);
                cave.Print("The door opens and you step out into the cave.\n");
                cave.SetRoom(cave.Tunnel);
            } else
            {
                cave.Print("Invalid command!\n");
            }

            return adventure;
        }
    }
}