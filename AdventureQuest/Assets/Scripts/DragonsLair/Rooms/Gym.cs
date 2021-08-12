using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class Gym : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You are in a gym filled with exercise equipment. A sign on the wall reads, 'Ye
Olde Gym'. It appears all of the equipment is in use except for some [weights].
On the far wall is an [elevator].";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "Ye Olde Gym";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;
            if (input.Equals("weights") && dla.Strength < 10)
            {
                dla.Print("You pick up the weights and do a rep!\n");
                dla.Strength = dla.Strength + 6;
                dla.Sleep(1);
                dla.Print($"Your strength is now {dla.Strength}\n");
            }
            else if (input.Equals("weights") && dla.Strength >= 10)
            {
                dla.Print("You're feeling pretty strong already, maybe you could go lift some boulders!\n");
            }
            else if (input.Equals("elevator"))
            {
                dla.Print("You enter the elevator and begin to ascend.");
                dla.Sleep(1);
                dla.Print(".");
                dla.Sleep(1);
                dla.Print(".\n");
                dla.Sleep(1);
                dla.Print("The door opens and you step out into the cave.\n");
                return dla.Tunnel;
            }
            else
            {
                dla.Print("Invalid command!\n");
            }

            return this;
        }
    }
}