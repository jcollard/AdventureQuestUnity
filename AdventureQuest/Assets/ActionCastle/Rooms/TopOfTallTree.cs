using System;
using System.Collections.Generic;

namespace ActionCastle
{

    public class TopOfTallTree : Room
    {
        public string GetDescription(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            string description = "You are at the top of the tall tree. ";
            if (!actionCastle.branchBroken)
            {
                description += "There is a stout, dead [branch] here.\n\n";
            }
            else
            {
                description += "A sharp protruding [limb] where a branch used to be can be seen. It looks dangerous.\n\n"; ;
            }
            description += "Exits are: down\n\n";
            return description;
        }

        public string GetName(TextAdventure adventure)
        {
            return "Top of Tall Tree";
        }

        public List<string> GetOptions(TextAdventure adventure)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            List<string> options = new List<string>();
            options.Add("down");
            options.Add("branch");
            if ( actionCastle.branchBroken)
            {
                options.Add("limb");
            }
            return options;
        }

        public TextAdventure HandleInput(TextAdventure adventure, string userInput)
        {
            ActionCastle actionCastle = (ActionCastle)adventure;
            if (userInput.Equals("down"))
            {
                adventure.SetRoom(actionCastle.WindingPath);
            }
            if (userInput.Equals("branch"))
            {
                if (actionCastle.branchBroken)
                {
                    actionCastle.Print("Try as you might, you're not strong enough to break off another branch.\n\n");
                } else
                {
                    actionCastle.Print("You pull on the stout dead branch");
                    actionCastle.Print("...", 0.5f);
                    actionCastle.Print(" *KRAK* ");
                    actionCastle.Sleep(1.0f);
                    actionCastle.Print("As the the branch snaps, you lose your balance and fall out of the tree!\n\n");
                    actionCastle.Sleep(3.0f);
                    for(int x = 0; x < 6; x++)
                    {
                        actionCastle.Print("    |   |   |   |   |   |   |   |   |   |\n", 0.0f);
                        actionCastle.Sleep(0.08f);
                        actionCastle.Print("  |   |   |   |   |   |   |   |   |   |   |\n", 0.0f);
                        actionCastle.Sleep(0.08f);
                    }
                    actionCastle.Sleep(1.0f);
                    actionCastle.Print(@"

                                       ,---. 
,--------.,--.  ,--.,--. ,--.,------.  |   | 
'--.  .--'|  '--'  ||  | |  ||  .-.  \ |  .' 
   |  |   |  .--.  ||  | |  ||  |  \  :|  |  
   |  |   |  |  |  |'  '-'  '|  '--'  /`--'  
   `--'   `--'  `--' `-----' `-------' .--.  
                                       '--'  

", 0.001f);
                    actionCastle.Sleep(1.0f);
                    actionCastle.Print("That hurt! You've taken 1 damage.\n\n");
                    actionCastle.hp -= 1;
                    
                    actionCastle.SetRoom(actionCastle.WindingPath);
                    actionCastle.Print("You stand up, dust yourself off, pick up the branch and stuff it in your pocket.\n");
                    actionCastle.GetInventory().Add("Branch");
                    actionCastle.branchBroken = true;
                }
            }

            if (userInput.Equals("limb"))
            {
                actionCastle.Print("You reach out and grab the dangrous limb");
                actionCastle.Print("...", 0.5f);
                actionCastle.Print(" YEOUCH! That hurt. You take 1 damage.");
                actionCastle.hp -= 1;
            }
            return adventure;
        }
    }
}