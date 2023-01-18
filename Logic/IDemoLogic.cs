namespace DependencyInjectionDemo.Logic;

    public interface IDemoLogic
    {
    // the interface is just a get because it main class is public not private in which we have to set. 
        int Value1 { get; }
        int Value2 { get; }
    }
