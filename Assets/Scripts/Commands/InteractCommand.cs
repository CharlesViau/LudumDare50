namespace Commands
{
    public class InteractCommand : ICommand
    {
        private readonly IInteract _person;
        public InteractCommand(IInteract person)
        {
            _person = person;
        }
        public void Execute()
        {
            _person.Interact();
        }
    }
}