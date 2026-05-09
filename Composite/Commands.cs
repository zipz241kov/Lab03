namespace HTMLCreator;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class AddClassCommand : ICommand
{
    private LightElementNode _node;
    private string _className;

    public AddClassCommand(LightElementNode node, string className)
    {
        _node = node;
        _className = className;
    }

    public void Execute()
    {
        if (!_node.CssClasses.Contains(_className))
            _node.CssClasses.Add(_className);
    }

    public void Undo()
    {
        _node.CssClasses.Remove(_className);
    }
}

public class CommandManager
{
    private Stack<ICommand> _history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLast()
    {
        if (_history.Count > 0)
        {
            var cmd = _history.Pop();
            cmd.Undo();
            Console.WriteLine("Скасовано останню дію.");
        }
    }
}