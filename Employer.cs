namespace lab.rab._4.Reflection;

[HorizontalAlignment]
public class Employer
{
    public string? Name { get; set; }
    public string? Adress { get; set; }

    [NotPrintable]
    private int Wage { get; } = 100_000;

    public void Motivate(string name)
    {
        Console.WriteLine($"Солнце еще высоко, иди работай, {name}!");
    }
        
}
