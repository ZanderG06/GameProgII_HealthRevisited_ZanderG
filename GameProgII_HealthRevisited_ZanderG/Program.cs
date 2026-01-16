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

        public void TakeDamage(float damage)
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

        public void Heal(float healAmount)
        {
            if(healAmount < 0)
            {
                healAmount = 0;
                Console.WriteLine("ERROR! Heal is a negative numver, health will not change");
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
        public Health _health;
        public Health _shield;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Health Health
        {
            get { return _health; }
            private set { _health = value; }
        }

        public Health Shield
        {
            get { return _shield; }
            private set { _shield = value; }
        }

        public void TakeDamage(float damage)
        {
            if(damage > Shield.CurrentHealth)
            {
                float overflowDamage = damage - Shield.CurrentHealth;

                Shield.TakeDamage(damage);

                if(overflowDamage > 0)
                {
                    Health.TakeDamage(overflowDamage);
                }
            }
            else
            {
                Health.TakeDamage(damage);
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

        public Player(string name, int maxHealth, int maxShield)
        {
            _name = name;
            //Health = maxHealth;

        }
    }
}
