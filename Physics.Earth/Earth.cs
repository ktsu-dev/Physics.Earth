// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.Physics.Earth;

using ktsu.PhysicalQuantity.Acceleration;
using ktsu.PhysicalQuantity.Density;
using ktsu.PhysicalQuantity.Length;
using ktsu.PhysicalQuantity.Mass;
using ktsu.PhysicalQuantity.Volume;
using ktsu.SignificantNumber;

public static class Earth
{
	public static Acceleration GravityAtSeaLevel => 9.80665.MetersPerSecondSquared();
	public static Length Radius => 6371000.Meters();
	public static Length Circumference => Radius * Math.Tau.ToSignificantNumber();
	public static Length Diameter => Radius * 2.ToSignificantNumber();
	public static Mass Mass => 5.97237e24.Kilograms();
	public static Volume Volume => 1.08321e21.CubicMeters();
	public static Density Density => Mass / Volume;

	public static Acceleration GravityAtAltitude(Length geometricAltitude)
	{
		ArgumentNullException.ThrowIfNull(geometricAltitude);
		var geopotentialAltitude = GeopotentialAltitude(geometricAltitude);
		return GravityAtGeopotentialAltitude(geopotentialAltitude);
	}

	public static Acceleration GravityAtGeopotentialAltitude(Length geopotentialAltitude)
	{
		ArgumentNullException.ThrowIfNull(geopotentialAltitude);
		var reciprocalRelativeAltitude = ReciprocalRelativeAltitude(geopotentialAltitude);
		return GravityAtSeaLevel * reciprocalRelativeAltitude.Pow(2.ToSignificantNumber());
	}

	public static Length GeopotentialAltitude(Length geometricAltitude)
	{
		ArgumentNullException.ThrowIfNull(geometricAltitude);
		var reciprocalRelativeAltitude = ReciprocalRelativeAltitude(geometricAltitude);
		return geometricAltitude * reciprocalRelativeAltitude;
	}

	public static SignificantNumber ReciprocalRelativeAltitude(Length altitude)
	{
		ArgumentNullException.ThrowIfNull(altitude);
		return Radius / (Radius + altitude);
	}
}
