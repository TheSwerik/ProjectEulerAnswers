package till20;

import java.math.BigInteger;
import java.util.ArrayList;

public class Problem15 {
    public Problem15() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        BigInteger n = new BigInteger("1");
        BigInteger k = new BigInteger("1");
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
