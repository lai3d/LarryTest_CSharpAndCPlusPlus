// CPlusPlus_01_SteamBasedIO.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <string>
#include <sstream>
#include <cctype>

#include <regex> // for regex_match

bool isInteger(std::string const& n) noexcept
{
	if (std::isdigit(n[0]) || (n.size() > 1 && (n[0] == '-' || n[0] == '+')))
	{
		for (std::string::size_type i{ 1 }; i < n.size(); ++i)
			if (!std::isdigit(n[i]))
				return false;

		return true;
	}
	return false;
}

bool isIntegerWithRegex(const std::string &num) {
	return std::regex_match(num, std::regex("[+-]?[0-9]+"));
}

int main()
{
    std::cout << "Hello World!\n"; 

	std::cout << "Please input 10 numbers:\n";

	const int max = 10;
	int numbers[max] = {0};
	//int input = 0;
	std::string strInput;

	int i = 0;

	while (i < 10) {
		//std::cin >> input;

		std::getline(std::cin, strInput);

		if (isInteger(strInput)) {
			//continue;
			std::stringstream strStream(strInput);
			strStream >> numbers[i];

			++i;
		} else {
			std::cout << "Please enter a valid integer" << std::endl;
			//std::cin.clear();
			//std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		}
	}
}



// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
