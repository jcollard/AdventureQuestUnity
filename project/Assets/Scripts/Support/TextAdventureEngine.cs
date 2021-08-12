using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextAdventureEngine : MonoBehaviour
{

    public InputField userInput;
    public ScrollRect textDisplay;
    public Text textDisplayText;
    public Text inventoryText;
    public Text gameStateText;
    public TextAdventure adventure;

    private Queue<Renderer> toPrint = new Queue<Renderer>();
    private float nextRender = 0;
    private List<string> inventory = new List<string>();

    // Use this for initialization
    void Start()
    {
        
        this.textDisplayText.text = "";
        this.adventure = Config.GetAdventure();
        this.adventure.SetEngine(this);
        this.adventure.OnStart();
        this.adventure.DisplayRoom();
        // Update the inventory and gamestate display
        UpdateScreen();

        InputField.SubmitEvent se = new InputField.SubmitEvent();
        se.AddListener(HandleUserInput);
        this.userInput.onEndEdit = se;

        this.userInput.Select();
        this.userInput.ActivateInputField();
    }


    private void HandleUserInput(string message)
    {
        this.userInput.text = "";
        this.userInput.Select();
        this.userInput.ActivateInputField();

        if (message.Equals(""))
        {
            return;
        }

        Room r = this.adventure.GetRoom();
        this.adventure = this.adventure.HandleInput(message);

        // If we are in a new room, display the room
        if (r != this.adventure.GetRoom())
        {
            this.adventure.DisplayRoom();
        }
        
    }

    private void UpdateScreen()
    {
        this.inventoryText.text = this.adventure.FormatInventory();
        this.gameStateText.text = adventure.GetStatus();
    }

    private void FixedUpdate()
    {
        // Keep the Next Render counter up to date
        if (Time.time > this.nextRender)
        {
            this.nextRender = Time.time;
        }

        // If there is no work to be done
        if(toPrint.Count == 0)
        { 
            // Update the inventory and gamestate display
            UpdateScreen();
            return;
        }

        // If there is work to be done, check to see if we should print the
        // next character. Print all of the characters that should be printed
        while(toPrint.Count > 0 && toPrint.Peek().renderAt < Time.time)
        {
            toPrint.Dequeue().Render(this);
        }

        //Scroll to the bottom of the view
        textDisplay.verticalNormalizedPosition = 0;
        
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
}
