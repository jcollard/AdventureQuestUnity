using System;
using System.Collections.Generic;

/**
 * A Room represents a location within an adventure.
 */
public interface Room
{

    /**
     * Returns the name of this room. This is displayed at the top
     * of the screen when the player is in this Room and must not be null.
     */
    string GetName(TextAdventure adventure);

    /**
     * Given a GameState, returns a description of this room. This is drawn to 
     * the screen when
     * the player first enters the room. This must not be null.
     */
    string GetDescription(TextAdventure adventure);

    /**
     * Returns a list of options that the user is allowed to type while in
     * this room. If the user types anything not in this list, an invalid 
     * message
     * will be displayed. 
     * 
     * The returned list must not be null and must not be empty.
     */
    List<string> GetOptions(TextAdventure adventure);

    /**
     * Given a GameState and userInput, returns the next GameState.
     */
    TextAdventure HandleInput(TextAdventure adventure, string userInput);

}
