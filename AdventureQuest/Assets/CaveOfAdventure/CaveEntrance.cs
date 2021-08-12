using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.CaveOfAdventure
{
    public class CaveEntrance : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            return @"You stand before a cave. It is well known that an evil dragon slumbers here.
From time to time, the dragon wakes to terrorize the nearby villages and steal
their gold. Dare you [enter] the cave in search of riches? Or would you rather
[run] home to the comfort of your warm bed?";
        }

        public string GetName(TextAdventure adventure)
        {
            return "Cave Entrance";
        }

        public TextAdventure HandleInput(TextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();

            if (input.Equals("enter"))
            {
                adventure.Print("You enter the cave.\n");
                Cave _adventure = (Cave)adventure;
                adventure.SetRoom(_adventure.MouthOfCave);
            } else if (input.Equals("run"))
            {
                adventure.Print("Scared of the dragon, you run home to your bed where fall asleep.\n");
                adventure.GameOver();
            } else
            {
                adventure.Print("Invalid command!");
            }

            return adventure;
        }
    }
}