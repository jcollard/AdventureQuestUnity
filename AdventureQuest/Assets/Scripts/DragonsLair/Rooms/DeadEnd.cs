using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class DeadEnd : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You are at a dead end. There is a large [boulder] here. A path leads [back] to
the mouth of the cave.";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "A Dead End";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;
            if (input.Equals("boulder") && dla.Strength < 10)
            {
                dla.Print("You try to lift the boulder but you're too weak!\n");
            }
            else if (input.Equals("boulder") && dla.Strength >= 10)
            {
                dla.Print("You lift the boulder with ease!\n");
                if (dla.HasKey)
                {
                    dla.Print("Now you're just showing off.\n");
                }
                else
                {
                    dla.Print("Beneath the boulder, you find a key.\n");
                    dla.Print("You take the key and place it in your pocket!\n");
                    dla.HasKey = true;
                }

            }
            else if (input.Equals("back"))
            {
                dla.Print("You return to the Mouth of the Cave\n");
                return dla.MouthOfCave;
            }
            else
            {
                dla.Print("Invalid command!\n");
            }

            return this;
        }
    }
}