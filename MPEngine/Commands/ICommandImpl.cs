namespace MPEngine.Commands
{
    public abstract class ICommandImpl<T> : ICommand
    {
        protected T Receiver { get; }

        protected ICommandImpl(T receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();
    }
}