namespace DependencyInjectionDemo.Logic;

public class DemoLogic : IDemoLogic
{
    public int Value1 { get; private set; }
    public int Value2 { get; private set; }

    // let create a contructor
    public DemoLogic()
    {
        //the random here gives us a sutor random number
        //it says give me an integer between 1 and a 1001 , it is a 1001 because the top value is exculeeded(1001),
        //meaning we count up to the top value right below the top number that why it count 1 to 1000 (not 1 to 1001).
        //the Next there makes sure that the next random number is not the same random number coming.
        Value1 = Random.Shared.Next(minValue: 1, maxValue: 1001);
        Value2 = Random.Shared.Next(minValue: 1, maxValue: 1001);
        // So with this when ever i instantaite the class i put a value in value 1 and value 2, and it random.
        // They wont be the same value from the last intance i created.

    }

}

