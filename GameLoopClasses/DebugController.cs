using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Controlls the debug functionality of the game when run in debug mode. allowing the player to override gameplay
    /// </summary>
    public class DebugController
    {
        private Dictionary<KeyCode, Action> _keytypeDict;
        private bool _zombieToggle;
        /// <summary>
        /// Constructor. Adds all relevent debug keys to the debug dictionary and initialises variables
        /// </summary>
        public DebugController()
        {
            Console.WriteLine("\n\nDEBUG MODE ACTIVATED:"
                              + "\n\tKey:\t\tAction:"
                              + "\n\tNum1\t\tSpawn Zombie In Lane 0"
                              + "\n\tNum2\t\tSpawn Zombie In Lane 1"
                              + "\n\tNum3\t\tSpawn Zombie In Lane 2"
                              + "\n\tNum4\t\tSpawn Zombie In Lane 3"
                              + "\n\tNum5\t\tAdd 100 Money To Wallet"
                              + "\n\tNum6\t\tCreate Falling Sun"
                              + "\n\tTabKey\t\tToggle Zombie Spawn Type"
                              + "\n\tSpaceKey\tSkip 100 Game Ticks\n");
            _keytypeDict = new();
            _zombieToggle = false;
            _keytypeDict.Add(KeyCode.Num1Key,() => this.SpawnZombie(0));
            _keytypeDict.Add(KeyCode.Num2Key, () => this.SpawnZombie(1));
            _keytypeDict.Add(KeyCode.Num3Key, () => this.SpawnZombie(2));
            _keytypeDict.Add(KeyCode.Num4Key, () => this.SpawnZombie(3));
            _keytypeDict.Add(KeyCode.TabKey, () => this.ToggleZombie());
            _keytypeDict.Add(KeyCode.Num5Key, () => this.MakeMoney());
            _keytypeDict.Add(KeyCode.Num6Key, () => this.CreateSun());
            _keytypeDict.Add(KeyCode.SpaceKey, () => this.FastForward());
        }
        /// <summary>
        /// Updates the Debug controller. Loops through all valid keycodes and invokes the delegate attached
        /// </summary>
        public void Update()
        {
            foreach(KeyValuePair<KeyCode, Action> kvp in _keytypeDict)
            {
                if (SplashKit.KeyTyped(kvp.Key))
                {
                    kvp.Value.Invoke();
                }
            }
        }
        /// <summary>
        /// Force Spawns Zombie at Required Lane
        /// </summary>
        /// <param name="lane">Lane that Zobmie is to be Spawned</param>
        private void SpawnZombie(int lane)
        {
            if (_zombieToggle)
            {
                EntityFactory.SpawnZombie<StandardZombie>(EntityRepository.GetInstance().RowAt(lane));
                Console.WriteLine($"DEBUG: StandardZombie Spawned in Lane: {lane}");
            }
            else
            {
                EntityFactory.SpawnZombie<ConeZombie>(EntityRepository.GetInstance().RowAt(lane));
                Console.WriteLine($"DEBUG: ConeZombie Spawned in Lane: {lane}");
            }
        }
        /// <summary>
        /// Toggles What Zombie Type is to be spawned on a debug force spawn
        /// </summary>
        private void ToggleZombie()
        {
            _zombieToggle = !_zombieToggle;
            if (_zombieToggle)
            {
                Console.WriteLine("DEBUG: Manual Zombie Spawining Will Now Spawn StandardZombies");
            }
            else
            {
                Console.WriteLine("DEBUG: Manual Zombie Spawining Will Now Spawn ConeZombies");
            }
        }
        /// <summary>
        /// Force Adds money to player wallet
        /// </summary>
        private void MakeMoney()
        {
            PlayerData.GetInstance().Money += 100;
            Console.WriteLine("DEBUG: 100 Money Added to Wallet");
        }
        /// <summary>
        /// Skips 100 game ticks
        /// </summary>
        private void FastForward()
        {
            Console.WriteLine("DEBUG: 100 GameTicks Skipped");
            for (int i = 0; i<100; i++)
            {
                EntityUpdater.GetInstance().Update();
                TimeKeeper.GetInstance().Increment();
            }
        }
        private void CreateSun()
        {
            Random rnd = new Random();
            Console.WriteLine("DEBUG: Falling Sun Created");
            Cell c = EntityRepository.GetInstance().GetCell(rnd.Next(4),rnd.Next(9));
            EntityFactory.SpawnSun(c.X,c.Y);
        }
    }
}
