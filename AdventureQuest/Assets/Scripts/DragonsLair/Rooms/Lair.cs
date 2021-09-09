using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DragonsLair
{
    public class Lair : IRoom
    {
        public string GetDescription(ITextAdventure adventure)
        {
            return @"You are standing inside of a dragon's lair! The air is hot and dank. A tunnel
leads [back] the way you came. In the center of the room is a massive pile of
gold atop which a massive red dragon slumbers. Probably best not to [wake] the
dragon. If you could [slay] it, you would be a hero!";
        }

        public string GetName(ITextAdventure adventure)
        {
            return "The Dragon's Lair";
        }

        public IRoom HandleInput(ITextAdventure adventure)
        {
            string input = adventure.GetInput().ToLower();
            DragonsLairAdventure dla = (DragonsLairAdventure)adventure;
            if (input.Equals("back"))
            {
                dla.Print("You head back the way you came.\n");
                return dla.Snoring;
            }
            else if (input.Equals("wake"))
            {
                dla.Print("You wake the dragon...\n");
                dla.Sleep(1);
                dla.PrintTextFile("CaveOfAdventure/dragon", 0.05F);
                dla.Sleep(1);
                dla.Print(@"The dragon wakes and snarls, 'Who disturbs my slumber!?' It glares at you with
disdain and smiles crookedly before devouring you. The dragon lets out a
satisfying belch before closing its eyes and drifting back to sleep.");
                dla.GameOver();
            }
            else if (input.Equals("slay") && dla.HasSword)
            {
                dla.Print("You draw your sword to slay the dragon.\n");
                dla.Sleep(1);
                dla.Print(@"With your sword in hand, you sneak up to the dragon and drive it into the
beast's heart. The evil dragon winces as it realizes its reign of terror is
over. Congratulations, you are a hero!");
                dla.GameWon();
            }
            else if (input.Equals("slay") && !dla.HasSword)
            {
                dla.Print("You attempt to pummel the dragon with your fists!\n");
                dla.Sleep(1);
                dla.PrintTextFile("CaveOfAdventure/dragon", 0.05F);
                dla.Sleep(1);
                dla.Print(@"The dragon wakes and snarls, 'Who disturbs my slumber!?' It glares at you with
disdain and smiles crookedly before devouring you. The dragon lets out a
satisfying belch before closing its eyes and drifting back to sleep.");
                dla.GameOver();
            }
            else
            {
                dla.Print("Invalid command!\n");
            }

            return this;
        }
    }
}