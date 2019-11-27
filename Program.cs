using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var intMonoids = new List<IntegerMonoid>
		{
			new IntegerMonoid(0),
			new IntegerMonoid(1),
			new IntegerMonoid(1),
			new IntegerMonoid(2),
			new IntegerMonoid(3),
			new IntegerMonoid(5)
		};

		Console.WriteLine($"Fold: {FoldableMonoid.Fold(intMonoids)?.Value}");
	}
}

public class IntegerMonoid : Monoid<IntegerMonoid>
{
	public int Value { get; }

	public IntegerMonoid(int value)
	{
		Value = value;
	}

	public IntegerMonoid AssociativeBinaryOperation(IntegerMonoid x)
		=> new IntegerMonoid(Value + x?.Value ?? 0);
}

public interface Monoid<T>
{
	T AssociativeBinaryOperation(T x);
}

public static class FoldableMonoid
{
	public static T Fold<T>(IEnumerable<T> t) where T : Monoid<T>
		=> t.Aggregate(default(T), (x, y) => y.AssociativeBinaryOperation(x));
}
