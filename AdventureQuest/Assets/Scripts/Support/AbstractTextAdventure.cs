using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class AbstractTextAdventure : TextAdventure
{

    private TextAdventureEngine engine;
    private Room room;
    private List<string> inventory = new List<string>();
    private bool IsGameOver = false;
    private bool IsGameWon = false;

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

    public Room GetRoom()
    {
        return room;
    }

    public void SetRoom(Room room)
    {
        this.room = room;
    }

    public virtual void DisplayRoom()
    {
        DisplayRoomName();
        DisplayDescription();
    }


    public virtual void DisplayRoomName()
    {
        string roomName = this.room.GetName(this);
        string end = " |";
        string border = "=-";
        for (int ix = 0; ix < roomName.Length; ix++)
        {
            border += ix % 2 == 0 ? "=" : "-";
        }
        if (roomName.Length % 2 == 1)
        {
            border += "-=";
        }
        else
        {
            border += "=-=";
            end = "  |";
        }
        string middle = "| " + roomName + end;
        this.Print("\n" + border + "\n");
        this.Print(middle + "\n");
        this.Print(border + "\n");
    }

    public virtual void DisplayDescription()
    {
        this.Print("\n" + this.room.GetDescription(this) + "\n");
    }

    public abstract Room OnStart();

    public string GetInput()
    {
        string result = null;
        while (engine.input.IsEmpty )
        {
            Thread.Sleep(100);
        }
        if (!engine.input.TryDequeue(out result))
        {
            return GetInput();
        }
        return result;
    }

    public void Run()
    {
        this.room = this.OnStart();
        while (!IsGameOver && !IsGameWon)
        {
            DisplayRoom();
            this.room.HandleInput(this);
            Sleep(1);
        }
    }

    public void GameOver()
    {
        this.IsGameOver = true;
    }

    public void PrintTextFile(string resourceName, float delay)
    {
        string data = engine.GetTextFile(resourceName);
        string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        foreach(string line in lines)
        {
            Print(line + "\n", 0);
            Sleep(delay);
        }
    }

    public void GameWon()
    {
        this.IsGameWon = true;
    }
}
