// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.Physics.Earth.Test;

using ktsu.PhysicalQuantity.Acceleration;
using ktsu.PhysicalQuantity.Density;
using ktsu.PhysicalQuantity.Length;
using ktsu.PhysicalQuantity.Mass;
using ktsu.PhysicalQuantity.Volume;
using ktsu.Physics.Earth;
using ktsu.SignificantNumber;

[TestClass]
public class EarthTests
{
	[TestMethod]
	public void TestGravityAtSeaLevel()
	{
		var expected = 9.80665.ToSignificantNumber();
		var actual = Earth.GravityAtSeaLevel.MetersPerSecondSquared<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestRadius()
	{
		var expected = 6371000.ToSignificantNumber();
		var actual = Earth.Radius.Meters<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestCircumference()
	{
		var expected = Math.Tau.ToSignificantNumber() * 6371000.ToSignificantNumber();
		var actual = Earth.Circumference.Meters<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestDiameter()
	{
		var expected = (2 * 6371000).ToSignificantNumber();
		var actual = Earth.Diameter.Meters<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestMass()
	{
		var expected = 5.97237e24.ToSignificantNumber();
		var actual = Earth.Mass.Kilograms<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestVolume()
	{
		var expected = 1.08321e21.ToSignificantNumber();
		var actual = Earth.Volume.CubicMeters<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestDensity()
	{
		var expected = (5.97237e24 / 1.08321e21).ToSignificantNumber();
		var actual = Earth.Density.KilogramsPerCubicMeter<SignificantNumber>();
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestGravityAtAltitude()
	{
		var altitude = 1000.Meters();
		var expected = Earth.GravityAtSeaLevel * (Earth.Radius / (Earth.Radius + altitude)).Pow(2.ToSignificantNumber());
		var actual = Earth.GravityAtAltitude(altitude).MetersPerSecondSquared<SignificantNumber>();
		Assert.AreEqual(expected.MetersPerSecondSquared<SignificantNumber>(), actual);
	}

	[TestMethod]
	public void TestGravityAtGeopotentialAltitude()
	{
		var geopotentialAltitude = 1000.Meters();
		var expected = Earth.GravityAtSeaLevel * (Earth.Radius / (Earth.Radius + geopotentialAltitude)).Pow(2.ToSignificantNumber());
		var actual = Earth.GravityAtGeopotentialAltitude(geopotentialAltitude).MetersPerSecondSquared<SignificantNumber>();
		Assert.AreEqual(expected.MetersPerSecondSquared<SignificantNumber>(), actual);
	}

	[TestMethod]
	public void TestGeopotentialAltitude()
	{
		var geometricAltitude = 1000.Meters();
		var expected = geometricAltitude * (Earth.Radius / (Earth.Radius + geometricAltitude));
		var actual = Earth.GeopotentialAltitude(geometricAltitude).Meters<SignificantNumber>();
		Assert.AreEqual(expected.Meters<SignificantNumber>(), actual);
	}

	[TestMethod]
	public void TestReciprocalRelativeAltitude()
	{
		var altitude = 1000.Meters();
		var expected = Earth.Radius / (Earth.Radius + altitude);
		var actual = Earth.ReciprocalRelativeAltitude(altitude);
		Assert.AreEqual(expected, actual);
	}
}
