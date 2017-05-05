// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

class TestClass
{

};

int main()
{
	TestClass* tc = new TestClass();

	if (NULL == tc)
		std::cout << "NULL" << std::endl;
	else
		std::cout << "not NULL" << std::endl;

    return 0;
}

