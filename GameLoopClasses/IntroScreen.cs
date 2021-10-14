using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Simple introScreen class that allows the user to start the game with the click of a button
    /// </summary>
    public class IntroScreen
    {
        /// <summary>
        /// Constructor. Creates singleton instance for the timekeeper
        /// </summary>
        public IntroScreen() => TimeKeeper.CreateInstance();
        /// <summary>
        /// Runs the intro screen game loop. Will play a simple zombie animation until the player clicks the start game button
        /// </summary>
        public void Run()
        {
            bool _menuClose = false;
            Random rnd = new Random();
            uint bitmapTimer = 300;
            List<Zombie> _introZombies = new();
            List<Zombie> lawnmowers = new();
            for (int i = 0; i<6; i++)
            {
                lawnmowers.Add(new StandardZombie(i*100));
            }
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.FillRectangleOnWindow(SplashKit.CurrentWindow(), Color.DarkOliveGreen, 0, 0, 1000, 600);
                SplashKit.DrawText("Alex's Plants VS Zombies", Color.Black, SplashKit.FontNamed("OratorStd"), 40, 150, 10);
                if (SplashKit.PointInRectangle(SplashKit.MousePosition(), SplashKit.RectangleFrom((SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50)))
                {
                    SplashKit.FillRectangle(Color.DarkRed, (SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50);
                }
                else
                {
                    SplashKit.FillRectangle(Color.Green, (SplashKit.CurrentWindowWidth() / 2) - 100, (SplashKit.CurrentWindowHeight() / 2) - 25, 200, 50);
                }
                SplashKit.DrawText("Start Game", Color.Black, SplashKit.FontNamed("OratorStd"), 32, (SplashKit.CurrentWindowWidth() / 2) - 95, (SplashKit.CurrentWindowHeight() / 2) - 20);
                foreach(Zombie lm in lawnmowers)
                {
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.Lawnmower.ToString()), lm.X, lm.Y,SplashKit.OptionFlipY());
                    for(int i = 0; i < 5; i++)
                    {
                        lm.Update();
                    }
                }
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
