using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Falling sun from the sky that allows the user to gain a boost of money when clicked.
    /// </summary>
    public class Sun : DynamicEntity, IClickable
    {
        /// <summary>
        /// Final y location of the sun. Lets the class know when to stop moving
        /// </summary>
        private float _endHeight;
        /// <summary>
        /// if the entity has been clicked on then it is marked as dead and removed at the next game loop
        /// </summary>
        private bool _dead;
        /// <summary>
        /// Constructor. initialises the sun to a height above the game screen for it to fall onto the map.
        /// </summary>
        /// <param name="x">x coordinate of sun</param>
        /// <param name="y">y coordinate of sun</param>
        public Sun(float x, float y) : base(x, y, EntityName.Sun)
        {
            Y = y - 800;
            _endHeight = y;
            _dead = false;
        }
        /// <summary>
        /// Renders the sun to the screen
        /// </summary>
        public override void Draw() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.ToString()), X, Y);
        /// <summary>
        /// Boolean retuning if a point is found on sun
        /// </summary>
        /// <param name="x">x coordinate of desired point</param>
        /// <param name="y">y coordinate of desired point</param>
        /// <returns>retruns boolean of if the point is found on the sun</returns>
        public bool IsAt(float x, float y) => (y <= (Y + SplashKit.BitmapNamed(this.EntityName.ToString()).Height) && y >= Y && x <= (X + SplashKit.BitmapNamed(this.EntityName.ToString()).Width) && x >= X);
        /// <summary>
        /// Boolean dependant of if the sun needs to removed on the next game loop
        /// </summary>
        /// <returns>returns boolean on if the sun is dead or not</returns>
        public override bool IsDead() => _dead;
        /// <summary>
        /// Implements the suns click functionality. adds money to players wallet and kills the sun for the next game loop
        /// </summary>
        public void OnClick()
        {
            PlayerData.GetInstance().Money += 25;
            _dead = true;
        }
        /// <summary>
        /// Sun does not collide with any entities
        /// </summary>
        public override void OnCollision(DynamicEntity collidedWith) {  }
        /// <summary>
        /// Updates the suns location. will fall from the sky until it has hit its final chosen cell
        /// </summary>
        public override void Update()
        {
            if (Y < _endHeight)
            {
                Y += 0.5F;
            }
        }
    }
}
