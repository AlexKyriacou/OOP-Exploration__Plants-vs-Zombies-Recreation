using System;
using FinalProject;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        new Window("PVZ", 950, 600);
        SplashKit.LoadResourceBundle("Bitmaps", "Bitmaps.txt");
        IntroScreen intro = new IntroScreen();
        intro.Run();
        Game game = new Game();
        game.Run();
        GameOverScreen gameOverScreen = new GameOverScreen();
        gameOverScreen.Run();
        SplashKit.FreeResourceBundle("Bitmaps");
    }
}
