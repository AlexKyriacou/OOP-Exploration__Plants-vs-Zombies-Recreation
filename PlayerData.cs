using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Player contains all the player state information such as money, points and game over status.
    /// implements singleton pattern
    /// </summary>
    public class PlayerData
    {
        /// <summary>
        /// singleton instance of player
        /// </summary>
        private static PlayerData _instance;
        /// <summary>
        /// Players current money amount
        /// </summary>
        public int Money { get; set; }
        /// <summary>
        /// Boolean dependant on if a game over condition has been reached
        /// </summary>
        public bool GameOver { get; set; }
        /// <summary>
        /// Current in game point of the player
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Constructor. Intitialises the players money points and game state staus.
        /// </summary>
        private PlayerData() 
        {
            Money = 300;
            Points = 0;
            GameOver = false;
        }
        /// <summary>
        /// Creates new singleton instance of the player
        /// </summary>
        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
        }
        /// <summary>
        /// Gets singleton instnace of the player
        /// </summary>
        /// <returns>retruns singleton insatnce</returns>
        public static PlayerData GetInstance() => _instance;
        /// <summary>
        /// Renders Player Data to the screen
        /// </summary>
        public void Draw()
        {
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), "-Points:", Color.Black, SplashKit.FontNamed("OratorStd"), 32, SplashKit.CurrentWindowWidth() - 200, EntityRepository.GetInstance().RowAt(3) + 120);
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), Points.ToString(), Color.Black, SplashKit.FontNamed("OratorStd"), 32, SplashKit.CurrentWindowWidth() - 180, EntityRepository.GetInstance().RowAt(3) + 150);
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), "-Money: ", Color.Black, SplashKit.FontNamed("OratorStd"), 32, SplashKit.CurrentWindowWidth() - 200, EntityRepository.GetInstance().RowAt(3) + 190);
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), Money.ToString(), Color.Black, SplashKit.FontNamed("OratorStd"), 32, SplashKit.CurrentWindowWidth() - 180, EntityRepository.GetInstance().RowAt(3) + 220);
        }
    }
}
