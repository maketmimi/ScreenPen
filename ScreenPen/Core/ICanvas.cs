using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenPen.Core
{
    public interface ICanvas : IUndoable, IRedoable
    {
        void SetPenWidthTo(float NewWidth);
        void SetPenColorTo(Color NewColor);
        void SetNewPen(Pen NewPen);
        void SaveCanvas(string FolderPath, ImageFormat ImageType);
        void HideCanvas();
        void ShowCanvas();
    }
}
