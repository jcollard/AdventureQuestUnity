namespace DragonsLair
{
    public class DragonsLairAdventure : AbstractTextAdventure
    {

        public readonly IRoom CaveEntrance = new CaveEntrance();
        public readonly IRoom MouthOfCave = new MouthOfCave();
        public readonly IRoom Tunnel = new Tunnel();
        public readonly IRoom DeadEnd = new DeadEnd();
        public readonly IRoom Gym = new Gym();
        public readonly IRoom DragonLair = new Lair();
        public readonly IRoom Snoring = new Snoring();

        public int Strength = 0;
        public bool HasKey = false;
        public bool HasSword = false;

        public override IRoom OnStart()
        {
            Strength = 0;
            HasKey = false;
            HasSword = false;
            PrintTextFile("CaveOfAdventure/title", 0.1F);
            Print("\n                           A text adventure by Joseph Collard");
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