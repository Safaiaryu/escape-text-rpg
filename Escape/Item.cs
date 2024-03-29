﻿using System;

namespace Escape
{
	abstract class Item : Entity
	{
		#region Declarations
		private bool uses;
		#endregion
		
		#region Constructor
		public Item(
			string Name,
			string Description,
			bool uses = false)
		:base(Name, Description)
		{
			this.uses = uses;
		}
		#endregion
		
		#region Public Methods
		public virtual void Use() { }

		public void NoUse()
		{
			Program.SetError("There is a time and place for everything, but this is not the place to use that!");
		}
		#endregion
	}

	#region BrassKey
	class Key : Item
	{
		private int targetLocation;
		private int newLocation;

		public Key(
			string Name,
			string Description,
			int targetLocation,
			int newLocation,
			bool uses = false)
		:base(Name, Description, uses)
		{
			this.targetLocation = targetLocation;
			this.newLocation = newLocation;
		}

		public override void Use()
		{
			if (Player.Location == targetLocation)
			{
				Program.SetNotification("The " + this.Name + " opened the lock!");
				World.Map[targetLocation].Exits.Add(newLocation);
			}
			else
			{
				NoUse();
				return;
			}
		}
	}
	#endregion

	#region ShinyStone
	class ShinyStone : Item
	{
		public ShinyStone(
			string Name,
			string Description,
			bool uses = false)
		: base(Name, Description, uses)
		{
		}

		public override void Use()
		{
			if (Player.Location == 3)
			{
				Player.Health += Math.Min(Player.MaxHealth / 10, Player.MaxHealth - Player.Health);
				Program.SetNotification("The magical stone restored your health by 10%!");
			}
			else
			{
				Program.SetNotification("The shiny orb glowed shiny colors!");
			}
		}
	}
	#endregion

	#region Rock
	class Rock : Item
	{
		public Rock(
			string Name,
			string Description,
			bool uses = false)
		:base(Name, Description, uses)
		{
		}

		public override void Use()
		{
			Program.SetNotification("You threw the rock at a wall. Nothing happened.");
		}
	}
	#endregion
}