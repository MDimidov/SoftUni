// 1. Sentence Shifter.cpp : This file contains the 'main' function. Program execution begins and ends there.
//1. Sentence Shifter
//You are given a list of words in one line.On the other line, you are given a simple integer.
//Your role is to shift the words in the sentence according to that integer.
//For an example, if a sentence has 10 words and you receive a shift number 2 - the first word should become the
//third, the second word should become the fourth and so on, ..., the word before the last should become the first
//and the last word should become the second.
//Implement this task with a class that is initialized with a linear container(array, vector, etc.) of words and which has
//a getShiftedSentence() method which returns the words shifted.
//Each word is printed on a different line.

#include <iostream>
#include <vector>
#include <sstream>
#include <string>

/// <summary>
/// Human readable name of given vector
/// </summary>
typedef std::vector<std::string> WordsVector;

///////////////////////////
// CWordVec

/// <summary>
/// Class which operate with input sentance
/// </summary>
class CWordVec
{
    // Constructor / Destructor
public:

    /// <summary>
    /// Default constructor
    /// </summary>
    CWordVec();

    /// <summary>
    /// Parameter constructor to accept sentence
    /// </summary>
    /// <param name="strInput"> Default given sentence </param>
    CWordVec(const std::string& strInput);

    /// <summary>
    /// Default destructor
    /// </summary>
    virtual ~CWordVec();

    // Methods
public:

    /// <summary>
    /// Set vector from a given sentence
    /// </summary>
    /// <param name="strInput"> Given sentence </param>
    void SetVectorFromString(const std::string& strInput);

    /// <summary>
    /// Print result on console
    /// </summary>
    void PrintVectorOnConsole();

    /// <summary>
    /// Reorder words n given times
    /// </summary>
    /// <param name="nShiftCount"> Given times to reorder </param>
    void SetVectorShift(const int nShiftCount);

    // Members
private:

    /// <summary>
    /// Vector who kept sentence
    /// </summary>
    WordsVector wordsVector;
};

// Constructor / Destructor
CWordVec::CWordVec()
{
}

CWordVec::CWordVec(const std::string& strInput)
{
    this->SetVectorFromString(strInput);
}

CWordVec::~CWordVec()
{
}

// Methods
void CWordVec::SetVectorFromString(const std::string& strInput)
{
    std::istringstream iss(strInput);
    std::string strWord;

    while (iss >> strWord)
    {
        wordsVector.push_back(strWord);
    }
}

void CWordVec::PrintVectorOnConsole()
{
    for (auto it = wordsVector.begin(); it != wordsVector.end(); ++it)
    {
        std::cout << *it << std::endl;
    }
}

void CWordVec::SetVectorShift(const int nShiftCount)
{
    for (int nCount = 0; nCount < nShiftCount; nCount++)
    {
        wordsVector.insert(wordsVector.begin(), wordsVector.back());
        wordsVector.pop_back();
    }
}

// Main program
int main()
{
    std::string strInput;
    std::getline(std::cin, strInput);

    int nShiftCount;
    std::cin >> nShiftCount;

    CWordVec oWordVec(strInput);
    oWordVec.SetVectorShift(nShiftCount);
    oWordVec.PrintVectorOnConsole();
}
