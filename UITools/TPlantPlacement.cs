using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Plant placement tool. is activated after the player clicks on a plant icon and lets the user put plants on the game map.
    /// </summary>
    public class TPlantPlacement : ITool
    {
        /// <summary>
        /// enum of the plant type that the user clicked on and wants to place down
        /// </summary>
        public PlantTypes plantType;
        /// <summary>
        /// activates the plant placement tool and subscribes to the next mouse click
        /// </summary>
        public void ToolActivate() => InputManager.GetInstance().SubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// Deactivates the tool and has the tool stop listening to user input
        /// </summary>
        public void ToolDeactivate() => InputManager.GetInstance().UnsubscribeToMouseClickEvent(OnMouseClicked);
        /// <summary>
        /// when tool is active this tool has the bitmap of the plant that is to be placed hover under the mouse until the user have chosen a final destination for the plant
        /// </summary>
        public void ToolUpdate() => SplashKit.DrawBitmap(SplashKit.BitmapNamed(plantType.ToString()), SplashKit.MouseX() - 50, SplashKit.MouseY() - 50);
        /// <summary>
        /// implementation of game plant placement. This finds the cell under the mouse and checks if its empty and the user has enough money. only then will it allow a new plant to be placed.
        /// </summary>
        /// <param name="mouseButton"></param>
        private void OnMouseClicked(MouseButton mouseButton)
        {
            Cell c = EntityRepository.GetInstance().CellAt(SplashKit.MouseX(), SplashKit.MouseY());
            if (c!=null && !c.Occupied && PlayerData.GetInstance().Money >= ((int)plantType))
            {
                switch (plantType)
                {
                    case PlantTypes.StandardShooter:
                        EntityFactory.SpawnPlant<StandardShooter>(c.X, c.Y);
                        break;
                    case PlantTypes.SnowShooter:
                        EntityFactory.SpawnPlant<SnowShooter>(c.X, c.Y);
                        break;
                    case PlantTypes.Sunflower:
                        EntityFactory.SpawnPlant<Sunflower>(c.X, c.Y);
                        break;
                    case PlantTypes.Wallnut:
                        EntityFactory.SpawnPlant<Wallnut>(c.X, c.Y);
                        break;
                }
                c.Occupied = true;
                PlayerData.GetInstance().Money -= ((int)plantType);
            }
        }
    }
}
