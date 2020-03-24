package _00;

import java.math.BigInteger;

public class Problem0020 {
    public Problem0020() {
        long startTime = System.nanoTime();
        BigInteger result = BigInteger.ONE;

        // Solution:
        for (int i = 2; i <= 100; i++) {
            result = result.multiply(new BigInteger(i + ""));
        }
        String s = result.toString();
        result = BigInteger.ZERO;
        for (char c : s.toCharArray()) {
            result = result.add(new BigInteger(c - 48 + ""));
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
