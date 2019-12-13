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
        for (int i = 2; i <= 40; i++) {
            n = n.multiply(new BigInteger(i + ""));
        }
        for (int i = 2; i <= 20; i++) {
            k = k.multiply(new BigInteger(i + ""));
        }
        n = n.divide(k.multiply(k));

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + n + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
