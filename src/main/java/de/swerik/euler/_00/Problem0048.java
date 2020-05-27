package de.swerik.euler._00;

import java.math.BigInteger;

public class Problem0048 {
    public Problem0048() {
        long startTime = System.nanoTime();
        BigInteger result = BigInteger.ZERO;

        // Solution:
        for (int i = 1; i < 1000; i++) result = result.add(new BigInteger(i + "").pow(i));


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result.toString().substring(result.toString().length() - 10) + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
