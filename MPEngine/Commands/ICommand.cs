namespace MPEngine.Commands
{
    public interface ICommand
    {
        //Reverted a change that Jon made to make sure that inheritance works properly to ExitGameCommand
        void Execute();
    }
}