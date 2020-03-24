package _06;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Collections;

public class Problem0686 {
    private static final boolean SCALABLE = false;

    public Problem0686() {
        double lowBorder = this.findDecimal(true);
        double highBorder = this.findDecimal(false);
        long startTime = System.nanoTime();
        long exponent = 90;

        // Solution:
        String pattern = "123";
        long max = 678910;
        long[] increments;
        if (SCALABLE) {
            exponent = this.findFirst(pattern);
            increments = this.findIncrements(max, pattern, 100);
        } else {
            increments = new long[]{196, 289, 379, 485};
        }

        outer:
        for (long count = 1; count < max; count++) {
//            System.out.printf("%.2f", (float) count / max * 100);
//            System.out.println(" %");
            for (int i = 0; ; i++) {
                double exp = exponent + increments[i];
                if (exp * Math.log10(2) % 1 >= lowBorder &&
                        exp * Math.log10(2) % 1 <= highBorder) {
                    exponent += increments[i];
                    continue outer;
                }
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + exponent + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long[] findIncrements(long max, String pattern, long maxTimeMS) {
        maxTimeMS *= 1_000_000;
        long startTime = System.nanoTime();
        ArrayList<Long> increments = new ArrayList<>();

        long last = 0;
        for (long exponent = 91; System.nanoTime() - startTime < maxTimeMS; exponent++) {
            BigInteger digit = BigInteger.TWO.pow((int) exponent);
            if (digit.toString().startsWith(pattern)) {
                Long increment = exponent - last;
                if (!increments.contains(increment)) {
                    increments.add(increment);
                }
                last = exponent;
            }
        }
        Collections.sort(increments);

        long[] result = new long[increments.size()];
        for (int i = 0; i < result.length; i++) {
            result[i] = increments.get(i);
        }
        return result;
    }

    private int findFirst(String pattern) {
        for (int i = 1; ; i++) {
            BigInteger digit = BigInteger.TWO.pow(i);
            if (digit.toString().startsWith(pattern)) {
                return i;
            }
        }
    }

    public double findDecimal(boolean low) {
        long l;
        if (low) {
            l = 1_230_000_000_000_000_000L;
        } else {
            l = 1_239_999_999_999_999_999L;
        }
        return (this.log2(l) * Math.log10(2)) % 1;
    }

    private double log2(long l) {
        return Math.log(l) / Math.log(2);
    }
}
