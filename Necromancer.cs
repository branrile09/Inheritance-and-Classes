using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Necromancer:Mage
    {
        private List<Player> myTeam;
        private List<Player> opponentTeam;
        private List<Player> graveyard;

        public Necromancer()
        {
            PlayerClass ClassType = PlayerClass.Necromancer;
        }

        public Necromancer(string name, Stats newStats, List<Player> Team, List<Player> Opponents, List<Player> Graves)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Necromancer;
            myTeam = Team;
            opponentTeam = Opponents;
            graveyard = Graves;
        }


        public Necromancer(float health, float stamina, string name, int strength, int intelligence, int defence, List<Player> Team, List<Player> Opponents, List<Player> Graves)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            PlayerClass ClassType = PlayerClass.Necromancer;
            myTeam = Team;
            opponentTeam = Opponents;
            graveyard = Graves;
        }


        public override float DealDamage()
        {
            Random newRand = new();
            int attackingMove = newRand.Next(10);
            

            if (attackingMove > 8)
            {
                NecromancerVoodo();
                return 0;
            }
            else if (attackingMove > 3)
            {
                return Fireball();
            }
            else
            {
                return intelligence * 0.5f;
            }

        }


        private void NecromancerVoodo()
        {
            if (graveyard == null)
                return;

            if (graveyard.Count > 0)
            {
                Undead newUndead = new Undead(graveyard[0]);
                myTeam.Add(newUndead);
                graveyard.RemoveAt(0);
                Console.WriteLine("undead has been made");
            }
        
        }


    }

    internal class Undead : Player
    {
        
        public Undead( Player deadPlayer)
        {
            Stats newStat = deadPlayer.getStats();
            this.health = 20.0f;
            this.defence = newStat.defence;
            this.strength=newStat.strength;
            this.stamina=newStat.stamina;            
        }


    }





}
