
using System;
using System.Linq;

class Program
{
	static void Main()
	{
		// Q1
		var q1 = Source.ProductList
			.OrderByDescending(p => p.UnitPrice)
			.Take(3);

		foreach (var p in q1)
			Console.WriteLine(p.ProductName);

		Console.WriteLine("*************Q2***************");
		// Q2
		var q2 = Source.ProductList
			.Skip(5)
			.Take(5);

		foreach (var p in q2)
			Console.WriteLine(p.ProductName);
		Console.WriteLine("*************Q3***************");


		// Q3
		var q3 = Source.ProductList
			.OrderBy(p => p.UnitPrice)
			.TakeWhile(p => p.UnitPrice < 25);

		foreach (var p in q3)
			Console.WriteLine(p.ProductName);


		Console.WriteLine("*************Q4***************");


		// Q4
		bool q4 = Source.ProductList
			.Where(p => p.Category == "Seafood")
			.All(p => p.UnitsInStock > 0);

		Console.WriteLine(q4);
		Console.WriteLine("*************Q5***************");


		// Q5
		int[] ids = { 3, 9, 13, 18 };

		bool q5 = ids.Contains(9);

		Console.WriteLine(q5);

		Console.WriteLine("*************Q6***************");

		// Q6
		var q6 = Source.ProductList.GroupBy(p => p.Category);

		foreach (var group in q6)
			Console.WriteLine($"{group.Key}: {group.Count()}");
		Console.WriteLine("*************Q7***************");


		// Q7
		var q7 = Source.ProductList
			.GroupBy(p => p.Category)
			.Select(g => new
			{
				Category = g.Key,
				Products = g.Select(p => p.ProductName)
			});


		foreach (var group in q7)
		{
			Console.WriteLine(group.Category);

			foreach (var name in group.Products)
				Console.WriteLine(name);
		}

		Console.WriteLine("*************Q8***************");

		// Q8
		var q8 = Source.ProductList
			.GroupBy(p => p.Category)
			.Where(g => g.Count() > 3)
			.Select(g => g.Key);

		foreach (var category in q8)
			Console.WriteLine(category);

		Console.WriteLine("*************Q9***************");

		// Q9
		var q9 =
			from c in Source.CustomerList
			group c by c.Country into g
			select new
			{
				Country = g.Key,
				Count = g.Count(),
				TotalOrderValue = g.Sum(c =>
					c.Orders.Sum(o => o.Total))
			};

		foreach (var item in q9)
			Console.WriteLine($"{item.Country} - {item.Count} - {item.TotalOrderValue}");


		Console.WriteLine("*************Q10***************");
		// Q10
		var q10 = Source.ProductList.Sum(p => p.UnitsInStock);

		Console.WriteLine(q10);

		Console.WriteLine("*************Q11***************");

		// Q11
		var q11Min = Source.ProductList.Min(p => p.UnitPrice);
		var q11Max = Source.ProductList.Max(p => p.UnitPrice);

		Console.WriteLine($"Cheapest: {q11Min}");
		Console.WriteLine($"Most Expensive: {q11Max}");
		Console.WriteLine("*************Q12***************");


		// Q12
		var q12 = Source.ProductList
			.Select(p => p.Category)
			.Distinct();

		foreach (var category in q12)
			Console.WriteLine(category);

		Console.WriteLine("*************Q13***************");

		// Q13
		int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
		int[] setB = { 3, 6, 9, 12, 15, 13 };

		var q13 = setA.Except(setB);

		foreach (var id in q13)
			Console.WriteLine(id);

		Console.WriteLine("*************Q14***************");

		// Q14
		string[] list1 = { "Germany", "France", "UK", "Spain" };
		string[] list2 = { "france", "SPAIN", "Italy" };

		var q14 = list1.Except(
			list2,
			StringComparer.OrdinalIgnoreCase
		);

		foreach (var country in q14)
			Console.WriteLine(country);

		Console.WriteLine("*************Q15***************");

		// Q15
		var q15 = Source.ProductList
			.GroupBy(p => p.ProductID)
			.ToDictionary(g => g.Key, g => g.First());

		var product = q15[18];

		Console.WriteLine(product.ProductName);

		Console.WriteLine("*************Q16***************");

		// Q16
		var q16 = Source.ProductList
			.First(p => p.UnitPrice > 50);

		Console.WriteLine(q16.ProductName);

		Console.WriteLine("*************Q17***************");

		// Q17
		var q17 = Source.ProductList
			.FirstOrDefault(p => p.UnitPrice > 500);

		Console.WriteLine(q17?.ProductName ?? "null");

		Console.WriteLine("*************Q18***************");

		// Q18
		var q18 = Enumerable.Range(1, 10)
			.Select(x => 7 * x);

		foreach (var number in q18)
			Console.WriteLine(number);

		Console.WriteLine("*************Q19***************");

		// Q19
		var q19 = Enumerable.Range(1, 30)
			.Where(x => x % 2 == 0);

		foreach (var number in q19)
			Console.WriteLine(number);

		Console.WriteLine("*************Q20***************");


		// Q20
		var q20 = Source.ProductList
			.Take(3)
			.Select(p => p.ProductName)
			.Concat(
				Source.CustomerList
					.Take(3)
					.Select(c => c.CustomerName)
			);

		foreach (var name in q20)
			Console.WriteLine(name);

		Console.WriteLine("*************Q21***************");

		// Q21
		var q21 = Source.ProductList
			.Select(p => p.ProductName)
			.Zip(
				Source.CustomerList.Select(c => c.CustomerName),
				(productName, customerName) =>
					$"{productName} sold to {customerName}"
			);

		foreach (var item in q21)
			Console.WriteLine(item);
	}
}
