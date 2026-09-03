using System;
using ScreenPen.GUI.Canvasses.FormCanvasses.OverlayCanvas;
using ScreenPen.GUI.Canvasses.FormCanvasses.ScreenShotCanvas;

namespace ScreenPen.Core
{
    public static class Factory
    {
        public enum EnCanvasType
        {
            OverlayCanvas,
            ScreenShotCanvas
            // any other canvas type should go here
        }

        public static ICanvas GetCanvasObject(EnCanvasType CanvasType)
        {
            switch (CanvasType)
            {
                case EnCanvasType.OverlayCanvas:
                    return new FrmOverlayCanvas();
                case EnCanvasType.ScreenShotCanvas:
                    return new FrmScreenshotCanvas();
                default:
                    throw new NotSupportedException($"This type of canvasses is not supported {CanvasType}");
            }
        }


    }
}
