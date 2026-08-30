using System.Drawing;

namespace ScreenPen.Core
{
    public struct StrokePen
    {
        /*
            maybe we add a new wrapper class to wrap the Pen along side 
            a unique Id that is assigned to each StrokePen Object
            and compare them upon each call for CustomizePenToMatchThisStrokePen()
            so it does not reassign the pen value each time the 
            customization is requested, But I think this is a bad idea 
            unless it is cheaper than repeted Pen update
         
         */


        public Color color { set; get; }
        public float width { set; get; }

        public StrokePen(Color color, float width)
        {
            this.color = color;
            this.width = width;
        }
    
        public void CustomizePenToMatchThisStrokePen(Pen penToCustomize)
        {
            if (penToCustomize == null) return;

            penToCustomize.Color = this.color;
            penToCustomize.Width = this.width;
        }
    }
}
