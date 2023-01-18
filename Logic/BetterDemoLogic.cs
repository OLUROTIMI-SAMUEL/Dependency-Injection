namespace DependencyInjectionDemo.Logic;

    public class BetterDemoLogic :IDemoLogic
    {

        public int Value1 { get; private set; }
        public int Value2 { get; private set; }

        // let create a contructor
        public BetterDemoLogic()
        {
            Value1 = 25;
            Value2 = 50;
        }
    }

