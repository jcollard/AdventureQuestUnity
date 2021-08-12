using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class Tunnel : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You are in a long winding tunnel. It is pitch black except for the beam emitting
from your flashlight. You notice a [button] on the wall here. In one direction,
the tunnel leads to the [mouth] of the cave. In the other, the [tunnel]
continues.";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "A Long Winding Tunnel";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;
            if (input.Equals("button"))
            {
                dla.Print("You press the button and wait.");
                dla.Sleep(1);
                dla.Print(".");
                dla.Sleep(1);
                dla.Print(".\n");
                dla.Sleep(1);
                dla.Print("DING! The wall next to the button opens revealing an elevator!\n");
                dla.Print("Entering the elevator, you begin to descend.");
                dla.Sleep(1);
                dla.Print(".");
                dla.Sleep(1);
                dla.Print(".\n");
                dla.Sleep(1);
                dla.Print("The elevator door opens and you exit.\n");
                return dla.Gym;
            }
            else if (input.Equals("tunnel"))
            {
                dla.Print("You continue down the tunnel.\n");
                return dla.Snoring;
            }
            else if (input.Equals("mouth"))
            {
                dla.Print("You return to the mouth of the cave.\n");
                return dla.MouthOfCave;
            }
            else
            {
                adventure.Print("Invalid command!\n");
            }

            return this;
        }
    }
}