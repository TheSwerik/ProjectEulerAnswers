#include <iostream>
#include <chrono>

int main() {
	//Start time
	long long int result = 0;
	std::chrono::high_resolution_clock::time_point start = std::chrono::high_resolution_clock::now();

	//solve:




	//Stop time and print
	std::chrono::high_resolution_clock::time_point end = std::chrono::high_resolution_clock::now();
	double long  elapsedTime = (double long)std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count() / 1000000; //<- nanoseconds to microseconds
	std::cout << "Result:\t" << result
		<< "\tTime:\t" <<(elapsedTime > 1000 ? elapsedTime / 1000 : elapsedTime)
		<< (elapsedTime > 1000 ? "s" : "ms") << std::endl;
	return 0;
}
