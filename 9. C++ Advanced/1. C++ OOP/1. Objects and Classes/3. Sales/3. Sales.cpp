// 3. Sales.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Write a class Sale holding the following data: town, product, price, quantity. Read a list of sales and calculate and print the total sales by the town as shown in the output.Order the towns alphabetically in the output.


#include <iostream>
#include <string>
#include <sstream>
#include <map>
#include <iomanip>

#define DIGITS_AFTER_DECIMAL_SEPARATOR 2
#define INITAL_TOTAL_PRICE 0.0

////////////////////////
// CSale

/// <summary>
/// Class which keep and operate with City and total price
/// </summary>
class CSale
{
	// Construcotr / Destructor
public:

	/// <summary>
	/// Prameter constructor
	/// </summary>
	/// <param name="strCity"> Name of city </param>
	/// <param name="dPrice"> Initial city Price </param>
	CSale(const std::string strCity, const double dPrice);

	virtual ~CSale();

	// Methods
public:

	/// <summary>
	/// Getter to return city name
	/// </summary>
	/// <returns> Cyti name </returns>
	std::string GetCity() const;

	/// <summary>
	/// Getter for price
	/// </summary>
	/// <returns> Total price </returns>
	double GetTotalPrice() const;

	/// <summary>
	/// Setter that increase total price
	/// </summary>
	/// <param name="dPrice"> New value to add </param>
	void IncreaseTotalPrice(const double dPrice);

	// Members
private:

	/// <summary>
	/// City name
	/// </summary>
	const std::string m_strCity;

	/// <summary>
	/// Total price
	/// </summary>
	double m_dTotalPrice;
};

// Construcotr / Destructor
CSale::CSale(const std::string strCity, const double dPrice)
	: m_dTotalPrice(dPrice)
	, m_strCity(strCity)
{
}

CSale::~CSale()
{
}

// Methods
std::string CSale::GetCity() const
{
	return m_strCity;
}

double CSale::GetTotalPrice() const
{
	return m_dTotalPrice;
}

void CSale::IncreaseTotalPrice(const double dPrice)
{
	m_dTotalPrice += dPrice;
}

typedef std::map<std::string, CSale> SalesMap;


// Main program
int main()
{
	SalesMap salesMap;

	int n;
	std::cin >> n;
	std::cin.ignore();

	// Add values to SalseMap
	for (int i = 0; i < n; i++)
	{
		std::string strLine, strCity, strProduct;
		double nQuntity, dPrice, dTotalPrice;

		std::getline(std::cin, strLine);
		std::istringstream iss(strLine);

		iss >> strCity >> strProduct >> dPrice >> nQuntity;
		dTotalPrice = dPrice * nQuntity;

		CSale& oSale = salesMap.try_emplace(strCity, CSale{ strCity, INITAL_TOTAL_PRICE }).first->second;
		oSale.IncreaseTotalPrice(dPrice * nQuntity);
	}

	// Set max digit after decimal separator
	std::cout << std::fixed << std::setprecision(DIGITS_AFTER_DECIMAL_SEPARATOR);

	// Print total price for each city
	for (const auto& kvp : salesMap)
	{
		std::cout << kvp.first << " -> " << kvp.second.GetTotalPrice() << std::endl;
	}
}