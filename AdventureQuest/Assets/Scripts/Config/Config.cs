using System;
using System.Collections.Generic;

public class Config
{
    public static ITextAdventure GetAdventure()
    {
        return new DragonsLair.DragonsLairAdventure();
    }

    public static List<ITextAdventure> GetAdventures()
    {
        List<ITextAdventure> adventures = new List<ITextAdventure>();

        adventures.Add(new DragonsLair.DragonsLairAdventure());
        //TODO: Add your adventure here!
        adventures.Add(new DemoAdventure.DemoAdventure());

        return adventures;
    }
}
