#include <iostream>
#include <chrono>
#include <cmath>
#include <regex>
#include <string>

int main() {
    //Start time
    long long int result = 0;
    std::chrono::high_resolution_clock::time_point start = std::chrono::high_resolution_clock::now();

    //solve:
    long long int s = long(sqrt(1020304050607080900.0));
    long long int e = long(sqrt(1929394959697989990.0));
    const std::regex pattern("1.2.3.4.5.6.7.8.9.0");
    for (long long int i = s; i <= e; i += 10) {
        std::string s = std::to_string(i * i);
        if (s.size() != 19) { continue; }
//        if (std::regex_match(std::to_string(i * i), pattern)) {
//            result = i;
//            break;
//        }
        if (s.at(0) == '1' &&
            s.at(2) == '2' &&
            s.at(4) == '3' &&
            s.at(6) == '4' &&
            s.at(8) == '5' &&
            s.at(10) == '6' &&
            s.at(12) == '7' &&
            s.at(14) == '8' &&
            s.at(16) == '9' &&
            s.at(18) == '0') {
            result = i;
            break;
        }
    }

    //Stop time and print
    std::chrono::high_resolution_clock::time_point end = std::chrono::high_resolution_clock::now();
    double long elapsedTime =
            (double long) (std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count()) /
            1000000; //<- nanoseconds to microseconds
    std::cout << "Result:\t" << result
              << "\tTime:\t" << (elapsedTime > 1000 ? elapsedTime / 1000 : elapsedTime)
              << (elapsedTime > 1000 ? "s" : "ms") << std::endl;

    return 0;
}
