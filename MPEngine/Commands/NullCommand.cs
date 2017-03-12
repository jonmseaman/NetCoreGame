namespace MPEngine.Commands
{
    public class NullCommand : ICommand
    {
        public void Execute(object arg = null)
        {
        }
    }
}
