using System;
using System.Collections.Generic;

public interface TextAdventure
{
    void Print(string message);
    void Print(string message, float delay);
    void Sleep(float seconds);
    List<string> GetInventory();
    void SetRoom(Room room);
    Room GetRoom();
    string GetStatus();
    void SetEngine(TextAdventureEngine engine);
    TextAdventure HandleInput(string input);
    void DisplayRoom();
    string FormatInventory();
    void OnStart();

}
