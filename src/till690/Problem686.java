package till690;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Collections;

public class Problem686 {

    public Problem686() {
        boolean findIncrements = false;
        long startTime = System.nanoTime();
        long exponent = 0;

        // Solution:
        String pattern = "123";
        long max = 678910;
        long first;
        //find first:
        while (true) {
            BigInteger digit = BigInteger.TWO.pow((int) exponent);
            if (digit.toString().startsWith(pattern)) {
                first = exponent++;
                break;
            }
            exponent++;
        }
        //find increments:
        ArrayList<Long> increments = new ArrayList<>();
        if (findIncrements) {
            long last = 0;
            for (long count = 1; count < max && System.nanoTime() - startTime < 100_000_000; exponent++) {
                BigInteger digit = BigInteger.TWO.pow((int) exponent);
                if (digit.toString().startsWith(pattern)) {
                    count++;
                    Long increment = exponent - last;
                    if (!increments.contains(increment)) {
                        increments.add(increment);
                    }
                    last = exponent;
                }
            }
            Collections.sort(increments);
        } else {
            increments.add(196L);
            increments.add(289L);
            increments.add(379L);
            increments.add(485L);
        }

        //solve:
        exponent = first;

        outer: for (long count = 1; count < max; count++) {
            System.out.printf("%.2f", (float) count / max * 100);
            System.out.println(" %");
            for (int i = 0; ; i++) {
                BigInteger digit = BigInteger.TWO.pow((int) exponent + increments.get(i).intValue());
                if (digit.toString().startsWith(pattern)) {
                    exponent += increments.get(i);
                    continue outer;
                }
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + exponent + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
