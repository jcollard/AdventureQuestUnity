using System;
using System.Collections.Generic;

public abstract class AbstractTextAdventure : TextAdventure
{

    private TextAdventureEngine engine;
    private Room room;
    private List<string> inventory = new List<string>();

    public List<string> GetInventory()
    {
        return inventory;
    }

    public void Print(string message)
    {
        this.Print(message, 0.01f);
    }

    public void Print(string message, float delay)
    {
        if (engine == null)
        {
            return;
        }
        engine.Print(message, delay);
    }

    public void Sleep(float seconds)
    {
        if (engine == null)
        {
            return;
        }
        engine.Sleep(seconds);
    }

    public void SetEngine(TextAdventureEngine engine)
    {
        this.engine = engine;
    }

    public abstract string GetStatus();

    public virtual TextAdventure HandleInput(string input)
    {

        this.Print("\n> " + input + "\n\n");

        if (this.room.GetOptions(this).Contains(input))
        {
            return room.HandleInput(this, input);
        }

        if (input.Equals("look"))
        {
            this.DisplayRoom();
            return this;
        }

        this.Print("I'm sorry, I don't know how to \"" + input + "\"\n");
        return this;
    }

    public Room GetRoom()
    {
        return room;
    }

    public void SetRoom(Room room)
    {
        this.room = room;
    }

    

    public virtual string FormatInventory()
    {
        string inventory = "Inventory:\n\n";
        if (this.inventory.Count == 0)
        {
            inventory += " * Empty";
        }

        foreach (string item in this.GetInventory())
        {
            inventory += " * " + item + "\n";
        }
        return inventory;
    }

    public virtual void DisplayRoom()
    {
        DisplayRoomName();
        DisplayDescription();
    }


    public virtual void DisplayRoomName()
    {
        string end = " |";
        string border = "=-";
        for (int ix = 0; ix < this.room.GetName(this).Length; ix++)
        {
            border += ix % 2 == 0 ? "=" : "-";
        }
        if (this.room.GetName(this).Length % 2 == 1)
        {
            border += "-=";
        }
        else
        {
            border += "=-=";
            end = "  |";
        }
        string middle = "| " + this.room.GetName(this) + end;
        this.Print("\n" + border + "\n");
        this.Print(middle + "\n");
        this.Print(border + "\n");
    }

    public virtual void DisplayDescription()
    {
        this.Print("\n" + this.room.GetDescription(this) + "\n");
    }

    public virtual void OnStart()
    {
       
    }
}
