package de.swerik.euler._00;

public class Problem0012 {
    public Problem0012() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int divisors = 500;
        long n = 1;
        for (long i = 2; ; i++) {
            n = (i * (i + 1)) / 2;
            double root = Math.sqrt(n);
            int count = (int) root == root ? 1 : 0;
            for (long j = 1; j < root; j++) {
                if (n % j == 0) {
                    count += 2;
                }
            }
            if (count > divisors) {
                result = n;
                break;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
