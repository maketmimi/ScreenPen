using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenPen.Core
{
    public interface ICanvas : IUndoable, IRedoable
    {
        void SelectCanvasTool(EnCanvasTools ToolToSelect);
        void SetEraserWidth(float NewWidth);
        float GetEraserWidth();
        EnCanvasTools GetSelectedCanvasTool();
        void SetPenWidthTo(float NewWidth);
        float GetPenWidth();
        void SetPenColorTo(Color NewColor);
        Color GetCanvasPenColor();
        void SetNewPen(StrokePen NewPen);
        void SaveCanvas(string FolderPath, ImageFormat ImageType);
        void HideCanvas();
        void ShowCanvas();
        bool IsCanvasVisibile();
        void ResetCanvas();
        void CloseCanvas();
        void ShowMainFormWhenCanvasIsHidden(Form MainForm);
    }
}
