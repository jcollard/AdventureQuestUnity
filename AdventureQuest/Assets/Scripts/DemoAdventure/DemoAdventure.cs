// This namespace should be the same as the folder name
namespace DemoAdventure
{

    // This class should be named the same as the file
    public class DemoAdventure : AbstractTextAdventure
    {

        // Initialize the variables that will be used in this adventure

        /// <summary>
        /// A boolean tracking if the player has a key.
        /// </summary>
        public bool HasKey = false;


        // The code in the OnStart() method is executed when the adventure begins!
        public override IRoom OnStart()
        {
            // At the start of the game, set all the variables to their default values.
            HasKey = false;

            // TODO: Create a title card
            PrintTextFile("CaveOfAdventure/title", 0.1F);
            // TODO: Set yourself as the author
            Print("\n                           A text adventure by Joseph Collard");

            // Pause for 2 seconds for dramatic effect before beginning in the CaveEntrance
            Sleep(2);
            Print("\n");

            // This is the room the player will begin in
            return new CottageRoom();
        }

        public override string GetAuthor()
        {
            //TODO: Change the author
            return "YOUR NAME HERE!";
        }

        public override string GetDescription()
        {
            //TODO: Change the description
            return "A short description here!";
        }

        public override string GetName()
        {
            //TODO: Change the name
            return "A Demo Adventure";
        }
    }
}