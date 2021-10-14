using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Most Basic Plant type. Shoots standard bullets
    /// </summary>
    public class StandardShooter : Plant
    {
        /// <summary>
        /// Last time the plant object shot a bullet
        /// </summary>
        private ulong _timeAtLastShot;
        /// <summary>
        /// Controlls how fast the plants bullets travel
        /// </summary>
        public float FireSpeed { get; private set; }
        /// <summary>
        /// Constructor. Initialises the standard shooter objects fields
        /// </summary>
        /// <param name="x">X Coordinate of Plant</param>
        /// <param name="y">Y Coordinate of Plant</param>
        public StandardShooter(float x, float y) : base(x, y, EntityName.StandardShooter)
        {
            Health = 10;
            FireSpeed = 0.5F;
            _timeAtLastShot = TimeKeeper.GetInstance().Ticks;
            _bitmapHitCoolDown = 0;
        }
        /// <summary>
        /// Updates the plant object.
        /// Decides if the plant object needs to shoot a bullet
        /// </summary>
        public override void Update()
        {
            if (TimeKeeper.GetInstance().Ticks - _timeAtLastShot > 350)
            {
                this.Shoot();
            }
        }
        /// <summary>
        /// Draws Plant Object to screen
        /// </summary>
        public override void Draw()
        {
            if (_bitmapHitCoolDown != 0)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Hit"), X, Y);
                _bitmapHitCoolDown--;
            }
            else
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
            }
        }
        /// <summary>
        /// Shoots a bullet from plant object and resets the shot clock
        /// </summary>
        public void Shoot()
        {
            EntityFactory.SpawnBullet<StandardBullet>(this.X, this.Y, this.FireSpeed);
            _timeAtLastShot = TimeKeeper.GetInstance().Ticks;
        }
        /// <summary>
        /// Implements the collision methods of the plant object
        /// </summary>
        /// <param name="collidedWith">passed the dynamic entity that has collided with the plant object</param>
        public override void OnCollision(DynamicEntity collidedWith)
        {
            if (collidedWith.TryCast<Zombie>(out Zombie z))
            {
                if (z.ReadyToAttack())
                {
                    this.Health -= z.Damage;
                    _bitmapHitCoolDown = 15;
                }
            }
        }
    }
}
