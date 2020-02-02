package java_.problems;

import java.awt.*;
import java.math.BigInteger;

public class Problem0700 {

    public Problem0700() {
        long startTime = System.nanoTime();
        long result = 1504170715041707L;

        // Solution:
        long mod = 4503599627370517L;
        long low = 1504170715041707L;
        long high = 1504170715041707L;

        while (low > 0) {
            long next = (low + high) % mod;
            if (next < low) {
                low = next;
                result += low;
            } else {
                high = next;
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
