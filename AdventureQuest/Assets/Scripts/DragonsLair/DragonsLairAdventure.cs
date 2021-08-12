namespace DragonsLair
{
    /// <summary>
    /// The DragonsLairAdventure is an example adventure which demonstrates how to create a TextAdventure.
    /// </summary>
    public class DragonsLairAdventure : AbstractTextAdventure
    {

        // Initialize each of the rooms that will be used in this adventure.
        public readonly IRoom CaveEntrance = new CaveEntrance();
        public readonly IRoom MouthOfCave = new MouthOfCave();
        public readonly IRoom Tunnel = new Tunnel();
        public readonly IRoom DeadEnd = new DeadEnd();
        public readonly IRoom Gym = new Gym();
        public readonly IRoom DragonLair = new Lair();
        public readonly IRoom Snoring = new Snoring();

        // Initialize the variables that will be used in this adventure

        /// <summary>
        /// The players Strength. This can be increased by visiting the Gym.
        /// </summary>
        public int Strength = 0;

        /// <summary>
        /// A boolean tracking if the player has a key.
        /// </summary>
        public bool HasKey = false;

        /// <summary>
        /// A boolean tracking if the player has found the sword.
        /// </summary>
        public bool HasSword = false;

        public override IRoom OnStart()
        {
            // At the start of the game, set all the variables to their default values.
            Strength = 0;
            HasKey = false;
            HasSword = false;

            // Loads the Title Card Text
            PrintTextFile("CaveOfAdventure/title", 0.1F);
            Print("\n                           A text adventure by Joseph Collard");

            // Pause for 2 seconds for dramatic effect before beginning in the CaveEntrance
            Sleep(2);
            Print("\n");
            return CaveEntrance;
        }

        public override string GetAuthor()
        {
            return "Joseph Collard";
        }

        public override string GetDescription()
        {
            return "You stand before a cave. It is well known that an evil dragon slumbers here. From time to time, the dragon wakes to terrorize the nearby villages and steal their gold.Dare you enter the cave in search of riches? Or would you rather run home to the comfort of your warm bed?";
        }

        public override string GetName()
        {
            return "The Dragon's Lair";
        }
    }
}