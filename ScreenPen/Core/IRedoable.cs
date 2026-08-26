namespace ScreenPen.Core
{
    internal interface IRedoable
    {
        void Redo();
        bool CanRedo();

    }
}
