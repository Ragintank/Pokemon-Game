using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon_Game
{
	public class Entity
	{
		public Entity(string name, int hp, int mp)
		{
			Name = name;
			Health = hp;
			maxHealth = hp;
			Mana = mp;
			maxMana = mp;
		}
		public string Name { get; set; }
		public int Health { get; set; }
		public int Mana { get; set; }
		public int maxHealth;
		public int maxMana;
	}
}
