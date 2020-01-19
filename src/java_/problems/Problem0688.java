package java_.problems;

import java.math.BigInteger;

public class Problem0688 {
    public Problem0688() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 10_000_000_000_000_000L;
        for (long n = 1; n <= max; n++) {
//            result = result.add(f(n).multiply(new BigInteger((max - n + 1) + ""))).mod(new BigInteger("1000000007"));
            result += F(n);
            if (((double) n / max * 100) > 0.01)
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
            if (n < (k * k + k) / 2)
                continue;
            if (k % 2 == 0) {
                result += (((n - (k / 2)) / k) - (k / 2 - 1)) % 1_000_000_007;
            } else {
                result += (n / k - k / 2) % 1_000_000_007;
            }
            result %= 1_000_000_007;
        }

        return result % 1_000_000_007;
    }

    private long smallestPossible(long k) {
        return (k * k + k) / 2; // gaußsche summenformel
    }
}
