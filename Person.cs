namespace PostApp
{
    public class Person
    {
        public int Id { get; set; }
        public Abbreviation Abbreviation { get; set; }
        public string Post { get; set; }

        private Person(int id)
        {
            Id = id;
            Abbreviation = new Abbreviation();
            Post = String.Empty;
        }

        public Person(int id, string secondName, string firstName, string patronymic, string post)
            : this(id, new Abbreviation(secondName, firstName, patronymic), post) { }
        public Person(int id, Abbreviation abbreviation, string post) : this(id)
        {
            Abbreviation = abbreviation;
            Post = post;
        }

        public Person(string secondName, string firstName, string patronymic, string post)
            : this(new Abbreviation(secondName, firstName, patronymic), post) { }
        public Person(Abbreviation abbreviation, string post) : this(0)
        {
            Abbreviation = abbreviation;
            Post = post;
        }

        public override string ToString() => $"{Id} - {Abbreviation.ToString()} - {Post}";

        public static implicit operator Person(string person)
        {
            string[] data = person.Split('-');

            if (data.Length == 2)
            {
                string abbreviation = data[0].Trim();
                string post = data[1].Trim();

                return new Person(abbreviation, post);
            }

            if (data.Length == 3)
            {
                int id = Convert.ToInt32(data[0].Trim());
                string abbreviation = data[1].Trim();
                string post = data[2].Trim();

                return new Person(id, abbreviation, post);
            }

            throw new Exception($"Does not match signature in \'{person}\'.");
        }

        public static implicit operator string(Person person) => person.ToString();

        public static bool operator ==(Person left, Person right)
        {
            return left.Abbreviation == right.Abbreviation && left.Post == right.Post;
        }

        public static bool operator !=(Person left, Person right) => !(left == right);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return this == (Person)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}