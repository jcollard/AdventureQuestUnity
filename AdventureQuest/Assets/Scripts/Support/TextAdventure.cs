using System;
using System.Collections.Generic;

public interface TextAdventure
{
    void Print(string message);
    void Print(string message, float delay);
    void PrintTextFile(string resourceName, float delay);
    string GetInput();
    void Sleep(float seconds);
    List<string> GetInventory();
    void SetRoom(Room room);
    Room GetRoom();
    void SetEngine(TextAdventureEngine engine);
    void DisplayRoom();
    void Run();
    void GameOver();
    void GameWon();
    Room OnStart();
    

}
