using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading;

public class TextAdventureEngine : MonoBehaviour
{

    public InputField userInput;
    public ScrollRect textDisplay;
    public Text textDisplayText;
    public ITextAdventure adventure;

    private Queue<Renderer> toPrint = new Queue<Renderer>();
    private float nextRender = 0;
    private List<string> inventory = new List<string>();

    // Use this for initialization
    void Start()
    {

        this.textDisplayText.text = "";
        this.adventure = Config.GetAdventure();
        this.adventure.SetEngine(this);

        InputField.SubmitEvent se = new InputField.SubmitEvent();
        se.AddListener(HandleUserInput);
        this.userInput.onEndEdit = se;

        this.userInput.Select();
        this.userInput.ActivateInputField();
        Thread t = new Thread(new ThreadStart(this.adventure.Run));
        t.Start();
    }

    public ConcurrentQueue<string> input = new ConcurrentQueue<string>();


    private void HandleUserInput(string message)
    {
        this.userInput.text = "";
        this.userInput.Select();
        this.userInput.ActivateInputField();
        this.input.Enqueue(message);
        if (message.Trim().Equals(""))
        {
            return;
        }
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
        if (!assetQueue.IsEmpty) {
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

    public void Print(string message)
    {
        Print(message, 0.01f);
    }

    public void Print(string message, float delay = 0.01f)
    {
        foreach (char c in message)
        {
            toPrint.Enqueue(new Renderer("" + c, this, delay));
        }
    }

    public void Sleep(float seconds)
    {
        toPrint.Enqueue(new Renderer("", this, seconds));
    }

    private class Renderer
    {
        private string c;
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

    private IDictionary<string, string> textAssets = new ConcurrentDictionary<string, string>();
    private ConcurrentQueue<string> assetQueue = new ConcurrentQueue<string>();

    internal string GetTextFile(string resourceName)
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
}
