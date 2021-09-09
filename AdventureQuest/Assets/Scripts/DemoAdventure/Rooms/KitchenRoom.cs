using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DemoAdventure
{
    public class KitchenRoom : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            //TODO: Create a better description
            return @"You are standing in a kitchen cottage.
There is a [door] here.";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "A Kitchen";
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
                return new CottageRoom();
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