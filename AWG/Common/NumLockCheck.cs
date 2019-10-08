using System.Runtime.InteropServices;

namespace SpecialKeysCheck
{
    /// <summary>
    /// This class checks if NumLock is curently pressed/toggled on.
    /// </summary>
    class NumLockCheck
    {
        [DllImport("user32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        // Unkown 01/01
        /// <summary>
        /// Checks if the key is pressed/toggled on
        /// </summary>
        /// <param name="testKey">The key state of the key we are checking</param>
        /// <returns>False if it is not pressed/toggled, true otherwise</returns>
        public static bool IsKeyPressed(VirtualKeyStates testKey)
        {
            bool keyPressed = false;
            short result = GetKeyState(testKey);

            switch (result)
            {
                case 0:
                    // Not pressed and not toggled on.
                    keyPressed = false;
                    break;

               
                default:
                    // Pressed (and may be toggled on)
                    keyPressed = true;
                    break;
            }

            return keyPressed;
        }

        public enum VirtualKeyStates : int
        {
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_NUMLOCk = 0x90
        }
    }
}
