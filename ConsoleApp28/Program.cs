using System.Xml.Serialization;

Person person = new Person("Tom", 37);

// Выполнение сериализации
string xml = SerializeToXml(person);
Console.WriteLine("Сериализованный объект:");
Console.WriteLine(xml);

// Выполнение десериализации
Person deserializedPerson = DeserializeFromXml<Person>(xml);
Console.WriteLine("\nДесериализованный объект:");
Console.WriteLine($"Имя: {deserializedPerson.Name}");
Console.WriteLine($"Возраст: {deserializedPerson.Age}");

static string SerializeToXml<T>(T obj)
{
    XmlSerializer serializer = new XmlSerializer(typeof(Person));

    using (StringWriter writer = new StringWriter())
    {
        serializer.Serialize(writer, obj);
        return writer.ToString();
    }
}

static T DeserializeFromXml<T>(string xml)
{
    XmlSerializer serializer = new XmlSerializer(typeof(Person));

    using (StringReader reader = new StringReader(xml))
    {
        return (T)serializer.Deserialize(reader);
    }
}

//[Serializable]
public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;

    public Person() { }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}