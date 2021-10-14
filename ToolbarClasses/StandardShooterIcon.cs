using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Icon for standard shooter plant
    /// </summary>
    public class StandardShooterIcon : Icon
    {
        /// <summary>
        /// Plant type of the given icon
        /// </summary>
        private PlantTypes _plantType;
        /// <summary>
        /// Constructor. Intitialises the Standard shooter icon
        /// </summary>
        /// <param name="x">x coordinate of icon</param>
        /// <param name="y">y coordinate of icon</param>
        public StandardShooterIcon(float x, float y) : base(x, y, EntityName.StandardShooterIcon)
        {
            _plantType = PlantTypes.StandardShooter;
        }
        /// <summary>
        /// Implements the Icons onclick functionality.
        /// Sets the current tool to plant placement and subscribes to next mouse click
        /// </summary>
        public override void OnClick()
        {
            ITool tool = ToolManager.GetInstance().SetActiveTool(ToolType.PlantPlacement);
            InputManager.GetInstance().SubscribeToMouseClickEvent(OnMouseClicked);
            (tool as TPlantPlacement).plantType = _plantType;
            Selected = true;
        }
        /// <summary>
        /// Implements mouse click functionality. unsubcribes from mouse click and resets tool to entity selection 
        /// </summary>
        /// <param name="mouseButton">The splashkit mousebutton that was pressed</param>
        private void OnMouseClicked(MouseButton mouseButton)
        {
            Selected = false;
            InputManager.GetInstance().UnsubscribeToMouseClickEvent(OnMouseClicked);
            ToolManager.GetInstance().SetActiveTool(ToolType.EntitySelection);
        }
    }
}
