using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Passive plant type that is able to generate its own sun that can be collected by the player on click.
    /// </summary>
    public class Sunflower : Plant, IClickable
    {
        /// <summary>
        /// Boolean dependant on if the plant has reached the criteria for sun creation
        /// </summary>
        private bool _hasSun;
        /// <summary>
        /// The suns monetary value to be added to player wallet on click
        /// </summary>
        private int _sunValue;
        /// <summary>
        /// The last game tick that the plant produced sun
        /// </summary>
        private ulong _timeAtLastCashout;
        /// <summary>
        /// Constructor. Intialises the sunflower's heath location and sun information
        /// </summary>
        /// <param name="x">x coordinate of sunflower</param>
        /// <param name="y">y coordinate of sunflower</param>
        public Sunflower(float x, float y) : base(x, y, EntityName.Sunflower)
        {
            Health = 10;
            _hasSun = false;
            _sunValue = 20;
            _bitmapHitCoolDown = 0;
            _timeAtLastCashout = TimeKeeper.GetInstance().Ticks;
        }
        /// <summary>
        /// Renders the sunflower object to the screen
        /// </summary>
        public override void Draw()
        {
            if (_bitmapHitCoolDown != 0)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Hit"), X, Y);
                _bitmapHitCoolDown--;
            }
            else if (_hasSun)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString() + "Sun"), X, Y);
            }
            else
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
            }
        }
        /// <summary>
        /// returns. Boolean of if the sunflower is found at a given coordinate 
        /// </summary>
        /// <param name="x">x coordinate in question</param>
        /// <param name="y">y coordinate in question</param>
        /// <returns>returns 1 if found at coordinate and 0 if not</returns>
        public bool IsAt(float x, float y) => (y <= (Y + SplashKit.BitmapNamed(this.EntityName.ToString()).Height) && y >= Y && x <= (X + SplashKit.BitmapNamed(this.EntityName.ToString()).Width) && x >= X);
        /// <summary>
        /// Implements sunflower click functionality. On a click it removes any sun and adds its value to the players wallet
        /// </summary>
        public void OnClick()
        {
            _hasSun = false;
            PlayerData.GetInstance().Money += _sunValue;
        }
        /// <summary>
        /// Implements the sunflowers on collision functionality. When found to collide with a zombie it takes damage and sets off the damaged bitmap
        /// </summary>
        /// <param name="collidedWith">dynamic entity sunflower collided with</param>
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
        /// <summary>
        /// Updates sunflower state. checks if it has reached sun generation criteria
        /// </summary>
        public override void Update()
        {
            if (TimeKeeper.GetInstance().Ticks - _timeAtLastCashout > 4000)
            {
                _hasSun = true;
                _timeAtLastCashout = TimeKeeper.GetInstance().Ticks;
            }
        }
    }
}
