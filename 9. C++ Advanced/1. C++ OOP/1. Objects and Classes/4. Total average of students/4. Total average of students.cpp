// 4. Total average of students.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Write a program, use a class that has params:
// • Student Name
// • Student Surname
// • Total Average
// The class should have print method that for a given object prints all the information. Create a vector in main() that for a given number(passed thru user) saves the objects Make a function that calculates the Total average of all students. If there are no students, print “Invalid input”.

#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>

#define DIGITS_AFTER_DECIMAL_SEPARATOR 2
#define INITIAL_DOUBLE_VALUE 0.0

//////////////////////////
// CStudent

/// <summary>
/// Class that keep student info
/// </summary>
class CStudent
{
    // Constructor / Destructor
public:

    /// <summary>
    /// Paramtere constructor
    /// </summary>
    /// <param name="strName"> Student name </param>
    /// <param name="strSurname"> Student Surname </param>
    /// <param name="dTotalAverage"> Student total average </param>
    CStudent(const std::string& strName, const std::string strSurname, const double dTotalAverage);

    /// <summary>
    /// Destructor
    /// </summary>
    virtual ~CStudent();

    // Methods
public:

    /// <summary>
    /// With this method we can get all student info as string
    /// </summary>
    /// <returns> Text in format "FirstName LastName TotalAverage" </returns>
    std::string GetInfo() const;

    /// <summary>
    /// Getter to access total average
    /// </summary>
    /// <returns> Total average of student </returns>
    double GetTotalAverage() const;

    // Members
private:

    /// <summary>
    /// Student Name
    /// </summary>
    std::string m_strName;

    /// <summary>
    /// Student Surname
    /// </summary>
    std::string m_strSurname;

    /// <summary>
    /// Student Total average
    /// </summary>
    double m_dTotalAverage;
};

// Constructor / Destructor
CStudent::CStudent(const std::string& strName, const std::string strSurname, const double dTotalAverage)
    : m_strName(strName)
    , m_strSurname(strSurname)
    , m_dTotalAverage(dTotalAverage)
{
}

CStudent::~CStudent()
{
}

// Methods
std::string CStudent::GetInfo() const
{
    std::stringstream ss;  
    ss << std::fixed << std::setprecision(DIGITS_AFTER_DECIMAL_SEPARATOR) << m_dTotalAverage;
    return m_strName + " " + m_strSurname + " " + ss.str();
}

double CStudent::GetTotalAverage() const
{
    return m_dTotalAverage;
}

typedef std::vector<CStudent> Students;

// Main program
int main()
{
    int nStudents;
    std::cin >> nStudents;
    std::cin.ignore();

    Students students;

    std::string strLine;
    for (int i = 0; i < nStudents; i++)
    {
        std::string strStudentName, strStudentSurname;
        double dTotalAverage;

        std::cin >> strStudentName >> strStudentSurname >> dTotalAverage;
        std::cin.ignore();

        students.push_back(CStudent(strStudentName, strStudentSurname, dTotalAverage));
    }

    if (students.empty())
    {
        std::cout << "Invalid input";
        return 0;
    }

    double dTotalAverageOfAllStudents = INITIAL_DOUBLE_VALUE;
    for (CStudent oStudent : students)
    {
        dTotalAverageOfAllStudents += oStudent.GetTotalAverage();
        std::cout << oStudent.GetInfo() << std::endl;
    }

    std::cout << std::fixed << std::setprecision(DIGITS_AFTER_DECIMAL_SEPARATOR);
    std::cout << dTotalAverageOfAllStudents / students.size();
}