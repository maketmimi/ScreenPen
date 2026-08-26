namespace ScreenPen.Core
{
    public interface IUndoable
    {
        void Undo();

        bool CanUndo();
    }
}
