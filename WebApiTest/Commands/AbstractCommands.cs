namespace WebApiTest.Commands {

    public interface ICommand { }

    public interface IDeleteCommand<T>:ICommand {
        T Id { get; set; }
    }
    public interface ICreateCommand:ICommand { }
    public interface IUpdateCommand<T>:ICommand {
        T Id { get; set; }
    }
}
