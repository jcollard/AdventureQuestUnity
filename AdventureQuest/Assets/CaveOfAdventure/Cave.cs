using Assets.CaveOfAdventure;
using System.Collections;
using UnityEngine;


    public class Cave : AbstractTextAdventure
    {

    public readonly Room CaveEntrance = new CaveEntrance();
    public readonly Room MouthOfCave = new MouthOfCave();
    public readonly Room Tunnel = new Tunnel();
    public readonly Room DeadEnd = new DeadEnd();
    public readonly Room Gym = new Gym();
    public readonly Room DragonLair = new DragonLair();
    public readonly Room Snoring = new Snoring();

    public int Strength = 0;
    public bool HasKey = false;
    public bool HasSword = false;

    public override Room OnStart()
    {
        Strength = 0;
        HasKey = false;
        HasSword = false;
        PrintTextFile("CaveOfAdventure/title", 0.1F);
        Print("\n                           A text adventure by Joseph Collard");
        Sleep(2);
        Print("\n");
        return CaveEntrance;
    }
}