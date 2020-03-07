import java.math.BigInteger;

public class Problem0704 {
    public Problem0704() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        for (long n = 1; n <= 10000000L; n++) {
            result += this.f(n);
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long f(long n) {
        long result = 0;
        for (int m = 0; m <= n; m++) {
            long g = this.g(n, m);
            if (g > result) {
                result = g;
            }
        }
        return result;
    }

    private long g(long lN, long m) {
        // n over m
        BigInteger n = this.fac(lN, lN - m).divide(this.fac(m));

        // find biggest potenz of 2
        long max = 0;
        BigInteger j = BigInteger.ONE;
        for (long i = 0; j.compareTo(n) < 0; i++, j = j.multiply(BigInteger.TWO)) {
            if (n.mod(j).compareTo(BigInteger.ZERO) != 0) {
                return max;
            }
            max = i;
        }
        return max;
    }

    private BigInteger fac(long n) {
        if (n == 0) return BigInteger.ONE;
        BigInteger bN = new BigInteger(n + "");
        for (long i = n - 1; i > 1; i--) {
            bN = bN.multiply(new BigInteger(i + ""));
        }
        return bN.compareTo(BigInteger.ZERO) > 0 ? bN : BigInteger.ONE;
    }

    private BigInteger fac(long n, long m) {
        if (n == 0) return BigInteger.ONE;
        BigInteger bN = new BigInteger(n + "");
        for (long i = n - 1; i > m; i--) {
            bN = bN.multiply(new BigInteger(i + ""));
        }
        return bN.compareTo(BigInteger.ZERO) > 0 ? bN : BigInteger.ONE;
    }
}
