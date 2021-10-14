using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Main game controller class. manages the game loop, all entity engines and gui elements.
    /// </summary>
    public class Game
    {
        private Toolbar _toolbar;
        private SunEngine _sunEngine;
        private EntityCollisionEngine _entityCollisionEngine;
        private ZombieEngine _zombieEngine;
        private EntityRenderer _entityRenderer;
        #if DEBUG
            private DebugController _debug;
        #endif
        /// <summary>
        /// Constructor. Intitialises all relevant singleton classes and creates base gui objects required on game startup.
        /// </summary>
        public Game() 
        {
            TimeKeeper.CreateInstance();
            InputManager.CreateInstance();
            EntityUpdater.CreateInstance();
            EntityRepository.CreateInstance();
            PlayerData.CreateInstance();
            #if DEBUG
                _debug = new();
            #endif
            _toolbar = new Toolbar(0,EntityRepository.GetInstance().RowAt(3)+100);
            _entityCollisionEngine = new EntityCollisionEngine();
            _entityRenderer = new EntityRenderer();
            _sunEngine = new SunEngine();
            _zombieEngine = new ZombieEngine();
            for(int i = 0; i<4; i++)
            {
                float y = EntityRepository.GetInstance().RowAt(i);
                EntityFactory.SpawnLawnmower(y);
            }
        }
        /// <summary>
        /// Runs the game loop, handles calling all updaters, renderers and collision engines
        /// </summary>
        public void Run()
        {
            ToolManager.GetInstance().SetActiveTool(ToolType.EntitySelection);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.FillRectangleOnWindow(SplashKit.CurrentWindow(), Color.Tan, 0, 0, 1000, 600); //tan backdrop to window
                InputManager.GetInstance().Update();
                _entityCollisionEngine.Collide();
                EntityUpdater.GetInstance().Update();
                _sunEngine.Update();
                _zombieEngine.Update();
                _entityRenderer.Render();
                #if DEBUG
                    _debug.Update();
                #endif
                ToolManager.GetInstance().Update();
                PlayerData.GetInstance().Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("PVZ") && !PlayerData.GetInstance().GameOver);
        }
    }
}
