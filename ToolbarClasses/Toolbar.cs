using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Toolbar contains the list of icons at the bottom of the screen that the player interacts with
    /// </summary>
    public class Toolbar : Entity
    {
        /// <summary>
        /// List of icons for the game
        /// </summary>
        private List<Icon> _iconList;
        /// <summary>
        /// Constructor. Initialises the toolbar and icons.
        /// </summary>
        /// <param name="x">x location of toolbar</param>
        /// <param name="y">y location of toolbar</param>
        public Toolbar(float x, float y) : base(x, y, EntityName.Toolbar)
        {
            _iconList = new List<Icon>();
            _iconList.Add(EntityFactory.SpawnIcon<StandardShooterIcon>(X + 5, Y + 15));
            _iconList.Add(EntityFactory.SpawnIcon<SunflowerIcon>(X + 147, Y + 15));
            _iconList.Add(EntityFactory.SpawnIcon<SnowShooterIcon>(X + 289, Y + 15));
            _iconList.Add(EntityFactory.SpawnIcon<WallnutIcon>(X + 431, Y + 15));
            _iconList.Add(EntityFactory.SpawnIcon<ShovelIcon>(X + 573, Y + 15));
        }
        /// <summary>
        /// Icons are responsible for drawing themselves so this isnt necessary
        /// </summary>
        public override void Draw() {  }
    }
}
