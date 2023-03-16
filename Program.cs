using CA230316;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

List<Person> people = MTest.GetTestList();

//sorozatszámítás (összegzés)
int noh = people.Sum(p => p.Hobbies.Length);
Console.WriteLine($"hobbik száma a listában: {noh} db");

//-> átlag
double avg = people.Average(p => p.Age);
Console.WriteLine($"átlagéletkor: {avg}");

//megszámlálás
int non = people.Count(p => p.Age >= 18);
Console.WriteLine($"nagykorúak száma: {non}");

//szélsőérték hely/index/példány
Person lgf = people.MinBy(p => p.Age)!;
Console.WriteLine($"legfiatalabb neve: {lgf.Name}");

//szélsőérték
int lgk = people.Max(p => p.Age);
Console.WriteLine($"legnagyobb kor: {lgk}");

//eldöntés
bool vekn = people.Any(p => p.BirthDate.Year == 2004);
Console.WriteLine($"{(vekn ? "van" : "nincs")} olyan, aki 2004ben született");

//kiv./linker

// -> mindnél a return value: object

//firstOrDef [EZ a LINKER]
// -> HA keresési feltétel legalább egy elemre IGAZ:
//      -> visszaadja a lekisbb indexű, keresésnek megfelelő objektumot
// -> EGYÉBKÉNT
//      -> HA a keresebb obj. VALUE TYPE:
//          -> visszaadja az struct példány ZERO értékét
//      -> HA a keresett obj. REF TYPE:
//          -> null értéket ad vissza

Person alex = people.FirstOrDefault(p => p.Name.ToLower().StartsWith("alex"))!;
Console.WriteLine(alex is null 
    ? "NINCS olyan, akineke a neve alex-el kezdődne" 
    : $"{alex.Name} neve alex-el kezdődik");

//lineáris keresés -> index (példány)
//kiválasztás

//first
// abban különbözik, hogy ha nincs találat a keresésre,
// akkor nem null vagy zero a return, hanem exception

//last && lastOrDef
// találat esetén a legNAGYOBB indexű obj.-t adja vissza

//single
// -> ha a keresési feltétel PONTOSAN egy elemre igaz, akkor visszadja azt az elemet
// -> ha többre is igaz, akkor exception
// -> ha nincs találat, akkor is exception (csak más)
//singleOrDef
// -> ha pont 1 találat van akkor ua. mint a single
// -> ha többre is igaz, akkor is ua. mint single (tehát kivételt dob)
// -> ha egyre sem igaz, akkor vagy null vagy zero


Person ker = people.Find(p => p.Name.Contains("asd"))!;
bool bnv = people.Exists(p => p.Name.Contains("asd"));
int ind = people.IndexOf(lgf);
bool bnv2 = people.Contains(lgf);
Console.WriteLine($"fegfiatalabb indexe: {ind}");

var embrk = new Person[5];
people.CopyTo(0, embrk, 0, 5);

//kiválogatás
IEnumerable<Person> millenials = people.Where(p => p.BirthDate.Year > 2000);
foreach (var p in millenials)
{
    Console.WriteLine($"{p.Name} ({p.BirthDate.Year})");
}

//rendezés(ek)

IOrderedEnumerable<Person> rndztt = people.OrderBy(p => p.Name);
var vszfl = people.OrderByDescending(p => p.Age);

//projekció
IEnumerable<string> nvk = people.Select(p => p.Name);

IEnumerable<string> hbbk = people.SelectMany(p => p.Hobbies);

IEnumerable<string> dhbbk = hbbk.Distinct();

foreach (var h in dhbbk) Console.WriteLine(h);


//"""szétváloggatás"""
IEnumerable<IGrouping<bool, Person>> grp = people.GroupBy(p => p.Sex);

foreach (var igp in grp)
{
    if (igp.Key) Console.WriteLine("fiúk:");
    else Console.WriteLine("lányok:");
    foreach (var p in igp)
    {
        Console.WriteLine($"\t{p.Name}");
    }
}

string lif = people
    .Where(p => p.Sex)
    .MaxBy(p => p.Age)!
    .Name;

var f = new int[] { 3, 4, 5, 5, 6 };

var asd = people.Zip(f).ToDictionary(x => x.Item1, x => x.Item2);

//string fff = "";
//if ((fff = Console.ReadLine()!) == "lófasz")
//{
//}