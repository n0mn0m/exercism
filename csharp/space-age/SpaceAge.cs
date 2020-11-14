using System;

public class SpaceAge
{
    private const double EarthSecondsPerYear = 31_557_600D;
    private const double MercuryYearsPerEarthYear = 0.2408467;
    private const double VenusYearsPerEarthYear = 0.61519726;
    private const double MarsYearsPerEarthYear = 1.8808158;
    private const double JupiterYearsPerEarthYear = 11.862615;
    private const double SaturnYearsPerEarthYear = 29.447498;
    private const double UranusYearsPerEarthYear = 84.016846;
    private const double NeptuneYearsPerEarthYear = 164.79132;
    
    private double AgeInEarthSeconds { get; }
    public SpaceAge(int seconds) => AgeInEarthSeconds = seconds;

    public double OnEarth() => AgeInEarthSeconds / EarthSecondsPerYear;

    public double OnMercury() => OnEarth() / MercuryYearsPerEarthYear;

    public double OnVenus() => OnEarth() / VenusYearsPerEarthYear;

    public double OnMars() => OnEarth() / MarsYearsPerEarthYear;

    public double OnJupiter() => OnEarth() / JupiterYearsPerEarthYear;

    public double OnSaturn() => OnEarth() / SaturnYearsPerEarthYear;

    public double OnUranus() => OnEarth() / UranusYearsPerEarthYear;

    public double OnNeptune() => OnEarth() / NeptuneYearsPerEarthYear;
}