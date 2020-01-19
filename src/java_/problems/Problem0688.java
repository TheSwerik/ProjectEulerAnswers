package java_.problems;

import java.math.BigInteger;

public class Problem0688 {
    public Problem0688() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 10_000_000_000_000_000L;
        long tempMax = 300_000L;
//        long tempMax = max;
        int percent = 0;
        for (long n = 1; n <= tempMax; n++) {
            // Theory:
            result += F(n);

            // percent
            int temp = (int) ((double) n / tempMax * 100);
            if (temp > percent) {
                System.out.println((percent = temp) + "%");
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long F(long n) {
        long result = 0;

        for (long k = 1; k <= n; k++) {
//            long debugLast = result;
            if (n < (k * k + k) / 2)
                continue;
            if (k % 2 == 0) {
                result += (((n - (k / 2)) / k) - (k / 2 - 1)) % 1_000_000_007;
            } else {
                result += (n / k - k / 2) % 1_000_000_007;
            }
            result %= 1_000_000_007;
//            System.out.println("f(" + n + "," + k + ") = " + (result - debugLast));
        }

        return result % 1_000_000_007;
    }
}
