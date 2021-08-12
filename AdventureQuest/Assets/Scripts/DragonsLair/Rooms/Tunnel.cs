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
            DragonsLairAdventure cave = (DragonsLairAdventure)adventure;
            if (input.Equals("button"))
            {
                cave.Print("You press the button and wait.");
                cave.Sleep(1);
                cave.Print(".");
                cave.Sleep(1);
                cave.Print(".\n");
                cave.Sleep(1);
                cave.Print("DING! The wall next to the button opens revealing an elevator!\n");
                cave.Print("Entering the elevator, you begin to descend.");
                cave.Sleep(1);
                cave.Print(".");
                cave.Sleep(1);
                cave.Print(".\n");
                cave.Sleep(1);
                cave.Print("The elevator door opens and you exit.\n");
                return cave.Gym;
            } else if (input.Equals("tunnel"))
            {
                cave.Print("You continue down the tunnel.\n");
                return cave.Snoring;
            } else if (input.Equals("mouth"))
            {
                cave.Print("You return to the mouth of the cave.\n");
                return cave.MouthOfCave;
            } else
            {
                adventure.Print("Invalid command!\n");
            }

            return this;
        }
    }
}