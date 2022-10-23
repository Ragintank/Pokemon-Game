using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemon_Game
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public List<Entity> entitys = new List<Entity>();
		StartPage start = new StartPage();
		public Random rnd = new Random();
		private string buttonName;
		private int healCount;
		public Page1()
		{
			InitializeComponent();
			BackButtonFunction();
			EntityCreate();
		}

		//Methods
		private void EntityCreate()
		{
			entitys.Add(new Entity("Player", 125, 75));
			entitys.Add(new Entity("Giant Rat", 200, 0));

			playerName.Text = entitys[0].Name;
			creatureName.Text = entitys[1].Name;

			healCount = 2;
			EntityUpdate();
		}
		private void EntityUpdate()
		{
			playerHP.Text = "Health: " + entitys[0].Health.ToString() + " / " + entitys[0].maxHealth.ToString();
			playerHPBar.Progress = Convert.ToDouble(entitys[0].Health) / Convert.ToDouble(entitys[0].maxHealth);
			playerMP.Text = "Mana: " + entitys[0].Mana.ToString() + " / " + entitys[0].maxMana.ToString();
			playerMPBar.Progress = Convert.ToDouble(entitys[0].Mana) / Convert.ToDouble(entitys[0].maxMana);

			creatureHP.Text = "Health: " + entitys[1].Health.ToString() + " / " + entitys[1].maxHealth.ToString();
			creatureHPBar.Progress = Convert.ToDouble(entitys[1].Health) / Convert.ToDouble(entitys[1].maxHealth);

			if(entitys[0].Health <= 0)
			{
				restartLabel.Text = "You have died!";
				Win_Loss();
			}
			else if(entitys[1].Health <= 0)
			{
				restartLabel.Text = "You have killed the " + creatureName.Text + "!";
				Win_Loss();
			}
			else if(entitys[0].Mana <= 0 && healCount == 0)
			{
				restartLabel.Text = "You have ran out of mana and heals.";
				Win_Loss();
			}
		}
		private void NotEnoughMana()
		{
			notEnoughMana.Text = "Not Enough Mana To Cast: " + buttonName;
			notEnoughMana.IsVisible = true;
		}
		private void EnemyAttack()
		{
			int num = rnd.Next(5, 30);
			entitys[0].Health -= num;
		}
		private void BackButtonFunction()
		{
			//Attack Buttons
			stabButton.IsVisible = false;
			slashButton.IsVisible = false;
			throwButton.IsVisible = false;
			stabManaCost.IsVisible = false;
			slashManaCost.IsVisible = false;
			throwManaCost.IsVisible = false;

			//Heal Label
			healCountLabel.IsVisible = true;

			//Menu Buttons
			quitToStartButton.IsVisible = false;
			quitButton.IsVisible = false;

			//Back Button iteself
			backButton.IsVisible = false;

			//Default Buttons
			attackButton.IsVisible = true;
			healButton.IsVisible = true;
			menuButton.IsVisible = true;
		}
		private void Win_Loss()
		{
			restartLabel.IsVisible = true;
			restartButton.IsVisible = true;
			quitToStartButton.IsVisible = true;
			quitButton.IsVisible = true;

			attackButton.IsVisible = false;
			healButton.IsVisible = false;
			menuButton.IsVisible = false;
			healCountLabel.IsVisible = false;

			stabButton.IsVisible = false;
			stabManaCost.IsVisible = false;
			slashButton.IsVisible = false;
			slashManaCost.IsVisible = false;
			throwButton.IsVisible = false;
			throwManaCost.IsVisible = false;
			backButton.IsVisible = false;

			stabManaCost.IsVisible = false;
			slashManaCost.IsVisible = false;
			throwManaCost.IsVisible = false;

			notEnoughMana.IsVisible = false;
		}


		//Buttons Below
		async void AttackButtonClicked(object sender, EventArgs args)
		{
			start.MenuSound();
			attackButton.IsVisible = false;
			healButton.IsVisible = false;
			menuButton.IsVisible = false;
			healCountLabel.IsVisible = false;

			stabButton.IsVisible = true;
			slashButton.IsVisible = true;
			throwButton.IsVisible = true;
			backButton.IsVisible = true;

			stabManaCost.IsVisible = true;
			slashManaCost.IsVisible = true;
			throwManaCost.IsVisible = true;

			notEnoughMana.IsVisible = false;
		}
		async void HealButtonClicked(object sender, EventArgs args)
		{
			start.HealSound();
			if(healCount >= 1)
			{
				entitys[0].Health += 50;
				entitys[0].Mana += 25;
				healCount -= 1;
				healCountLabel.Text = "Heals Left: " + healCount;
				if(entitys[0].Health >= 125)
				{
					entitys[0].Health = 125;
				}
				if(entitys[0].Mana >= 75)
				{
					entitys[0].Mana = 75;
				}
				EnemyAttack();
				EntityUpdate();
			}

			notEnoughMana.IsVisible = false;
		}
		async void MenuButtonClicked(object sender, EventArgs args)
		{
			start.MenuSound();
			attackButton.IsVisible = false;
			healButton.IsVisible = false;
			menuButton.IsVisible = false;
			healCountLabel.IsVisible = false;

			quitToStartButton.IsVisible = true;
			quitButton.IsVisible = true;
			backButton.IsVisible = true;

			notEnoughMana.IsVisible = false;
		}
		async void BackButtonClicked(object sender, EventArgs args)
		{
			start.MenuSound();
			BackButtonFunction();
		}
		async void SlashButtonClicked(object sender, EventArgs args)
		{
			start.SlashSound();
			//Strong but expensive attack
			int num = rnd.Next(4, 8);
			buttonName = "slash";
			BackButtonFunction();

			if(entitys[0].Mana >= 25)
			{
				entitys[0].Mana -= 25;
				entitys[1].Health -= 30 + num;
				EnemyAttack();
				EntityUpdate();
			}
			else
			{
				NotEnoughMana();
			}
		}
		async void StabButtonClicked(object sender, EventArgs args)
		{
			start.StabSound();
			//Mediumn strength medium cost
			int num = rnd.Next(2, 6);
			buttonName = "stab";
			BackButtonFunction();

			if(entitys[0].Mana >= 10)
			{
				entitys[0].Mana -= 10;
				entitys[1].Health -= 15 + num;
				EnemyAttack();
				EntityUpdate();
			}
			else
			{
				NotEnoughMana();
			}
		}
		async void ThrowButtonClicked(object sender, EventArgs args)
		{
			start.ThrowSound();
			//Weak but cheap attack
			int num = rnd.Next(1, 5);
			buttonName = "Throw Rock";
			BackButtonFunction();

			if(entitys[0].Mana >= 5)
			{
				entitys[0].Mana -= 5;
				entitys[1].Health -= 10 + num;
				EnemyAttack();
				EntityUpdate();
			}
			else
			{
				NotEnoughMana();
			}
		}
		async void QuitToStartButtonClicked(object sender, EventArgs args)
		{
			start.MenuSound();
			Navigation.PushAsync(new StartPage());
		}
		async void QuitButtonClicked(object sender, EventArgs args)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}
		async void RestartButtonClicked(object sende, EventArgs args)
		{
			start.MenuSound();
			Navigation.PushAsync(new Page1());
		}
	}
}