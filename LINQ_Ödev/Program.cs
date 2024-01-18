using ConsoleApp.Data;  // PersonData için
using ConsoleApp.Models; // Person sınıfı için
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = PersonData.GetPeople();

            // Where: Yaşı 30'dan büyük olan kişiler
            var olderThan30 = people.Where(p => p.Age > 30);
            PrintPeople("Yaşı 30'dan büyük olan kişiler:", olderThan30);

            // Select: Kişilerin sadece isimlerini seç
            var names = people.Select(p => p.Name);
            Console.WriteLine("\nKişilerin İsimleri:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            // OrderBy: Yaşa göre sırala
            var sortedByAge = people.OrderBy(p => p.Age);
            PrintPeople("Yaşa göre sıralanmış kişiler:", sortedByAge);

            // GroupBy: Yaşa göre grupla
            var groupedByAge = people.GroupBy(p => p.Age);
            Console.WriteLine("\nYaşa Göre Gruplanmış Kişiler:");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Yaş: {group.Key}");
                foreach (var person in group)
                {
                    Console.WriteLine($"\t{person.Name}");
                }
            }

            // Sum, Average: Toplam ve Ortalama Yaş
            var totalAge = people.Sum(p => p.Age);
            var averageAge = people.Average(p => p.Age);
            Console.WriteLine($"\nToplam Yaş: {totalAge}, Ortalama Yaş: {averageAge}");

            // Min, Max: En küçük ve en büyük yaş
            var minAge = people.Min(p => p.Age);
            var maxAge = people.Max(p => p.Age);
            Console.WriteLine($"En Küçük Yaş: {minAge}, En Büyük Yaş: {maxAge}");

            // FirstOrDefault: İlk 'Ahmet' isimli kişiyi bul
            var firstAhmet = people.FirstOrDefault(p => p.Name == "Ahmet");
            Console.WriteLine($"\nİlk 'Ahmet': {firstAhmet?.Name ?? "Bulunamadı"}");

            // Any: Herhangi bir kişinin 40 yaşından büyük olup olmadığını kontrol et
            var isAnyOver40 = people.Any(p => p.Age > 40);
            Console.WriteLine($"\n40 yaşından büyük herhangi bir kişi var mı? {isAnyOver40}");

            // All: Tüm kişilerin 20 yaşından büyük olup olmadığını kontrol et
            var areAllOver20 = people.All(p => p.Age > 20);
            Console.WriteLine($"Tüm kişiler 20 yaşından büyük mü? {areAllOver20}");

            // Concat: Başka bir liste ile birleştir
            var morePeople = new List<Person> { new Person { Name = "Elif", Age = 22 } };
            var allPeople = people.Concat(morePeople);
            PrintPeople("\nTüm Kişiler:", allPeople);

            // Distinct: Yaşlarına göre farklı olan kişileri seç
            var distinctAges = people.Select(p => p.Age).Distinct();
            Console.WriteLine("\nFarklı Yaşlar:");
            foreach (var age in distinctAges)
            {
                Console.WriteLine(age);
            }

            // Skip, Take: İlk iki kişiyi atla, sonraki iki kişiyi al
            var skipAndTake = people.Skip(2).Take(2);
            PrintPeople("\nİlk iki kişiyi atla, sonraki iki kişiyi al:", skipAndTake);

            // Aggregate: Yaşları topla
            var totalAgeAggregate = people.Aggregate(0, (total, next) => total + next.Age);
            Console.WriteLine($"\nAggregate ile Toplam Yaş: {totalAgeAggregate}");
            
            // ThenBy: Yaşa göre sırala ve sonra isme göre
            var sortedByAgeThenByName = people.OrderBy(p => p.Age).ThenBy(p => p.Name);
            PrintPeople("Yaşa ve ardından isme göre sıralanmış kişiler:", sortedByAgeThenByName);

            // Reverse: Sıralamayı tersine çevir
            var reversedPeople = people.OrderByDescending(p => p.Age).ToList();
            reversedPeople.Reverse();
            PrintPeople("Tersine çevrilmiş sıralama:", reversedPeople);

            // Zip: İki listeyi birleştir
            var morePeopleZip = new List<Person> { new Person { Name = "Kerem", Age = 32 }, new Person { Name = "Zeynep", Age = 29 } };
            var zippedPeople = people.Zip(morePeopleZip, (p1, p2) => $"{p1.Name} & {p2.Name}");
            Console.WriteLine("\nZip ile Birleştirilmiş İsimler:");
            foreach (var name in zippedPeople)
            {
                Console.WriteLine(name);
            }

            // SingleOrDefault: Tek bir öğe döndür (Örnek için uygun bir senaryo olmadığından yorum içinde)
            // var singlePerson = people.SingleOrDefault(p => p.Name == "Ahmet");

            // LastOrDefault: Koşulu karşılayan son öğeyi al
            var lastPersonUnder30 = people.LastOrDefault(p => p.Age < 30);
            Console.WriteLine($"\n30 yaşından küçük son kişi: {lastPersonUnder30?.Name ?? "Bulunamadı"}");

            // TakeWhile: Koşul bozulana kadar al
            var takeWhileUnder40 = people.TakeWhile(p => p.Age < 40).ToList();
            PrintPeople("40 yaşından küçük kişiler (TakeWhile):", takeWhileUnder40);

            // SkipWhile: Koşul bozulana kadar atla
            var skipWhileUnder30 = people.SkipWhile(p => p.Age < 30).ToList();
            PrintPeople("30 yaşından küçükler atlandıktan sonra kalanlar:", skipWhileUnder30);

            // SequenceEqual: İki listeyi karşılaştır
            var isEqual = people.SequenceEqual(morePeople);
            Console.WriteLine($"\nİki liste eşit mi? {isEqual}");
        }

        private static void PrintPeople(string title, IEnumerable<Person> peopleList)
        {
            Console.WriteLine($"\n{title}");
            foreach (var person in peopleList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
