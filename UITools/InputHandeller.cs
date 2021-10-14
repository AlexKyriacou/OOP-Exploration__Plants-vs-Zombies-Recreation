using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace FinalProject
{
    /// <summary>
    /// Input Manager of player inputs. Event based system that tools are able to subscribe to depending on their controls.
    /// Uses Singleton pattern.
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// Delegate method for mouse click methods to be implemented by tools
        /// </summary>
        /// <param name="mouseButton">Splashkit mousebutton enum</param>
        public delegate void OnMouseClicked(MouseButton mouseButton);
        /// <summary>
        /// Mouseclick event caused by player clicking mouse
        /// </summary>
        public event OnMouseClicked eventOnMouseClick;
        /// <summary>
        /// singleton instance of the input manager
        /// </summary>
        private static InputManager _instance;
        /// <summary>
        /// Constructor. Inialises input manager
        /// </summary>
        private InputManager() { }
        /// <summary>
        /// creates new singleton instance of input manager
        /// </summary>
        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new InputManager();
            }
        }
        /// <summary>
        /// returns singleton instance of input manager
        /// </summary>
        /// <returns>returns singleton instance</returns>
        public static InputManager GetInstance() => _instance;
        /// <summary>
        /// Update the input manager.
        /// Checks for mouse input
        /// </summary>
        public void Update()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                eventOnMouseClick(MouseButton.LeftButton);
            }
        }
        /// <summary>
        /// Allows tools and other classes to subscribe to mouse click
        /// </summary>
        /// <param name="handler">function to evoke during mouse click</param>
        public void SubscribeToMouseClickEvent(OnMouseClicked handler) => eventOnMouseClick += handler;
        /// <summary>
        /// Allows tools and other classes to subscribe to mouse click
        /// </summary>
        /// <param name="handler">function to evoke during mouse click</param>
        public void UnsubscribeToMouseClickEvent(OnMouseClicked handler) => eventOnMouseClick -= handler;
    }
}
