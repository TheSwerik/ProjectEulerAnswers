package java_.problems;

import java.math.BigInteger;

public class Problem0688 {

    BigInteger mod = new BigInteger("1000000007");

    public Problem0688() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 10_000_000_000_000_000L;
        long gausMax = 4_294_967_295L;
        long tempMax = 100_000;
        System.out.println(gaus(gausMax + 1));
        System.exit(0);
//        long tempMax = max;
        int percent = 0;
        for (long n = tempMax; n <= tempMax; n++) {

            for (long k = 1; k <= n; k++) {
                if (k > gausMax && n > (k * k + k) / 2) {
                    continue;
                }
                if (k % 2 == 0) {
                    result += (((n - (k / 2)) / k) - (k / 2 - 1)) % 1_000_000_007;
                } else {
                    result += (n / k - k / 2) % 1_000_000_007;
                }
                result %= 1_000_000_007;
            }

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

    private long gaus(long k) {
        BigInteger kB = new BigInteger(k + "");
        BigInteger result = new BigInteger(k + "");
        result = ((kB.multiply(kB)).add(kB)).divide(BigInteger.TWO).mod(mod);
        return Long.parseLong(result.toString());
    }
}
