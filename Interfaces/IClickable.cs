using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Interface defining entities that have some interactive capability that can be clicked on
    /// </summary>
    public interface IClickable
    {
        /// <summary>
        /// Implents the functionality of what an entity should do on a click
        /// </summary>
        public void OnClick();
        /// <summary>
        /// Returns boolean depending of if an entity is found at a specific point
        /// </summary>
        /// <param name="x">x coordinate in question</param>
        /// <param name="y">y coordinate in question</param>
        /// <returns>returns boolean of if the entity is at a point</returns>
        public bool IsAt(float x, float y);
    }
}
