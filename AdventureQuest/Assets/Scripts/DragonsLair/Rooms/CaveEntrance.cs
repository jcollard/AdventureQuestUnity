using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class CaveEntrance : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You stand before a cave. It is well known that an evil dragon slumbers here.
From time to time, the dragon wakes to terrorize the nearby villages and steal
their gold. Dare you [enter] the cave in search of riches? Or would you rather
[run] home to the comfort of your warm bed?";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "Cave Entrance";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();

            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;

            if (input.Equals("enter"))
            {
                adventure.Print("You enter the cave.\n");
                return dla.MouthOfCave;
            }
            else if (input.Equals("run"))
            {
                adventure.Print("Scared of the dragon, you run home to your bed where fall asleep.\n");
                adventure.GameOver();
            }
            else
            {
                adventure.Print("Invalid command!");
            }
            return this;
        }
    }
}