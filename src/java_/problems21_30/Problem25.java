package java_.problems21_30;

import java.math.BigInteger;

public class Problem25 {

    public Problem25() {
        long startTime = System.nanoTime();
        long result = 2;

        // Solution:
        BigInteger number1 = BigInteger.ONE;
        BigInteger number2 = BigInteger.ONE;
        do {
            BigInteger help = number2;
            number2 = number2.add(number1);
            number1 = help;
            result++;
        } while (number2.toString().length() < 1000);

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
