using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// enumeration of all bitmap names used in the game.
    /// The order of the enum determines the order entities are rendered.
    /// Negative values are entities and positive/zero values are dynamic entities
    /// </summary>
    public enum EntityName
    {
        Toolbar = -8,
        WallnutIcon = -7,
        SunflowerIcon = -6,
        StandardShooterIcon = -5,
        SnowShooterIcon = -4,
        ShovelIcon = -3,
        Shovel = -2,
        Grass = -1,
        StandardShooter,
        SnowShooter,
        Sunflower,
        Wallnut,
        Sun,
        StandardBullet,
        SnowBullet,
        Lawnmower,
        StandardZombie,
        ConeZombie
    }
}
