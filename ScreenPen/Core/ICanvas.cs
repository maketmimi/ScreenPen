using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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
        bool IsCanvasVisibile();
        void ResetCanvas();
        void CloseCanvas();
        void ShowMainFormWhenCanvasIsHidden(Form MainForm);
    }
}
