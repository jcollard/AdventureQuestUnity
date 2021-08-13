using System.Collections;
using System.Collections.Generic;
using DragonsLair;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestDragonsLair
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestGetKey()
    {
        // Use the Assert class to test conditions
        DragonsLairAdventure dla = new DragonsLairAdventure();
        TestingEngine engine = new TestingEngine();
        dla.SetEngine(engine);

        // Game Starts Without Key
        Assert.IsFalse(dla.HasKey);

        DeadEnd deadEnd = new DeadEnd();

        // The player strength should start less than 10
        Assert.Less(dla.Strength, 10);

        // The player should not have the key if they don't have the strenght to lift the boulder
        engine.AddUserInput("boulder");
        deadEnd.HandleInput(dla);
        Assert.IsFalse(dla.HasKey);

        // Set the player Strength to 10 and try to lift the boulder
        dla.Strength = 12;
        engine.AddUserInput("boulder");
        deadEnd.HandleInput(dla);
        // The player should now have the key
        Assert.IsTrue(dla.HasKey);
        
    }

}
