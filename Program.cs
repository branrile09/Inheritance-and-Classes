namespace Inheritance_and_Classes
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            List<Player> Team1 = new List<Player>();
            List<Player> Team2 = new List<Player>();
            List<Player> Graveyard = new();
            int teamSizes = 12;

            InitializeTeams(Team1, teamSizes,Team2,Graveyard);
            InitializeTeams(Team2, teamSizes,Team1,Graveyard);

            do
            {
                BattlePhases(Team1,Team2,Graveyard);
                BattlePhases(Team2,Team1,Graveyard);

            } while (Team1.Count > 0 && Team2.Count > 0);

            if (Team1.Count > 0)
                Console.WriteLine("Team 1 wins");
            else            
                Console.WriteLine("Team 2 wins");
            
        }

        static void InitializeTeams(List<Player> Team, int size, List<Player> Opponents, List<Player>Graves)
        { 
           
            Random random = new Random();
            PlayerClass playerClass = new();
            
            for (int i = 0; i < size; i++)
            {
                float health = random.Next(60,100);
                float stamina = 100;                
                int strength = random.Next(10);
                int intelligence = random.Next(10);
                int defence = random.Next(10);
                Stats newStats = new(stamina,strength,defence,intelligence,health);

                string name = "";

                Player newPlayer = null;
                playerClass = (PlayerClass) random.Next(1,10);
                switch (playerClass)
                {
                    case PlayerClass.Warrior:
                        name = "bob the berserker" + i;
                        newPlayer = new Warrior(name,newStats);
                        break;
                    case PlayerClass.Assassin:
                        name = "aragorn the assassin" + i;
                        newPlayer = new Assassin(name,newStats);
                        break;
                    case PlayerClass.Mage:
                        name = "Merlin the mage" + i;
                        newPlayer = new Mage(name,newStats);
                        break;
                    case PlayerClass.Druid:
                        name = "DAZZA the Druid" + i;
                        newPlayer = new Druid(name, newStats);
                        break;
                    case PlayerClass.Necromancer:
                        name = "Necromancer Nick" + i;
                        newPlayer = new Necromancer(name,newStats,Team,Opponents,Graves);
                        break;
                    case PlayerClass.Paladin:
                        name = "Paladin Pete" + i;
                        newPlayer = new Paladin(name, newStats);
                        break;
                    case PlayerClass.Healer:
                        name = "Tim the Healer" + i;
                        newPlayer = new Healer(name, newStats,Team);
                        break;
                    case PlayerClass.Archer:
                        name = "Adam" + i;
                        newPlayer = new Archer(name, newStats);
                        break;
                    case PlayerClass.Rogue:
                        name = "Rick" + i;
                        newPlayer = new Rogue(name, newStats);
                        break;
                }
                if (newPlayer != null)
                {
                    Team.Add(newPlayer);
                    //Console.WriteLine($"{name} added to list");
                }
            }       
        
        }



        static void BattlePhases(List<Player> Attacking, List<Player> Defending, List<Player> Graveyard)
        {
            int i = Attacking.Count;
            //added in undead during attack phase has summoning sickness
            for (int j = 0; j < i; j++)
            {
                if (Defending.Count <= 0)
                { break; }
                float damage = Attacking[j].DealDamage();
                int iterator = 0;
                Random rand = new Random();
                iterator = rand.Next(Defending.Count);
                Defending[iterator].ReceiveDamage(damage);

                if (!Defending[iterator].IsAlive())
                {
                    Graveyard.Add(Defending[iterator]);
                    Defending.RemoveAt(iterator);                
                }
            }                
        
        
        }

    }
}