package java_.problems;

import java.math.BigInteger;

public class Problem0688 {

    BigInteger mod = new BigInteger("1000000007");

    public Problem0688() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long max = 10_000_000_000_000_000L;
//        long gausMax = 4_294_967_295L; // max for long
        long gausMax = findGausMax(10_000_000_000_000_000L); // max for max
        long tempMax = 1_000_000;
        int percent = 0;
        outer:
        for (long n = 1; n <= tempMax; n++) {
            // F(n):
            for (long k = 1; k <= n; k++) {
                if (k > gausMax) {
                    break outer;
                }
                if (n < (k * k + k) / 2) {
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
        result += Long.parseLong((new BigInteger(F(gausMax) + "").multiply(new BigInteger((max - gausMax - 1)+ "")).mod(mod)).toString());


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
        result = ((kB.multiply(kB)).add(kB)).divide(BigInteger.TWO);
        return Long.parseLong(result.toString());
    }

    private long findGausMax(long max) {
        StringBuilder result = new StringBuilder();
        String maxS = max + "";
        outer:
        for (int i = maxS.length() - 2; i >= 0; i--) {
            for (int j = 10; j >= 0; j--) {
                long temp = Long.parseLong(result.toString() + j + "0".repeat(i));

                if (temp > 4_294_967_295L) { // too big for Long
                    continue;
                }

                if (max - gaus(temp) > 0) {
                    result.append(j);
                    continue outer;
                }
            }
        }
        return Long.parseLong(result.toString());
    }
}
