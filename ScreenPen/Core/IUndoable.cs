namespace ScreenPen.Core
{
    internal interface IUndoable
    {
        void Undo();

        bool CanUndo();
    }
}
