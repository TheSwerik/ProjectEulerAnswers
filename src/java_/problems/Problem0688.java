package java_.problems;

import java.math.BigInteger;

public class Problem0688 {
    public Problem0688() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 10_000_000_000_000_000L;
        for (long n = 1; n <= 200; n++) {
            // Theory:
//            result += f(n) * (max - n + 1) % 1_000_000_007;
            result += F(n);
            if (((double) n / max * 100) > 0.000001)
                System.out.println(((double) n / max * 100) + "%");
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long F(long n) {
        long result = 0;

        for (int k = 1; k <= n; k++) {
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

    private long smallestPossible(long k) {
        return (k * k + k) / 2; // gaußsche summenformel
    }
}
