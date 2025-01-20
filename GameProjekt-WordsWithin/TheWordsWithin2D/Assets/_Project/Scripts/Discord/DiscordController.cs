using System;
using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Discord
{
    public class DiscordController : MonoBehaviour {
        private global::Discord.Discord _discord;

        private UserManager _userManager;
        private string _currentScene;

        // Use this for initialization
        private void Start () {
            _discord = new global::Discord.Discord(902894229578215454, (ulong)CreateFlags.NoRequireDiscord);
            _userManager = _discord.GetUserManager();
            _userManager.OnCurrentUserUpdate += UpdateCurrentUsername;

            ActivityManager activityManager = _discord.GetActivityManager();

            ActivityAssets assets = new ActivityAssets {SmallImage = "player"};
            //discord.GetUserManager().GetCurrentUser.name;


            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

            ActivityTimestamps timestamps = new ActivityTimestamps {Start = unixTime};

            _currentScene = SceneManager.GetActiveScene().name;
            string title = "";

            switch (_currentScene)
            {
                case "Tutorial":
                    assets.LargeImage = "tutorial";
                    title = "Tutorial";
                    break;

                case "Level1":
                    assets.LargeImage = "grass";
                    title = "Level 1";
                    break;
                case "Level2":
                    assets.LargeImage = "autumn";
                    title = "Level 2";
                    break;
                case "MainMenu":
                    assets.LargeImage = "main";
                    title = "Hauptmen�";
                    break;
                case "Gameover":
                    assets.LargeImage = "gameover";
                    title = "Verloren :(";
                    break;
                case "Win":
                    assets.LargeImage = "win";
                    title = "Gewonnen";
                    break;
                case "Settings":
                    assets.LargeImage = "setting";
                    title = "Einstellungen";
                    break;
                case "Start":
                    assets.LargeImage = "tww";
                    title = "Fängt gerade an...";
                    break;
            }

            Activity activity = new Activity
            {
                State = title,
                Details = "Playing Singleplayer",
                Assets = assets,
                Instance = true,
                Timestamps = timestamps
            };


            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Result.Ok)
                {
                    Debug.Log("Discord initialized!");
                }
            });
        }

        private static void UpdateCurrentUsername()
        {
            // ToDo: Maybe we want to use the discord username at some point?
            //var currentUser = userManager.GetCurrentUser();
            //StaticValues.setCurrentUserName($"{currentUser.Username}#{currentUser.Discriminator}"); 
        }

        // Update is called once per frame
        private void Update ()
        {
            _discord.RunCallbacks();
        }

        private void OnDisable()
        {
            _discord?.Dispose();
        }
    }
}