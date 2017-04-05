namespace Engine.Commands
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
        protected Cmd(T receiver)
        {
            Receiver = receiver;
        }

        protected T Receiver { get; }

        public abstract void Execute(object arg = null);
    }
}