namespace PostApp
{
    public class DataBase
    {
        private int countIds;
        public List<Person> _persons;
        public DataBase()
        {
            _persons = new List<Person>();
            countIds = 0;
        }
        public DataBase(string src, bool ignoreHeader = false)
        {
            using (StreamReader reader = new StreamReader(src))
            {
                string? line = String.Empty;

                _persons = new List<Person>();

                if (ignoreHeader)
                {
                    reader?.ReadLine();
                }

                while ((line = reader?.ReadLine()) != null)
                {
                    string[] data = line.Split("-");


                    int id = Convert.ToInt32(data[0].Trim());

                    string abbreviation = data[1].Trim();

                    string post = data[2].Trim();

                    Person person = new Person(abbreviation, post);
                    person.Id = id;

                    _persons.Add(person);
                }

                countIds = _persons.Count();
            }
        }

        public void Add(Person person)
        {
            person.Id = countIds;

            countIds++;

            _persons.Add(person);
        }

        public void Remove(int id)
        {
            foreach (Person person in _persons)
            {
                if (person.Id == id)
                {
                    _persons.Remove(person);
                    return;
                }
            }
            Console.WriteLine($"Database have not person with id: {id}");
        }
        public void Remove(Person person)
        {
            Console.WriteLine($"Remove: {person}");
            _persons.Remove(person);
        }
        public Person Find(int id)
        {
            foreach (Person person in _persons)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            throw new Exception($"Database have not person with id: {id}");
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
        public void Save(string path, bool ignoreHeader = false)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                if (ignoreHeader)
                {
                    writer.WriteLine("Id - Abbreviation - Post");
                }

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

            string info = "1 - Add person\n2 - Remove person\n3 - Remove person with id\n4 - Find person\n5 - Print all\n6 - Save database in persons.txt\n7 - Exit";

            while (menuMode)
            {
                Console.WriteLine(info);

                string command = Console.ReadLine() ?? "0";

                switch (command)
                {
                    case "1": Add(Console.ReadLine() ?? String.Empty); break;
                    case "2": Remove(Console.ReadLine() ?? String.Empty); break;
                    case "3": Remove(Convert.ToInt32(Console.ReadLine())); break;
                    case "4": Find(Console.ReadLine() ?? String.Empty).Print(); break;
                    case "5": Print(); break;
                    case "6": Save(Console.ReadLine() ?? "persons.txt"); break;
                    case "7": menuMode = false; break;
                    default: break;
                }
            }
        }
    }
}