// Sec4_Ex_InterviewQuestion.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>

using std::vector;
using std::cout;
using std::endl;

bool containsCommon(vector<char> vec1, vector<char> vec2);

int main()
{
	vector<char> vec1 { 'a', 'b', 'c', 'x'};
	vector<char> vec2 { 'z', 'y', 'i' };
	vector<char> vec3 { 'a', 'b', 'c', 'x' };
	vector<char> vec4 { 'z', 'y', 'x' };

	// false
	bool set1 { containsCommon(vec1, vec2) };
	// true
	bool set2 { containsCommon(vec3, vec4) };

	// using std::boolalpha to print true/false instead of 1/0
	cout << std::boolalpha << set1 << endl;
	cout << std::boolalpha << set2 << endl;

	return 0;
}

// naive approach
bool containsCommon(vector<char> vec1, vector<char> vec2) {
	
	for (int i = 0; i < vec1.size(); i++) {
		for (int j = 0; j < vec2.size(); j++) {
			if (vec1[i] == vec2[j]) {
				return true;
			}
		}
	}
	return false;
}