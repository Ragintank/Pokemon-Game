using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace Pokemon_Game
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
		}
		async void StartButtonClicked(object sender, EventArgs args)
		{
			MenuSound();
			Navigation.PushAsync(new Page1());
		}
		async void QuitButtonClicked(object sender, EventArgs args)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}
		public void MenuSound()
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream audioStream = assembly.GetManifestResourceStream("Pokemon_Game.ButtonSound.wav");
			var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
			audio.Load(audioStream);

			audio.Play();
		}
		public void HealSound()
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream audioStream = assembly.GetManifestResourceStream("Pokemon_Game.HealSound.wav");
			var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
			audio.Load(audioStream);

			audio.Play();
		}
		public void SlashSound()
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream audioStream = assembly.GetManifestResourceStream("Pokemon_Game.SlashSound.wav");
			var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
			audio.Load(audioStream);

			audio.Play();
		}
		public void StabSound()
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream audioStream = assembly.GetManifestResourceStream("Pokemon_Game.StabSound.wav");
			var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
			audio.Load(audioStream);

			audio.Play();
		}
		public void ThrowSound()
		{
			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream audioStream = assembly.GetManifestResourceStream("Pokemon_Game.ThrowSound.wav");
			var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
			audio.Load(audioStream);

			audio.Play();
		}
	}
}
