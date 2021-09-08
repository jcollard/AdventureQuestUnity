using System;
using System.Collections.Generic;

/// <summary>
/// An ITextAdventure defines a TextAdventure. It is recommended that you extend
/// the <a cref="AbstractTextAdventure">AbstractTextAdventure</a> class to
/// create a new adventure as it provides default implementations for almost all
/// of the methods for this interface.
/// </summary>
public interface ITextAdventure
{

    /// <returns>The name of this TextAdventure</returns>
    string GetName();

    /// <returns>The author of this TextAdventure</returns>
    string GetAuthor();

    /// <returns>The description of this TextAdventure</returns>
    string GetDescription();

    /// <summary>
    /// Prints the specified message to the console one character at a time
    /// using the default delay speed. Note: This does not include a newline
    /// character. If you would like to print a newline character, you must
    /// specify it using '\n'.
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    void Print(string message);

    /// <summary>
    /// Prints the specified message to the console one character at a time
    /// using the specified delay in seconds. Note: This does not include a
    /// newline character. If you would like to print a newline character, you
    /// must specify it using '\n'.
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    /// <param name="delay">The number of seconds to wait between characters
    ///     </param>
    void Print(string message, float delay);

    /// <summary>
    /// Prints the specified text file to the console one line at a time using
    /// the specified delay in seconds. The specified file should be present in
    /// the Resources folder of your project. For example:
    /// <code>
    /// PrintTextFile("CaveOfAdventure/title", 0.1F);
    /// </code>
    /// The above example, looks for the file "title.txt" located in the
    /// "Resources/CaveOfAdventure" directory.
    /// </summary>
    /// <param name="resourceName">The name of the resource to load</param>
    /// <param name="delay">The number of seconds to wait between lines</param>
    void PrintTextFile(string resourceName, float delay);

    /// <summary>
    /// Clears the screen.
    /// </summary>
    void Clear();

    /// <summary>
    /// Pause the game for the specified number of seconds.
    /// </summary>
    /// <param name="seconds">The number of seconds to pause</param>
    void Sleep(float seconds);

    /// <summary>
    /// Reads input from the user and returns it as a string. This method blocks
    /// until input is received.
    /// </summary>
    /// <returns>The next line entered by the user</returns>
    string GetInput();

    /// <returns>The current <a cref="IRoom">IRoom</a> that the player is in.
    ///     </returns>
    IRoom GetRoom();

    /// <summary>
    /// Specifies the <a cref="IEngine">Engine</a> that
    /// should be used to for input and output.
    /// </summary>
    void SetEngine(IEngine engine);

    /// <summary>
    /// Called when the player loses the adventure.
    /// </summary>
    void GameOver();

    /// <summary>
    /// Called when the player wins the adventure.
    /// </summary>
    void GameWon();

    /// <summary>
    /// Called before the adventure starts and specifies the starting room. This
    /// method should initialize all of the <a cref="IRoom">IRoom</a>'s and
    /// variables.
    /// </summary>
    /// <returns>The starting <a cref="IRoom">IRoom</a></returns>
    IRoom OnStart();

    /// <summary>
    /// Runs the Adventure.
    /// </summary>
    void Run();




}
