#include <iostream>
#include <chrono>

int main() {
	//Start time
	long long int result = 0;
	std::chrono::steady_clock::time_point start = std::chrono::steady_clock::now();

	//solve:




	//Stop time and print
	std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();
	double long  elapsedTime = (double long)std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count() / 1000000; //<- nanoseconds to microseconds
	std::cout << "Result:\t" << result << "\tTime:\t" << (elapsedTime > 1000 ? elapsedTime / 1000 : elapsedTime) << std::endl;

	return 0;
}