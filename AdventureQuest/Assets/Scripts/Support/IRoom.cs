using System;
using System.Collections.Generic;

/// <summary>
/// A Room represents a location within a <c>TextAdventure</c>.
/// </summary>
public interface IRoom
{

    /// <summary>
    /// Returns the name of this <c>Room</c>. This method accepts a
    /// <c>TextAdventure</c> as a parameter which can be used to change the name
    /// depending on the state of the game. of the screen when the player enters
    /// the <c>Room</c>. The return value must not be null.
    /// </summary>
    /// <param name="adventure">The <c>TextAdventure</c> that is being played.
    ///     </param>
    /// <returns>The name of this room</returns>
    string GetName(ITextAdventure adventure);

    /// <summary>
    /// Given a <c>TextAdventure</c>, returns a description of this room. This
    /// method accepts a <c>TextAdventure</c> as a parameter which can be used
    /// to change the description depending on the state of the game. This is
    /// drawn to the screen when the player first enters the room. This must not
    /// be null.
    /// </summary>
    /// <param name="adventure">The <c>TextAdventure</c> that is being played.
    ///     </param>
    /// <returns>The description of this Room</returns>
    string GetDescription(ITextAdventure adventure);

    /// <summary>
    /// This method is used to handle user input and interaction within a Room.
    /// It accepts a <c>TextAdventure</c> as an argument which can be used to
    /// manage the state of the adventure.
    /// </summary>
    /// <param name="adventure">The <c>TextAdventure</c> containing the state of
    ///     the adventure</param>
    /// <return>The room the player should be in next</return>
    
    IRoom HandleInput(ITextAdventure adventure);

}
