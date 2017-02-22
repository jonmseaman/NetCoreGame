namespace MPEngine.Commands
{
    public interface ICommand
    {
        //Reverted a change that Jon made to make sure that inheritance works properly to ExitGameCommand
        void Execute(object arg = null);
    }

    /// <summary>
    /// Simple implementation of ICommand.
    /// </summary>
    /// <typeparam name="T">Type of Receiver.</typeparam>
    public abstract class Cmd<T> : ICommand
    {
        protected T Receiver { get; }

        protected Cmd(T receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute(object arg = null);
    }
}