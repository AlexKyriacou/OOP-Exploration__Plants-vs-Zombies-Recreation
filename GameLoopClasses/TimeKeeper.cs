using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Controls the time used by entities every game loop time will be incremented by 1.
    /// Uses Singleton Pattern
    /// </summary>
    public class TimeKeeper
    {
        /// <summary>
        /// Singleton instance of timekeeper
        /// </summary>
        private static TimeKeeper _instance;
        /// <summary>
        /// Returns Current Game Ticks
        /// </summary>
        public ulong Ticks { get; private set; }
        /// <summary>
        /// Creates new singleton instance of timekeeper
        /// </summary>
        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new TimeKeeper();
            }
        }
        /// <returns>
        /// Returns singleton instance of the timekeeper
        /// </returns>
        public static TimeKeeper GetInstance() => _instance;
        /// <summary>
        /// Initialises TimeKeeper with game ticks starting from 0
        /// </summary>
        private TimeKeeper() => Ticks = 0;
        /// <summary>
        /// Increments Game Ticks, is called by game engine class
        /// </summary>
        public void Increment() => Ticks++;
    }
}
