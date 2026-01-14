using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_HealthRevisited_ZanderG
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Health
    {
        float _currentHealth;
        float _maxHealth;

        public float CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = value; }
        }

        public float MaxHealth
        {
            get { return _maxHealth; }
            private set { _maxHealth = value; }
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("ERROR! Damage is a negative number, health will not change.");
            }
            else
            {
                _currentHealth -= damage;
            }
        }

        public void Restore()
        {
            _currentHealth = _maxHealth;
        }

        public void Heal(int heal)
        {
            if(heal < 0)
            {
                Console.WriteLine("ERROR! Heal is a negative numver, health will not change");
            }
            else
            {
                _currentHealth += heal;
            }
        }

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }
    }

    class Player
    {
        string _name;
        public Health health;
        public Health shield;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Health Health
        {
            get { return health; }
            private set { health = value; }
        }

        public Health Shield
        {
            get { return shield; }
            private set { shield = value; }
        }

        public void TakeDamage(int damage)
        {

        }

        public string GetStatusString()
        {
            //if(health == 100)
            {

            }
            
            return "";
        }
    }
}
