using System;

public class Config
{
    public static ITextAdventure GetAdventure()
    {
        return new DragonsLair.DragonsLairAdventure();
    }
}
