using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.CaveOfAdventure
{
    public class Tunnel : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return @"You are in a long winding tunnel. It is pitch black except for the beam emitting
from your flashlight. You notice a [button] on the wall here. In one direction,
the tunnel leads to the [mouth] of the cave. In the other, the [tunnel]
continues.";
        }

        public string GetName(TextAdventure adventure)
        {
            return "A Long Winding Tunnel";
        }

        public TextAdventure HandleInput(TextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            Cave cave = (Cave)adventure;
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
                cave.SetRoom(cave.Gym);
            } else if (input.Equals("tunnel"))
            {
                cave.Print("You continue down the tunnel.\n");
                cave.SetRoom(cave.Snoring);
            } else if (input.Equals("mouth"))
            {
                cave.Print("You return to the mouth of the cave.\n");
                cave.SetRoom(cave.MouthOfCave);
            } else
            {
                adventure.Print("Invalid command!\n");
            }

            return adventure;
        }
    }
}