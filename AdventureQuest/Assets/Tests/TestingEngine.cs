using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;

/// <summary>
/// The main engine which handles input and output.
/// </summary>
public class TestingEngine : IEngine
{


    /// <summary>
    /// A Thread safe Queue for handling user input.
    /// </summary>
    private ConcurrentQueue<string> input = new ConcurrentQueue<string>();

    /// <summary>
    /// A dictionary of loaded resources.
    /// </summary>
    private IDictionary<string, string> textAssets = new ConcurrentDictionary<string, string>();


    /// <inheritdoc/>
    public void Print(string message, float delay = 0.01f)
    {
        Debug.Log(message);
    }

    /// <inheritdoc/>
    public void Sleep(float seconds)
    {

    }

    /// <inheritdoc/>
    public string GetTextFile(string resourceName)
    {
        return "In Testing Mode!";
    }

    /// <inheritdoc/>
    public ConcurrentQueue<string> GetInput()
    {
        return input;
    }

    public void AddUserInput(string userInput)
    {
        input.Enqueue(userInput);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        Debug.Log("<CLEAR TRIGGERED>");
    }
}
