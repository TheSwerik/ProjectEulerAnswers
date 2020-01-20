long fibonacci(long n) {
	long a = 0;
	long b = 1;
	for (long i = 0; i < n - 1; i++) {
		long help = b;
		b = a + b;
		a = help;
	}
	return b;
}