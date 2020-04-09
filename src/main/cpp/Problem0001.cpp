#include <iostream>
#include <chrono>

int main() {
	//Start time
	long long int result = 0;
	std::chrono::high_resolution_clock::time_point start = std::chrono::high_resolution_clock::now();

	//solve:
	for (int i = 3; i < 1000; i++) {
		if (i % 3 == 0 || i % 5 == 0) {
			result += i;
		}
	}

	//Stop time and print
	std::chrono::high_resolution_clock::time_point end = std::chrono::high_resolution_clock::now();
	double long elapsedTime = (double long)(std::chrono::duration_cast<std::chrono::nanoseconds>(end - start).count()) / 1000000; //<- nanoseconds to microseconds
	std::cout << "Result:\t" << result
		<< "\tTime:\t" <<(elapsedTime > 1000 ? elapsedTime / 1000 : elapsedTime)
		<< (elapsedTime > 1000 ? "s" : "ms") << std::endl;

	return 0;
}

/*
Leonhard Euler (/ˈɔɪlər/ OY-lər;[2] German: [ˈɔʏlɐ] (About this soundlisten)[3]; 15 April 1707 – 18 September 1783)
was a Swiss mathematician, physicist, astronomer, geographer, logician and engineer who made important and
influential discoveries in many branches of mathematics, such as infinitesimal calculus and graph theory,
while also making pioneering contributions to several branches such as topology and analytic number theory. He also
introduced much of the modern mathematical terminology and notation, particularly for mathematical analysis,
such as the notion of a mathematical function.[4] He is also known for his work in mechanics, fluid dynamics,
optics, astronomy and music theory.[5] Euler was one of the most eminent mathematicians of the 18th century and is
held to be one of the greatest in history. He is also widely considered to be the most prolific, as his collected
works fill 92 volumes,[6] more than anyone else in the field. He spent most of his adult life in Saint Petersburg,
Russia, and in Berlin, then the capital of Prussia. A statement attributed to Pierre-Simon Laplace expresses
Euler's influence on mathematics: "Read Euler, read Euler, he is the master of us all." Early life Leonhard Euler
was born on 15 April 1707, in Basel, Switzerland, to Paul III Euler, a pastor of the Reformed Church,
and Marguerite née Brucker, a pastor's daughter. He had two younger sisters, Anna Maria and Maria Magdalena,
and a younger brother, Johann Heinrich.[9] Soon after the birth of Leonhard, the Eulers moved from Basel to the
town of Riehen, where Leonhard spent most of his childhood. Paul was a friend of the Bernoulli family; Johann
Bernoulli, then regarded as Europe's foremost mathematician, would eventually be the most important influence on
young Leonhard.
*/
