using System;
using System.Threading;

/// <summary>
/// An AbstractTextAdventure provides default implementations of almost all of
/// the methods necessary to create a Text Adventure game. To extend this class,
/// you only need to implement the <a cref="ITextAdventure.OnStart">OnStart</a>,
/// <a cref="ITextAdventure.GetName">GetName</a>,
/// <a cref="ITextAdventure.GetAuthor">GetAuthor</a>, and
/// <a cref="ITextAdventure.GetDescription">GetDescription</a> methods. An
/// example adventure has been provided: <see cref="DragonsLairAdventure"/>
/// </summary>
public abstract class AbstractTextAdventure : ITextAdventure
{

    /// <summary>
    /// The Engine to use for input and output
    /// </summary>
    private TextAdventureEngine engine;

    /// <summary>
    /// The current Room
    /// </summary>
    private IRoom room;

    /// <summary>
    /// If the player has lost the game
    /// </summary>
    private bool IsGameOver = false;

    /// <summary>
    /// If the player has won the game
    /// </summary>
    private bool IsGameWon = false;

    /// <inheritdoc/>
    public void Print(string message)
    {
        this.Print(message, 0.01f);
    }

    /// <inheritdoc/>
    public void Print(string message, float delay)
    {
        if (engine == null)
        {
            return;
        }
        engine.Print(message, delay);
    }

    /// <inheritdoc/>
    public void Sleep(float seconds)
    {
        if (engine == null)
        {
            return;
        }
        engine.Sleep(seconds);
    }

    /// <inheritdoc/>
    public void SetEngine(TextAdventureEngine engine)
    {
        this.engine = engine;
    }

    /// <inheritdoc/>
    public IRoom GetRoom()
    {
        return room;
    }

    /// <inheritdoc/>
    public void DisplayRoom()
    {
        DisplayRoomName();
        DisplayDescription();
    }

    /// <inheritdoc/>
    public void DisplayRoomName()
    {
        string roomName = this.room.GetName(this);
        string end = " |";
        string border = "=-";
        for (int ix = 0; ix < roomName.Length; ix++)
        {
            border += ix % 2 == 0 ? "=" : "-";
        }
        if (roomName.Length % 2 == 1)
        {
            border += "-=";
        }
        else
        {
            border += "=-=";
            end = "  |";
        }
        string middle = "| " + roomName + end;
        this.Print("\n" + border + "\n");
        this.Print(middle + "\n");
        this.Print(border + "\n");
    }

    /// <inheritdoc/>
    public void DisplayDescription()
    {
        this.Print("\n" + this.room.GetDescription(this) + "\n");
    }

    /// <inheritdoc/>
    public string GetInput()
    {
        string result = null;
        while (engine.input.IsEmpty)
        {
            Thread.Sleep(100);
        }
        if (!engine.input.TryDequeue(out result))
        {
            return GetInput();
        }
        return result;
    }

    /// <inheritdoc/>
    public void Run()
    {
        this.room = this.OnStart();
        while (!IsGameOver && !IsGameWon)
        {
            if (this.room == null)
            {
                Print("ERROR: The current room is null!");
                break;
            }
            DisplayRoom();
            this.room = this.room.HandleInput(this);
            Sleep(1);
        }
    }

    /// <inheritdoc/>
    public void GameOver()
    {
        this.IsGameOver = true;
    }

    /// <inheritdoc/>
    public void PrintTextFile(string resourceName, float delay)
    {
        string data = engine.GetTextFile(resourceName);
        string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        foreach (string line in lines)
        {
            Print(line + "\n", 0);
            Sleep(delay);
        }
    }

    /// <inheritdoc/>
    public void GameWon()
    {
        this.IsGameWon = true;
    }

    /// <inheritdoc/>
    public abstract IRoom OnStart();

    /// <inheritdoc/>
    public abstract string GetName();

    /// <inheritdoc/>
    public abstract string GetAuthor();

    /// <inheritdoc/>
    public abstract string GetDescription();

}
