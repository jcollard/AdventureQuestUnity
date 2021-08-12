using System;

namespace ActionCastle 
{

    public class ActionCastle : AbstractTextAdventure
    {
        public readonly Room Cottage;
        public readonly Room CourtYard;
        public readonly Room DrawBridge;
        public readonly Room Dungeon;
        public readonly Room DungeonStairs;
        public readonly Room FishingPond;
        public readonly Room GardenPath;
        public readonly Room GreatFeastingHall;
        public readonly Room ThroneRoom;
        public readonly Room TopOfTallTree;
        public readonly Room TowerStairs;
        public readonly Room Tower;
        public readonly Room WindingPath;

        public int hp = 5;
        public bool tookFishingPole = false;
        public bool pickedRose = false;
        public bool branchBroken = false;
        public bool guardSleeping = false;
        public bool isTrollFed = false;
        public bool isGuardSleeping = false;

        public ActionCastle()
        {
            Cottage = new Cottage();
            CourtYard = new CourtYard();
            DrawBridge = new DrawBridge();
            Dungeon = new Dungeon();
            DungeonStairs = new DungeonStairs();
            FishingPond = new FishingPond();
            GardenPath = new GardenPath();
            GreatFeastingHall = new GreatFeastingHall();
            ThroneRoom = new ThroneRoom();
            TopOfTallTree = new TopOfTallTree();
            TowerStairs = new TowerStairs();
            Tower = new Tower();
            WindingPath = new WindingPath();
            this.SetRoom(Cottage);
        }

        public override TextAdventure HandleInput(string input)
        {
            TextAdventure adventure = base.HandleInput(input);
            if (hp <= 0)
            {
                this.Print("You are dead.\n\n");
                this.Sleep(1.0f);
                this.OnStart();
                return new ActionCastle();
            }
            return adventure;
        }

        public override string GetStatus()
        {
            return "Status:\n\n - Hit Points: " + this.hp;
        }

        public override void OnStart()
        {
            this.Print(@"
 █████╗  ██████╗████████╗██╗ ██████╗ ███╗   ██╗  
██╔══██╗██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║  
███████║██║        ██║   ██║██║   ██║██╔██╗ ██║  
██╔══██║██║        ██║   ██║██║   ██║██║╚██╗██║  
██║  ██║╚██████╗   ██║   ██║╚██████╔╝██║ ╚████║  
╚═╝  ╚═╝ ╚═════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝  
                                                 
 ██████╗ █████╗ ███████╗████████╗██╗     ███████╗
██╔════╝██╔══██╗██╔════╝╚══██╔══╝██║     ██╔════╝
██║     ███████║███████╗   ██║   ██║     █████╗  
██║     ██╔══██║╚════██║   ██║   ██║     ██╔══╝  
╚██████╗██║  ██║███████║   ██║   ███████╗███████╗
 ╚═════╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚══════╝
                                                 
", 0.0025f);
            this.Print("WELCOME TO ACTION CASTLE!\n\n");
            this.Sleep(1.0f);
        }
    }

}
