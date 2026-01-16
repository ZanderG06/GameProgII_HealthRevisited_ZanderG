using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_HealthRevisited_ZanderG
{
    internal class Program
    {
        static bool isPlaying = true;

        static void Main(string[] args)
        {

            Health health = new Health(100);
            Health shield = new Health(100);

            
            Random random = new Random();
            
            Console.WriteLine("Please type your name");
            string userName = Console.ReadLine();

            Player player = new Player(userName, 100, 100);
            Console.Clear();

            while (isPlaying)
            {
                player.ShowHUD();
                
                if (player.Health.CurrentHealth <= 0)
                {
                    isPlaying = false;
                    Console.WriteLine("You are dead, press any button to quit");
                }
                else
                {
                    Console.WriteLine("Press D key to take damage or H key to heal");
                }

                
                ConsoleKeyInfo playerInput = Console.ReadKey(true);

                if (playerInput.Key == ConsoleKey.D)
                {
                    player.TakeDamage(random.Next(1, 21));
                }
                if (playerInput.Key == ConsoleKey.H)
                {
                    player.Health.Heal(random.Next(1, 21));
                }
                Console.Clear();
            }        
        }
    }

    class Health
    {
        public int _currentHealth;
        public int _maxHealth;


        public int CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
            private set { _maxHealth = value; }
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("ERROR! Damage is a negative number, health will not change.");
            }
            else
            {
                CurrentHealth -= damage;

                if(CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                }
            }
        }

        public void Restore()
        {
            CurrentHealth = MaxHealth;
        }

        public void Heal(int healAmount)
        {
            if(healAmount < 0)
            {
                healAmount = 0;
                Console.WriteLine("ERROR! Heal is a negative number, health will not change");
            }
            else
            {
                CurrentHealth += healAmount;

                if(CurrentHealth > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
        }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        
    }

    class Player
    {
        string _name;


        public Health Health = new Health(100);
        public Health Shield = new Health(100);

        public Player(string name, int maxHealth, int maxShield)
        {
            _name = name;
            Health._maxHealth = maxHealth;
            Shield._maxHealth = maxShield;

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        public Health _health
        {
            get { return _health; }
            private set { _health = value; }
        }
        

        public Health _shield
        {
            get { return _shield; }
            private set { _shield = value; }
        }

       
        public void TakeDamage(int damage)
        {
            int overflowDamage = damage - Shield.CurrentHealth;

            Shield.TakeDamage(damage);

            if (overflowDamage > 0)
            {
                Health.TakeDamage(overflowDamage);
            }
        }

        public string GetStatusString()
        {
            if(Health.CurrentHealth == 100)
            {
                return "Health Perfect";
            }
            else if(Health.CurrentHealth <= 99 && Health.CurrentHealth >= 76)
            {
                return "Health Good";
            }
            else if(Health.CurrentHealth <= 75 && Health.CurrentHealth >= 51)
            {
                return "Health Ok";
            }
            else if(Health.CurrentHealth <= 50 && Health.CurrentHealth >= 26)
            {
                return "Health Low";
            }
            else if(Health.CurrentHealth <= 25 && Health.CurrentHealth >= 1)
            {
                return "Bro Heal Up!";
            }
            else
            {
                return "Dead";
            }
        }

        public void ShowHUD()
        {
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health.CurrentHealth}");
            Console.WriteLine($"Shield: {Shield.CurrentHealth}");
            Console.WriteLine($"Status: {GetStatusString()}");
        }
    }
}
