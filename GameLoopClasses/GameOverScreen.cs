using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Basic GameOver Screen with a quit game button
    /// </summary>
    class GameOverScreen
    {
        public GameOverScreen() {  }
        /// <summary>
        /// Runs the game over screen draw update loop until either the window is closed or a the game exit button is pressed
        /// </summary>
        public void Run()
        {
            bool _menuClose = false;
            Random rnd = new Random();
            uint bitmapTimer = 0;
            List<Zombie> _introZombies = new();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.FillRectangleOnWindow(SplashKit.CurrentWindow(), Color.DarkOliveGreen, 0, 0, 1000, 600);
                SplashKit.DrawText("GameOver", Color.Black, SplashKit.FontNamed("OratorStd"), 40, 350, 10);
                SplashKit.DrawText("You Scored: " + PlayerData.GetInstance().Points, Color.Black, SplashKit.FontNamed("OratorStd"), 40, 350, 50);
                if (SplashKit.PointInRectangle(SplashKit.MousePosition(), SplashKit.RectangleFrom((SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50)))
                {
                    SplashKit.FillRectangle(Color.DarkRed, (SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50);
                }
                else
                {
                    SplashKit.FillRectangle(Color.Green, (SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50);
                }
                SplashKit.DrawText("Quit", Color.Black, SplashKit.FontNamed("OratorStd"), 32, (SplashKit.CurrentWindowWidth() / 2) - 95, (SplashKit.CurrentWindowHeight() / 2) - 20);
                if (bitmapTimer % 1000 == 0)
                {
                    _introZombies.Add(new StandardZombie(rnd.Next(600)));
                }
                foreach (Zombie z in _introZombies)
                {
                    z.Draw();
                    z.Update();
                }
                bitmapTimer++;
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (SplashKit.PointInRectangle(SplashKit.MousePosition(), SplashKit.RectangleFrom((SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50)))
                    {
                        _menuClose = true;
                    }
                }
                SplashKit.RefreshScreen();
            } while (!_menuClose && !SplashKit.WindowCloseRequested("PVZ"));
        }
    }
}

