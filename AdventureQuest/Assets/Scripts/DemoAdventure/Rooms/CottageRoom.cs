using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DemoAdventure
{
    public class CottageRoom : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            //TODO: Create a better description
            return @"You are standing in a small cottage.
There is a [door] here. There is a bed here that you can [sleep] in.";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "A small Cottage";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            //You will almost always start with these two lines.
            string input = adventure.GetInput().ToLower();
            DemoAdventure da = (DemoAdventure)adventure;

            // Check if the user has entered a valid option
            if (input.Equals("door"))
            {
                
                adventure.Print("You move through the door.\n");
                // This function expects you to return the
                // next room the player should enter.
                return new KitchenRoom();
            }
            else if (input.Equals("sleep"))
            {
                adventure.Print("You lay down and go to sleep.\n");
                // When the player loses, we call the GameOver() method.
                adventure.GameOver();
            }
            else
            {
                //If the user enters an invalid option, we have to let them know
                adventure.Print("Invalid command!");
            }

            // If we don't want the user to change rooms, we can return "this" room
            return this;
        }
    }
}