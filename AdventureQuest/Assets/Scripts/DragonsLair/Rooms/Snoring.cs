using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class Snoring : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You are in a large natural room within a cave. It is unnaturally warm here and
you can hear what sounds like a giant creature [snoring] around a corner. In the
center of the room is a [chest]. A [tunnel] leads back toward the mouth of the
cave.";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "A Large Natural Cave";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;

            if (input.Equals("snoring"))
            {
                dla.Print("You slowly approach the snoring...\n");
                return dla.DragonLair;
            }
            else if (input.Equals("chest") && dla.HasKey)
            {
                
                if (dla.HasSword == false)
                {
                    dla.Print("The chest is locked.\n");
                    dla.Sleep(1);
                    dla.Print("You take the key from your pocket and unlock the chest.\n");
                    dla.Sleep(1);
                    dla.PrintTextFile("CaveOfAdventure/treasure", 0.05F);
                    dla.Sleep(1);
                    dla.Print("Inside, you find a beautiful sword!\n");
                    dla.HasSword = true;
                }
                else
                {
                    dla.Print("You search the chest again, but it is empty.\n");
                }

            }
            else if (input.Equals("chest") && !dla.HasKey)
            {
                dla.Print("The chest is locked!\n");
            }
            else if (input.Equals("tunnel"))
            {
                dla.Print("You head back toward the mouth of the cave.\n");
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