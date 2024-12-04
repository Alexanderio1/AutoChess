using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess.Classes
{
    public abstract class Unit : ICloneable
    {
        private int health;
        private int attackPower;
        private string name;
        private string description;

        // Имя персонажа с проверкой
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else throw new ArgumentException("Имя не может быть пустым или состоять только из пробелов");
            }
        }

        // Описание персонажа
        public string Description
        {
            get => description;
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
                else throw new ArgumentException("Описание не может быть пустым или состоять только из пробелов");
            }
        }

        // Здоровье
        public int Health
        {
            get => health;
            set
            {
                if (value < 0) health = 0;
                else health = value;
            }
        }

        // Сила атаки
        public int AttackPower
        {
            get => attackPower;
            set
            {
                if (value >= 0) attackPower = value;
                else throw new ArgumentOutOfRangeException("Сила атаки не может быть отрицательной");
            }
        }

        // Защита
        public int Defense { get; set; }

        // Координаты на поле
        public (int X, int Y) Position { get; set; }

        // Метод для нанесения урона
        public void TakeDamage(int damage, string damageType = "Physical")
        {
            int effectiveDamage = CalculateDamage(damage, damageType);
            Health -= effectiveDamage;

            Console.WriteLine($"{Name} получил {effectiveDamage} урона ({damageType}). Осталось здоровья: {Health}");
        }

        // Рассчёт урона с учётом типа
        private int CalculateDamage(int damage, string damageType)
        {
            if (damageType == "Magical") return damage;

            int reducedDamage = damage - Defense;
            return reducedDamage > 0 ? reducedDamage : 0;
        }

        

        // Абстрактный метод для уникальных действий
        public abstract void UseAbility();

        // Клонирование объекта
        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name} ({Description}) - HP: {Health}, Attack: {AttackPower}, Defense: {Defense}, Position: ({Position.X}, {Position.Y})";
        }
    }
}
