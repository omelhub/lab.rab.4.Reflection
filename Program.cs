List<object> people = new()
{
    new Student { Name = "Летов", Age = 100, Scholarship = 18_000, Knowledge = true },
    new Employer { Name = "Аспирити", Adress = "Ладо Кецховелли, 22а"}
};

ConsoleReporting x = new();
x.Parse(people);