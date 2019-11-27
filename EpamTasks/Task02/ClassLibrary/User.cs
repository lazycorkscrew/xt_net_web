using System;

namespace Task02.ClassLibrary
{
    public class User
    {
        public string Fname { get; private set; }
        public string Lname { get; private set; }
        public string Patronymic { get; private set; }
        public DateTime DateBirth { get; private set; }

        public User(string fname, string lname, string patronymic, DateTime dateBirth)
        {
            Fname = fname;
            Lname = lname;
            Patronymic = patronymic;
            DateBirth = dateBirth;
        }

        public override string ToString()
        {
            return $"{Fname} {Lname} {Patronymic}, дата рождения: {DateBirth.ToLongDateString()}";
        }
    }
}
