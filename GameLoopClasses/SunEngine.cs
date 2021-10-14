using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Controls the automation of sun creation within the game.
    /// </summary>
    public class SunEngine
    {
        /// <summary>
        /// Controls which cell is chosen at random
        /// </summary>
        private Random rnd = new Random();
        /// <summary>
        /// the Time the last sun fell from the sky
        /// </summary>
        private ulong _lastSunRain;
        /// <summary>
        /// Constructor. Initialises the sun engine, rains sun immediately giving the player a starting money boost.
        /// </summary>
        public SunEngine() 
        {
            _lastSunRain = TimeKeeper.GetInstance().Ticks;
            this.RainSun();
        }
        /// <summary>
        /// Creates a new sun in the game, choosing a random game cell on the map.
        /// </summary>
        private void RainSun()
        {
            Cell c = EntityRepository.GetInstance().GetCell(rnd.Next(4),rnd.Next(9));
            if (!c.Occupied)
            {
                EntityFactory.SpawnSun(c.X,c.Y);
            }
        }
        /// <summary>
        /// Updates the engine, every 10,000 game ticks a new sun will fall
        /// </summary>
        public void Update()
        {
            if(TimeKeeper.GetInstance().Ticks - _lastSunRain > 10000)
            {
                this.RainSun();
                _lastSunRain = TimeKeeper.GetInstance().Ticks;
            }
        }
    }
}
