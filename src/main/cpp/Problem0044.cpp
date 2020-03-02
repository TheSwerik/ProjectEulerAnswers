#include <iostream>
#include <chrono>
#include <cmath>


bool isPartOfFormular(long n) {
    if (n < 0) {
        n = -n;
    }
    long long int r = 1;
    for (long long int i = 1; r <= n; i++) {
        r = i * (3 * i - 1) / 2L;
        if (r == n) {
            return true;
        }
    }
    return false;
}

int main() {
    //Start time
    long long int result = 0;
    std::chrono::high_resolution_clock::time_point start = std::chrono::high_resolution_clock::now();

    //solve:
    const long max = 3600000;
    for (long long int i = 1; i < max; i++) {
        long long int l1 = i * (3 * i - 1) / 2L;
        for (long long int j = 1; j <= i; j++) {
            long long int l2 = j * (3 * j - 1) / 2L;
            if (isPartOfFormular(l1 + l2) && isPartOfFormular(l1 - l2)) {
                result = l1 - l2 > 0 ? l1 - l2 : l2 - l1;
//                std::cout << l1 << "\t" << l2 << std::endl;
//                std::cout << i << "\t" << j << std::endl;
                goto finish;
            }
        }
    }


    finish:
    {
    };

    //Stop time and print
    std::chrono::high_resolution_clock::time_point end = std::chrono::high_resolution_clock::now();
    double long elapsedTime = (double long) std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count() /1000000; //<- nanoseconds to microseconds
	std::cout << "Result:\t" << result
		<< "\tTime:\t" <<(elapsedTime > 1000 ? elapsedTime / 1000 : elapsedTime)
		<< (elapsedTime > 1000 ? "s" : "ms") << std::endl;

    return 0;
}
