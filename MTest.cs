namespace CA230316
{
    internal static class MTest
    {
        internal static List<Person> GetTestList()
            => new()
            {
                new()
                {
                    Id = 1,
                    Name = "Nicole Mahmoud",
                    BirthDate = new(1987, 03, 17),
                    Hobbies = new string[] { "origami", "painting", "horses", },
                    Sex = false,
                },
                new()
                {
                    Id = 2,
                    Name = "Alexandre Jeong-Suk",
                    BirthDate = new(2004, 04, 19),
                    Hobbies = new string[] { "music", "computer games", },
                    Sex = true,
                },
                new()
                {
                    Id = 3,
                    Name = "Violeta Jehohanan",
                    BirthDate = new(1997, 02, 11),
                    Hobbies = new string[] { "fishing", "alcohol", },
                    Sex = false,
                },
                new()
                {
                    Id = 4,
                    Name = "Gherardo Olwyn",
                    BirthDate = new(2013, 05, 23),
                    Hobbies = new string[] { "fishing", "computer games", "horses", },
                    Sex = true,
                },
                new()
                {
                    Id = 5,
                    Name = "Jayendra Tzeruyah",
                    BirthDate = new(1935, 12, 02),
                    Hobbies = new string[] { "take pills", "sleeping", "cooking", },
                    Sex = false,
                },
            };
    }

    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Today.Year - BirthDate.Year;
        public string[] Hobbies { get; set; }
        public bool Sex { get; set; }
    }
}

