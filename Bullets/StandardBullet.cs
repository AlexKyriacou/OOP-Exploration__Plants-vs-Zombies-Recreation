using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Most Basic kind of bullet. will be created when plant objects 'shoot'.
    /// </summary>
    public class StandardBullet : Bullet
    {
        /// <summary>
        /// Constructor. Initialises Standard bullet object and sets all fields
        /// </summary>
        /// <param name="x">X Coordinate of Bullet</param>
        /// <param name="y">Y Coordinate of Bullet</param>
        /// <param name="speed">Per-Game-Tick speed of bullet</param>
        public StandardBullet(float x, float y, float speed) : base(x, y, EntityName.StandardBullet, speed)
        {
            ExpiryX = X + 600;
            Damage = 20;
        }
        /// <summary>
        /// Draws bullet object to screen
        /// </summary>
        public override void Draw() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X + 15, Y + 15);
        /// <summary>
        /// Updates bullet objects postiion
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
        /// Implements bullets actions when collided with another relevant game object E.g. Zombies
        /// </summary>
        /// <param name="collidedWith">The dynamic entity that this bullet collided with</param>
        public override void OnCollision(DynamicEntity collidedWith) => this.Dead = true;
    }
}
