namespace PostApp
{
    public static class ExtentionEnumerable
    {
        public static void Print(this IEnumerable<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            DataBase dataBase = new DataBase("persons.txt");

            dataBase.Add(new Person(0, "Иванов", "Иван", "Иванович", "Сисадмин"));
            dataBase.Add("Иванов Иван Иванович - Разработчик");

            dataBase.Menu();
        }
    }
}