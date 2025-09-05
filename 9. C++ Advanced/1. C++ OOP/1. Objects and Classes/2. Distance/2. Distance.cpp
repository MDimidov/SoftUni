// 2. Distance.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Write a program to calculate the (Euclidean) distance between two points p1 {x1, y1} and p2 {x2, y2}. You should write a class to represent such points and a method in it that calculates the distance from the point to another point.

#define POWER_UP_NUM 2
#define DIGITS_AFTER_DECIMAL_SEPARATOR 3
#include <iostream>
#include <iomanip>

///////////////////////////////////
// CPoint

/// <summary>
/// Class point that save and operate with point in coordinate system
/// </summary>
class CPoint
{
	// Constructor / Destructor
public:

	/// <summary>
	/// Parameter constructor
	/// </summary>
	/// <param name="x"> X point position </param>
	/// <param name="y"> Y point position </param>
	CPoint(double x, double y);

	virtual ~CPoint();

	// Methods
public:

	/// <summary>
	/// Calculates the Euclidean distance from the current point to the specified point.
	/// </summary>
	/// <param name="oPoint">The point to which the Euclidean distance is calculated.</param>
	/// <returns>The Euclidean distance between the current point and the specified point.</returns>
	const double GetEuclideanDistanceByGivenOtherPoint(const CPoint& oPoint) const;

	// Members
private:

	/// <summary>
	/// Represents the X coordinate as a double-precision floating-point value.
	/// </summary>
	double m_dX;

	/// <summary>
	/// Represents the Y coordinate as a double-precision floating-point value.
	/// </summary>
	double m_dY;
};


// Constructor / Destructor
CPoint::CPoint(double x, double y)
	: m_dX(x)
	, m_dY(y)
{
}

CPoint::~CPoint()
{
}

// Methods
const double CPoint::GetEuclideanDistanceByGivenOtherPoint(const CPoint& oPoint) const
{
	return std::sqrt(pow(oPoint.m_dX - this->m_dX, POWER_UP_NUM) + pow(oPoint.m_dY - m_dY, POWER_UP_NUM));
}


// Main program
int main()
{
	double dX1, dY1, dX2, dY2;
	std::cin >> dX1 >> dY1 >> dX2 >> dY2;

	CPoint oFirstPoint(dX1, dY1);
	CPoint oSecondPoint(dX2, dY2);

	std::cout << std::fixed << std::setprecision(DIGITS_AFTER_DECIMAL_SEPARATOR);	// Print X more digits after decimal separator
	std::cout << oFirstPoint.GetEuclideanDistanceByGivenOtherPoint(oSecondPoint);	// Print result
}