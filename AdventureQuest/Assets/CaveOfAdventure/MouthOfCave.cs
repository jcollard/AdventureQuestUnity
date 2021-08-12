﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.CaveOfAdventure
{
    public class MouthOfCave : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return @"You are at the mouth of the cave. It is dark and damp. Luckily, you brought your
trusty flashlight with you! You can see two paths here. One leads to the [left]
and the other leads to the [right]. You can also see the [entrance] of the cave.";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Mouth of the Cave";
        }

        public TextAdventure HandleInput(TextAdventure adventure)
        {
            Cave cave = (Cave)adventure;
            string input = adventure.GetInput().ToLower();

            if (input.Equals("right"))
            {
                adventure.Print("You take the path to the right.\n");
                cave.SetRoom(cave.Tunnel);
            } else if (input.Equals("left"))
            {
                adventure.Print("You take the path to the left.\n");
                cave.SetRoom(cave.DeadEnd);
            } else if (input.Equals("entrance"))
            {
                adventure.Print("On second thought, you return to the entrance.\n");
                cave.SetRoom(cave.CaveEntrance);
            } else
            {
                adventure.Print("Invalid Command!\n");
            }

            return adventure;
        }
    }
}