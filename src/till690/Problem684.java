package till690;

import java.math.BigInteger;

public class Problem684 {

    public Problem684() {
        long startTime = System.nanoTime();
        BigInteger result = BigInteger.ZERO;

        // Solution:
        long[] fibo = findFibos(90);
        BigInteger lastS = BigInteger.ZERO;
        for (int i = 2; i < 90; i++) {
            lastS = lastS.add(addAllUntilN(fibo[i], i - 1));
            result = result.add(lastS.mod(new BigInteger("1000000007")));
            System.out.println((int) (((double) i - 1) / 89 * 100) + " %");
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result.toString() + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long[] findFibos(int n) {
        long[] result = new long[n];

        result[0] = 1;
        result[1] = 1;
        result[2] = 2;
        for (int i = 3; i < n; i++) {
            result[i] = result[i - 1] + result[i - 2];
        }

        return result;
    }

    private BigInteger findSmallestDigitSum(long n) {
        return new BigInteger(n % 9 + "9".repeat((int) n / 9));
    }

    private BigInteger addAllUntilN(long n, long lastIndex) {
        BigInteger result = BigInteger.ZERO;

        for (long i = lastIndex; i < n; i++) {
            result = result.add(findSmallestDigitSum(i));
        }

        return result;
    }
}
