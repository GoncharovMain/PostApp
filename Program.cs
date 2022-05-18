namespace PostApp
{
    public class Program
    {
        public static void Main()
        {
            DataBase dataBase = new DataBase("persons.txt");

            //dataBase.Add(new Person("Иванов", "Иван", "Иванович", "Сисадмин"));
            dataBase.Add("Иванов Иван Иванович - Разработчик");

            dataBase.Menu();
        }
    }
}