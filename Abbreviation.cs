namespace PostApp
{
    public class Abbreviation
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public Abbreviation()
        {
            SecondName = String.Empty;
            FirstName = String.Empty;
            Patronymic = String.Empty;
        }
        public Abbreviation(string secondName, string firstName, string patronymic)
        {
            SecondName = secondName;
            FirstName = firstName;
            Patronymic = patronymic;
        }

        public override string ToString() => $"{SecondName} {FirstName} {Patronymic}";

        public static implicit operator Abbreviation(string abbreviation)
        {
            string[] abbreviations = abbreviation.Split(' ');

            if (abbreviations.Length != 3)
                throw new Exception($"Does not match signature in \'{abbreviation}\'.");

            return new Abbreviation(
                secondName: abbreviations[0],
                firstName: abbreviations[1],
                patronymic: abbreviations[2]);
        }
        public static implicit operator string(Abbreviation abbreviation) => abbreviation.ToString();

        public static bool operator ==(Abbreviation left, Abbreviation right)
        {
            return left.FirstName == right.FirstName &&
                    left.SecondName == right.SecondName &&
                    left.Patronymic == right.Patronymic;
        }

        public static bool operator !=(Abbreviation left, Abbreviation right) => !(left == right);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return this == (Abbreviation)obj;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}