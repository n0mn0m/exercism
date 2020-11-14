using System;
using System.Linq;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask) => _mask = mask;

    public bool IsAllergicTo(Allergen allergen) => IsBitSet(_mask, (int)allergen);

    public Allergen[] List() => Enum.GetValues(typeof(Allergen)).Cast<Allergen>().Where(allergen => IsBitSet(_mask, (int)allergen)).ToArray();

    private static bool IsBitSet(int b, int position) => (b & (1 << position)) != 0;
}
