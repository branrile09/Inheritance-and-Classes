using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    public struct Stats
    {
        public float stamina;
        public int strength;
        public int defence;
        public int intelligence;
        public float health;
        public Stats(float stamina,  int strength, int defence, int intelligence, float health)
        { 
            this.stamina = stamina;
            this.strength = strength;
            this.defence = defence;        
            this.intelligence = intelligence;
            this.health = health;
        }

    }





    public enum PlayerClass:int
    {
        Player = 0, 
        //mage types
        Mage = 1,
        Necromancer = 2,
        Druid = 3,
        //warrior types
        Warrior = 4,
        Paladin = 5,
        Healer = 6,
        //archer types
        Archer = 7,
        Rogue = 8,
        Assassin = 9, 
    }

    public abstract class Player
    {
        //basic stats
        protected float health = 100.0f;
        protected float stamina = 100.0f;
        protected string name = "";

        //adv stats
        protected int strength = 5;
        protected int intelligence = 5;
        protected int defence = 5;

        //very useful for polymorphism
        public PlayerClass ClassType = PlayerClass.Player;


        //constructor
        public Player()
        { 
        
        }

        public Player(float health, float stamina, string name, int strength, int intelligence, int defence)
        { 
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;            
        }

        public Player(Stats newStats)
        {
            assignStats(newStats);
        }

        //player abillities/interaction
        public virtual float DealDamage()
        {
            return strength* 0.5f;
        }

        public virtual void ReceiveDamage(float damage)
        {
            health -= damage;
        }

        //checks
        public bool IsAlive()
        {
            return health > 0;        
        }

        public string getName()
        { 
            return name;        
        }

        public float getHealth()
        {
            return health;        
        }

        public void receiveHealing(float health)
        {
            this.health += health;
        }

        public Stats getStats()
        {
            return new Stats(stamina,strength,defence,intelligence,health);               
        }

        protected void assignStats(Stats newStats)
        {
            this.stamina = newStats.stamina;
            this.strength = newStats.strength;
            this.defence = newStats.defence;
            this.intelligence = newStats.intelligence;
            this.health = newStats.health;
        }

    }



}
