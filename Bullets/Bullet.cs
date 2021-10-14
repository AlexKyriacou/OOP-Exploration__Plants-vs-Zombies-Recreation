using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Base Class for all bullet objects
    /// </summary>
    public abstract class Bullet: DynamicEntity
    {
        /// <summary>
        /// Sets how long the bullet will fly before it expries and dies on its own
        /// </summary>
        public float ExpiryX { get; protected set; }
        /// <summary>
        /// Per-Game-Tick speed of bullet
        /// </summary>
        public float Speed { get; protected set; }
        /// <summary>
        /// Damage bullet does to objects
        /// </summary>
        public int Damage { get; protected set; }
        /// <summary>
        /// Manual setting of the bullets dead status. used when the bullet reaches its expiry location
        /// </summary>
        public bool Dead { private get; set; }
        /// <summary>
        /// Constructor. Can be used by child bullets to initialise common fields.
        /// </summary>
        /// <param name="x">X Coordinate of Bullet</param>
        /// <param name="y">Y Coordinate of Bullet</param>
        /// <param name="bitmapName">Enum of Bitmap file name for respective bullet</param>
        /// <param name="speed">Per-Game-Tick speed of bullet</param>
        public Bullet(float x, float y, EntityName bitmapName, float speed) : base(x, y, bitmapName)
        {
            ExpiryX = 1000;
            Dead = false;
            Speed = speed;
            Damage = 1;
        }
        /// <summary>
        /// Bullet will return false if it has reached its expiry locaiton or hit a zombie
        /// </summary>
        /// <returns>Returns boolean dependant on if bullet is has fuffliled a death condition</returns>
        public override bool IsDead() => this.Dead;
    }
}
