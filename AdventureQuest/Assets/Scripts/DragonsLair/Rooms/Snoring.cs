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
            DragonsLairAdventure cave = (DragonsLairAdventure)adventure;

            if (input.Equals("snoring"))
            {
                cave.Print("You slowly approach the snoring...\n");
                return cave.DragonLair;
            }
            else if (input.Equals("chest") && cave.HasKey)
            {

                if (cave.HasSword == false)
                {
                    cave.Print("The chest is locked.\n");
                    cave.Sleep(1);
                    cave.Print("You take the key from your pocket and unlock the chest.\n");
                    cave.Sleep(1);
                    cave.Print("Inside, you find a beautiful sword!\n");
                    cave.HasSword = true;
                }
                else
                {
                    cave.Print("You search the chest again, but it is empty.\n");
                }

            }
            else if (input.Equals("chest") && !cave.HasKey)
            {
                cave.Print("The chest is locked!\n");
            }
            else if (input.Equals("tunnel"))
            {
                cave.Print("You head back toward the mouth of the cave.\n");
                return cave.Tunnel;
            }
            else
            {
                cave.Print("Invalid command!\n");
            }

            return this;
        }
    }
}