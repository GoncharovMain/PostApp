namespace PostApp
{
    public class Person
    {
        public int Id { get; set; }
        public Abbreviation Abbreviation { get; set; }
        public string Post { get; set; }
        public Person(int id, string secondName, string firstName, string patronymic, string post)
            : this(id, new Abbreviation(secondName, firstName, patronymic), post) { }

        public Person(int id, Abbreviation abbreviation, string post)
        {
            Id = id;
            Abbreviation = abbreviation;
            Post = post;
        }

        public override string ToString() => $"{Id} - {Abbreviation.ToString()} - {Post}";

        public static implicit operator Person(string person)
        {
            string[] data = person.Split("-");

            int id = Convert.ToInt32(data[0].Trim());
            string abbreviation = data[1].Trim();
            string post = data[2].Trim();

            return new Person(id, abbreviation, post);
            // int indexHyphen = person.IndexOf("-");

            // if (indexHyphen == -1)
            //     throw new Exception($"Does not match signature in \'{person}\'.");

            // string abbreviation = person.Substring(0, indexHyphen);

            // string post = person.Substring(indexHyphen + 1, person.Length - indexHyphen - 1);

            // return new Person(abbreviation.Trim(), post.Trim());
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