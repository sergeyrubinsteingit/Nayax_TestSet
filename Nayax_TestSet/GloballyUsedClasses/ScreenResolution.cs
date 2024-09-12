using System.Drawing;
using System.Collections.Generic;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class ScreenResolution
    {
        public static List<int> DisplayDimensions = new List<int>();
        public static List<int> GetDisplayBounds() {

            Rectangle screenDimensions = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

            DisplayDimensions.Add(screenDimensions.Width);

            DisplayDimensions.Add(screenDimensions.Height);

            return DisplayDimensions;

        }//GetDisplayBounds

    }//ScreenResolution
}
