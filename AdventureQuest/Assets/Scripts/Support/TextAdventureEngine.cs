using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading;

/// <summary>
/// The main engine which handles input and output.
/// </summary>
public class TextAdventureEngine : MonoBehaviour, IEngine
{

    /// <summary>
    /// The input field the user types into
    /// </summary>
    public InputField userInput;

    /// <summary>
    /// The view port which shows text
    /// </summary>
    public ScrollRect textDisplay;

    /// <summary>
    /// The text that is displayed
    /// </summary>
    public Text textDisplayText;

    /// <summary>
    /// The current adventure.
    /// </summary>
    private ITextAdventure adventure;

    /// <summary>
    /// A Queue of elements to be printed to the screen.
    /// </summary>
    private Queue<Renderer> toPrint = new Queue<Renderer>();

    /// <summary>
    /// The time at which the next character will be rendered
    /// </summary>
    private float nextRender = 0;

    /// <summary>
    /// A Thread safe Queue for handling user input.
    /// </summary>
    private ConcurrentQueue<string> input = new ConcurrentQueue<string>();

    /// <summary>
    /// A dictionary of loaded resources.
    /// </summary>
    private IDictionary<string, string> textAssets = new ConcurrentDictionary<string, string>();

    /// <summary>
    /// A Thread safe queue used to load resources.
    /// </summary>
    private ConcurrentQueue<string> assetQueue = new ConcurrentQueue<string>();

    // Initialize the GameEngine
    void Start()
    {
        // Clear the text area
        this.textDisplayText.text = "";

        // Load the adventure
        this.adventure = Config.GetAdventure();
        this.adventure.SetEngine(this);

        // Register how user input is handled
        InputField.SubmitEvent se = new InputField.SubmitEvent();
        se.AddListener(HandleUserInput);
        this.userInput.onEndEdit = se;
        this.userInput.Select();
        this.userInput.ActivateInputField();

        // Start the Adventure
        Thread t = new Thread(new ThreadStart(this.adventure.Run));
        t.Start();
    }

    private void HandleUserInput(string message)
    {
        // When a message comes in, clear out the user input box
        this.userInput.text = "";
        this.userInput.Select();
        this.userInput.ActivateInputField();

        // Add the message to the input queue so it can be handled by the next call to GetInput
        this.input.Enqueue(message);

        // If the user just pressed enter, don't display their output
        if (message.Trim().Equals(""))
        {
            return;
        }

        // Echo the users input to the console.
        this.adventure.Print("\n\n> " + message + "\n\n");

    }

    private void Update()
    {
        // Keep the Next Render counter up to date
        if (Time.time > this.nextRender)
        {
            this.nextRender = Time.time;
        }

        // If there is work to be done, check to see if we should print the
        // next character. Print all of the characters that should be printed
        while (toPrint.Count > 0 && toPrint.Peek().renderAt < Time.time)
        {
            toPrint.Dequeue().Render(this);
        }

        //Scroll to the bottom of the view
        textDisplay.verticalNormalizedPosition = 0;

        //If the assetQueue is not empty, try to load the asset
        if (!assetQueue.IsEmpty)
        {
            string key = null;
            assetQueue.TryDequeue(out key);
            if (key != null)
            {
                TextAsset text = (TextAsset)Resources.Load(key);
                string result = text == null ? $"COULD NOT READ: {key}" : text.text;
                textAssets.Add(key, result);
            }
        }

    }

    /// <inheritdoc/>
    public void Print(string message, float delay = 0.01f)
    {
        foreach (char c in message)
        {
            toPrint.Enqueue(new Renderer("" + c, this, delay));
        }
    }

    /// <inheritdoc/>
    public void Sleep(float seconds)
    {
        toPrint.Enqueue(new Renderer("", this, seconds));
    }

    /// <inheritdoc/>
    public string GetTextFile(string resourceName)
    {
        // If the key has not been loaded, enqueue it to be loaded
        if (!textAssets.ContainsKey(resourceName))
        {
            assetQueue.Enqueue(resourceName);
        }

        // Wait until the key is loaded
        while (!textAssets.ContainsKey(resourceName))
        {
            Thread.Sleep(100);
        }

        return textAssets[resourceName];
    }

    /// <inheritdoc/>
    public ConcurrentQueue<string> GetInput()
    {
        return input;
    }

    /// <summary>
    /// A Helper class for rendering text to the screen one character at a time.
    /// </summary>
    private class Renderer
    {
        /// <summary>
        /// The string to be rendered
        /// </summary>
        private string c;

        /// <summary>
        /// The time at which the string should be rendered
        /// </summary>
        public float renderAt;

        public Renderer(string c, TextAdventureEngine engine, float delay = 0.005f)
        {
            this.c = c;
            this.renderAt = engine.nextRender + delay;
            engine.nextRender += delay;
        }

        public void Render(TextAdventureEngine engine)
        {
            engine.textDisplayText.text += c;
        }
    }

}
