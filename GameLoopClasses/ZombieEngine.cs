using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Zombie Engine operates the automated spawning of zombies within the game
    /// </summary>
    public class ZombieEngine
    {
        /// <summary>
        /// Controls the random number chosen, dictating the gap between zombie spawns
        /// </summary>
        private Random rnd = new Random();
        /// <summary>
        /// Time at last zombie spawn
        /// </summary>
        private ulong _lastZombieTime;
        /// <summary>
        /// Current delay time between zombie spawns
        /// </summary>
        private double _currentZombieDelay;
        /// <summary>
        /// Current zombie round
        /// </summary>
        private int _round;
        /// <summary>
        /// Constructor. Initialises the first zombie delay
        /// </summary>
        public ZombieEngine()
        {
            _lastZombieTime = TimeKeeper.GetInstance().Ticks;
            _currentZombieDelay = 10000;
            _round = 0;
        }
        /// <summary>
        /// Creates new zombies on the map. passed a number and will create that many zombies, each in seperate lanes
        /// </summary>
        /// <param name="number">number of zombie to be created (Between 1 and 4)</param>
        private void MakeZombie(int number)
        {
            List<int> possibleNumbers = Enumerable.Range(1, 4).ToList();
            for (int i = 0; i < number; i++)
            {
                int index = rnd.Next(0, possibleNumbers.Count);
                float y = EntityRepository.GetInstance().RowAt(index);
                if (i % 2 == 0 && _round > 10)
                {
                    EntityFactory.SpawnZombie<ConeZombie>(y);
                }
                else
                {
                    EntityFactory.SpawnZombie<StandardZombie>(y);
                }
                possibleNumbers.RemoveAt(index);
            }
        }
        /// <summary>
        /// Updates the zombie engine. checks if criteria is met to create new zombies
        /// </summary>
        public void Update()
        {
            if (TimeKeeper.GetInstance().Ticks - _lastZombieTime > _currentZombieDelay)
            {
                this.MakeZombie(rnd.Next(1,4));
                _currentZombieDelay = rnd.Next(800,8000-_round*200);
                if (_round != 36) //At round 36 the spawn rate stops increasing
                {
                    _round++;
                }
                _lastZombieTime = TimeKeeper.GetInstance().Ticks;
            }
        }
    }
}
