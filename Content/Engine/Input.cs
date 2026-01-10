using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Honeycomb
{
    public partial class Engine
    {
        public class Input
        {
            public static KeyboardState KeyboardState = Keyboard.GetState();
            //public static GamePadState GamePadState = GamePad.GetState();
            public static MouseState MouseState = Mouse.GetState();

            private static KeyboardState PreviousKeyboardState = Keyboard.GetState();
            private static MouseState PreviousMouseState = Mouse.GetState();
            public static void Update()
            {
                PreviousKeyboardState = KeyboardState;
                PreviousMouseState = MouseState;
                KeyboardState = Keyboard.GetState();
                MouseState = Mouse.GetState();
            }
            public static bool KeyPressed(Keys key)
            {
                return KeyboardState.IsKeyDown(key) && !PreviousKeyboardState.IsKeyDown(key);
            }
            public static bool KeyReleased(Keys key)
            {
                return !KeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyDown(key);
            }
            public static bool KeyDown(Keys key)
            {
                return KeyboardState.IsKeyDown(key);
            }
        }
    }
}