// Sec4_Ex_InterviewQuestion.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <unordered_set>

using std::vector;
using std::cout;
using std::endl;

// passing by const reference because it doesn't make a copy and
// we don't need to change any values
bool contains_common(const vector<char> &vec1, const vector<char> &vec2);
bool better_contains_common(const vector<char> &vec1, const vector<char> &vec2);

int main()
{
	vector<char> vec1 { 'a', 'b', 'c', 'x'};
	vector<char> vec2 { 'z', 'y', 'i' };
	vector<char> vec3 { 'a', 'b', 'c', 'x' };
	vector<char> vec4 { 'z', 'y', 'x' };

	bool naive_set1 { contains_common(vec1, vec2) }; // false
	bool naive_set2 { contains_common(vec3, vec4) }; // true
	
	bool better_set1{ better_contains_common(vec1, vec2) };
	bool better_set2{ better_contains_common(vec3, vec4) };

	// using std::boolalpha to print true/false instead of 1/0
	cout << std::boolalpha;
	
	cout << "naive1 = " << naive_set1 << endl;
	cout << "naive2 = " << naive_set2 << "\n" << endl;
	cout << "better1 = " << better_set1 << endl;
	cout << "better2 = " << better_set2 << "\n" << endl;

	return 0;
}

// naive approach
// O(a*b) time complexity
// O(1) space complexity
bool contains_common(const vector<char> &vec1, const vector<char> &vec2) {
	// use of auto is preferred when type is easily identified
	for (auto &chr : vec1) {
		for (auto &c : vec2) {
			if (chr == c) {
				return true;
			}
		}
	}
	return false;
}

bool better_contains_common(const vector<char> &vec1, const vector<char> &vec2) {
	// declaring set to write vector values to for lookup 
	std::unordered_set<char> is_common {};
	
	// loop through set, check for value from vec in set, insert value if doesn't exist
	for (auto &chr : vec1) {
		if (is_common.find(chr) == is_common.end()) {
			is_common.insert(chr);
		}
	}

	// loop through set, check if value in vec2 matches any value in set
	for (auto &chr : vec2) {
		if (is_common.find(chr) != is_common.end()) {
			return true;
		}
	}

	return false;
}

bool cleaner_contain_common(const vector<char>& vec1, const vector<char>& vec2) {

}