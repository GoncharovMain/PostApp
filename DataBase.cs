namespace PostApp
{
    public class DataBase
    {
        public List<Person> _persons;
        public DataBase()
        {
            _persons = new List<Person>();
        }
        public DataBase(string src)
        {
            using (StreamReader reader = new StreamReader(src))
            {
                string? line = String.Empty;

                _persons = new List<Person>();

                while ((line = reader?.ReadLine()) != null)
                {
                    _persons.Add(line);
                }
            }
        }

        public void Add(Person person) => _persons.Add(person);

        public void Remove(Person person)
        {
            Console.WriteLine($"Remove: {person}");
            _persons.Remove(person);
        }

        public IEnumerable<Person> Find(string secondName)
        {
            Console.WriteLine($"Find: {secondName}");

            foreach (Person person in _persons)
            {
                if (person.Abbreviation.SecondName == secondName)
                {
                    yield return person;
                }
            }
        }
        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Person person in _persons)
                {
                    writer.WriteLine(person);
                }
            }
        }
        public void Print()
        {
            foreach (Person person in _persons)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
        }

        public void Menu()
        {
            bool menuMode = true;

            string info = "1 - Add person\n2 - Remove person\n3 - Find person\n4 - Print all\n5 - Save database in persons.txt\n6 - Exit";

            while (menuMode)
            {
                Console.WriteLine(info);

                string command = Console.ReadLine() ?? "0";

                switch (command)
                {
                    case "1": Add(Console.ReadLine() ?? String.Empty); break;
                    case "2": Remove(Console.ReadLine() ?? String.Empty); break;
                    case "3": Find(Console.ReadLine() ?? String.Empty).Print(); break;
                    case "4": Print(); break;
                    case "5": Save(Console.ReadLine() ?? "persons.txt"); break;
                    case "6": menuMode = false; break;
                    default: break;
                }
            }
        }
    }
}