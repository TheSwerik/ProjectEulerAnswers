package till100;

import java.math.BigInteger;

public class Problem100 {
    public Problem100() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 1000000000000L;
        long b = 15;
        long n = 21;

        while (n < max) {
            //xn+1 = 3 xn + 2 yn - 2
            //yn+1 = 4 xn + 3 yn - 3
            long b1 = 3 * b + 2 * n - 2;
            long n1 = 4 * b + 3 * n - 3;

            b = b1;
            n = n1;
        }
        result = b;

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
