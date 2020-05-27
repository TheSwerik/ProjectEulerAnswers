package de.swerik.euler._00;

import java.math.BigInteger;

public class Problem0015 {
    public Problem0015() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        BigInteger n = BigInteger.ONE;
        BigInteger k = BigInteger.ONE;
        for (int i = 21; i < 40; i++) {
            n = n.multiply(new BigInteger(i + ""));
            k = k.multiply(new BigInteger(i - 20 + ""));
        }
        n = (n.divide(k)).multiply(new BigInteger("2"));

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + n + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
