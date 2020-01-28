package java_.problems;

import java.nio.file.ClosedFileSystemException;

public class Problem0699 {
    public Problem0699() {
        long startTime = System.nanoTime();
        long result = 0;
        System.exit(0);
        // Solution:
        long max = 100_000_000_000_000L;
        double maxRoot = Math.sqrt(max);

        long start = 1_000_002;
        long startValue = 26089287;
        result += startValue;                                // because its a sum, I can just start here

        double percent = 0;

        for (long denom = start; denom <= max; denom+=3) {
            double root = Math.sqrt(denom);
            long num = root % 1 == 0 ? (long) root : 0;     // if the root is a whole number, add it too
            for (int i = 1; i < root; i++) {
                if (denom % i == 0) {
                    num += i + denom / i;                   // find the remaining divisors
                }
            }

            result += denomReduced(num, denom);             // reduce the fraction and add the denominator if it's 3^k

            if ((double) denom / max * 100 > percent) {
                System.out.println((percent += 0.000001d) + "%");
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean checkPow3(long denom) {
        long three = 3;
        while (three < denom) {
            if ((three *= 3) == denom) {
                return true;
            }
        }
        return false;
    }

    private long denomReduced(long num, long denom) {
        long gcd = gcd(num, denom);
        if (gcd != 0) {
            num /= gcd;
            denom /= gcd;
        }
        if (denom % 3 != 0 || !checkPow3(denom)) {
            return 0;
        }
        return denom;
    }

    private long gcd(long num, long denom) {
        while (denom != 0) {
            long t = num;
            num = denom;
            denom = t % denom;
        }
        return num;
    }
}
