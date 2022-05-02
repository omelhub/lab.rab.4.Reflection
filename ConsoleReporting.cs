namespace lab.rab._4.Reflection;

public class ConsoleReporting
{
    private int width = 0;

    public void Parse(List<Object> objects)
    {
        foreach(Object obj in objects)  //Организовать цикл по всем объектам
        {
            Type type = obj.GetType();          //Взять объект из коллекции
            List<string> properties = new();
            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {                                           //Организовать цикл по всем свойствам объекта, вывести название и значение
                bool np = false;
                foreach (var attribute in prop.GetCustomAttributes())
                {
                    if (attribute is NotPrintableAttribute)
                    {                                       //Не выводите свойства, которые содержат атрибут [NotPrintableAttribute].
                        np = true;
                        break;
                    }
                }
                if (!np)
                {
                    width += (prop.Name + ":" + new string(Convert.ToChar(" "), 12 - prop.Name.Length)
                        + prop.GetValue(obj) + new string(Convert.ToChar(" "), 12 - prop.Name.Length)).Length;

                    properties.Add(prop.Name + ":" + new string(Convert.ToChar(" "), 12 - prop.Name.Length)
                        + prop.GetValue(obj) + new string(Convert.ToChar(" "), 12 - prop.Name.Length));
                }
            }

            if (type.GetCustomAttribute(typeof(HorizontalAlignmentAttribute)) != null && properties != null)
            {
                width += 2 * properties.Count;
                PrintHeader(type.Name);                 //Вывести название типа
                for (int i = 0; i < (properties.Count - 1); i++)
                {
                    
                    Console.Write(properties[i] + " |");
                }
                if (properties.Count > 1)
                {
                    Console.WriteLine(" " + properties[properties.Count - 1]);
                }
                    
            }
            else
            {
                if (properties != null)
                {
                    PrintHeader(type.Name);                 //Вывести название типа
                    foreach (var prop in properties)
                    {
                        Console.WriteLine(prop);
                    }
                }
            }
            PrintFooter();
            Console.WriteLine();
            width = 0;
        }
    }
    
    /// <summary>
    /// Печатает заголовок()
    /// </summary>
    /// <param name="head">Заголовок</param>
    public void PrintHeader(string head)
    {
        if (width <= head.Length)
        {
            Console.WriteLine(head);
            width = head.Length;
            return;
        }
        if ((width - head.Length) % 2 != 0)
            width += 1;
        int space = (width - head.Length) / 2;
        Console.WriteLine(new string(Convert.ToChar("="), space) + head + new string(Convert.ToChar("="), space));
    }

    /// <summary>
    /// Печатает нижний контитул таблицы (пунктирную линию)
    /// </summary>
    public void PrintFooter()
    {
        Console.WriteLine(new string(Convert.ToChar("-"), width));
    }
}
