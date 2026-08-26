namespace ScreenPen.Core
{
    public interface IRedoable
    {
        void Redo();
        bool CanRedo();

    }
}
