using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

/// <summary>
/// A Room represents a location within a <c>TextAdventure</c>.
/// </summary>
public interface IEngine
{

    /// <returns>The User Input Queue</returns>
    public ConcurrentQueue<string> GetInput();

    /// <summary>
    /// Loads a TextFile from the given resource name
    /// </summary>
    /// <param name="resourceName">The resource name to load</param>
    /// <returns>The resulting text</returns>
    public string GetTextFile(string resourceName);

    /// <summary>
    /// Enqueue's a pause in the screens output for the specified number of
    /// seconds.
    /// </summary>
    /// <param name="seconds">The number of seconds to wait before rendering the
    ///     next character</param>
    public void Sleep(float seconds);

    /// <summary>
    /// Enqueue's a message to be printed to the screen one character at a time
    /// specifying the delay between characters.
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    /// <param name="delay">The number of seconds to wait to display each
    ///     character</param>
    public void Print(string message, float delay = 0.01f);

    /// <summary>
    /// Enqueue's a message to clear the on screen terminal.
    /// </summary>
    public void Clear();

    /// <summary>
    /// List all of the adventures registered in the Config file.
    /// </summary>
    public void ListAdventures();
}
