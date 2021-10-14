using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Plant removal tool. is activated after the shovel has been selected and has concluded once a subsequent mouse click has taken place.
    /// </summary>
    public class TPlantRemoval : ITool
    {
        /// <summary>
        /// activates the plant removal tool and subscribes to the next mouse click
        /// </summary>
        public void ToolActivate() => InputManager.GetInstance().SubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// Deactivates the tool and stops the tool from listenting to future events
        /// </summary>
        public void ToolDeactivate() => InputManager.GetInstance().UnsubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// This tool updates similar to the plant placement tool and has the shovel bitmap hover under the cursor until a choice is made
        /// </summary>
        public void ToolUpdate() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(EntityName.Shovel.ToString()), SplashKit.MouseX(), SplashKit.MouseY() - 100);
        /// <summary>
        /// implements the tools functionality. Unoccupys the cell under the cursor and removes any plants found.
        /// </summary>
        /// <param name="mouseButton">Splashkit mousebutton enum</param>
        private void OnMouseClicked(MouseButton mouseButton)
        {
            Cell c = EntityRepository.GetInstance().CellAt(SplashKit.MouseX(), SplashKit.MouseY());
            List<Plant> plantList = EntityRepository.GetInstance().GetEntityAt<Plant>(SplashKit.MouseX(), SplashKit.MouseY());
            if (c != null && c.Occupied)
            {
                foreach(Plant p in plantList)
                {
                    p.Kill();
                }
                c.Occupied = false;
            }
        }
    }
}
