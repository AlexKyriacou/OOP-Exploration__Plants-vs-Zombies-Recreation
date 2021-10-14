using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Bullet shot by snow shooter plants. slows zombies on collision
    /// </summary>
    public class SnowBullet : Bullet
    {
        /// <summary>
        /// Constructor. Initialise the bullet objects location and speed
        /// </summary>
        /// <param name="x">X Coordinate of Bullet</param>
        /// <param name="y">Y Coordinate of Bullet</param>
        /// <param name="speed">Per-Game-Tick speed of bullet</param>
        public SnowBullet(float x, float y, float speed) : base(x, y, EntityName.SnowBullet, speed)
        {
            ExpiryX = X + 600;
            Damage = 20;
        }
        /// <summary>
        /// Renders bullet to screen
        /// </summary>
        public override void Draw() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X + 15, Y + 15);
        /// <summary>
        /// Updates bullets location
        /// </summary>
        public override void Update()
        {
            if (X > ExpiryX)
            {
                this.Dead = true;
            }
            X += this.Speed;
        }
        /// <summary>
        /// Implementes the bullets collision functionality. in this case all entites this bullet collides with will kill the entity.
        /// </summary>
        /// <param name="collidedWith">dynamic entity that snow bullet collided with</param>
        public override void OnCollision(DynamicEntity collidedWith) => this.Dead = true;
    }
}
