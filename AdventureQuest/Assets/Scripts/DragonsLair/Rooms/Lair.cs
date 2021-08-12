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
            DragonsLairAdventure cave = (DragonsLairAdventure)adventure;
            if (input.Equals("back"))
            {
                cave.Print("You head back the way you came.\n");
                return cave.Snoring;
            }
            else if (input.Equals("wake"))
            {
                cave.Print("You wake the dragon...\n");
                cave.Sleep(1);
                cave.Print(@"The dragon wakes and snarls, 'Who disturbs my slumber!?' It glares at you with
disdain and smiles crookedly before devouring you. The dragon lets out a
satisfying belch before closing its eyes and drifting back to sleep.");
                cave.GameOver();
            }
            else if (input.Equals("slay") && cave.HasSword)
            {
                cave.Print("You draw your sword to slay the dragon.\n");
                cave.Sleep(1);
                cave.Print(@"With your sword in hand, you sneak up to the dragon and drive it into the
beast's heart. The evil dragon winces as it realizes its reign of terror is
over. Congratulations, you are a hero!");
                cave.GameWon();
            }
            else if (input.Equals("slay") && !cave.HasSword)
            {
                cave.Print("You attempt to pummel the dragon with your fists!\n");
                cave.Sleep(1);
                cave.Print(@"The dragon wakes and snarls, 'Who disturbs my slumber!?' It glares at you with
disdain and smiles crookedly before devouring you. The dragon lets out a
satisfying belch before closing its eyes and drifting back to sleep.");
                cave.GameOver();
            }
            else
            {
                cave.Print("Invalid command!\n");
            }

            return this;
        }
    }
}