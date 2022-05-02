namespace lab.rab._4.Reflection;

public class Student
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public int Scholarship { get; set; }

    [NotPrintable]
    public bool Knowledge { get; set; }

    public void Say() => Console.WriteLine("Есть хочу!");
}
