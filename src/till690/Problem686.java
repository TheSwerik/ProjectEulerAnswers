package till690;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Arrays;

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
        ArrayList<char[]> increments = new ArrayList<>();
        if (findIncrements) {
            long last = 0;
            for (long count = 1; count < max && System.nanoTime() - startTime < 100_000_000; exponent++) {
                BigInteger digit = BigInteger.TWO.pow((int) exponent);
                if (digit.toString().startsWith(pattern)) {
                    count++;
                    Long increment = exponent - last;
                    if (!increments.contains(increment)) {
//                        increments.add(increment);
                    }
                    last = exponent;
                }
            }
//            Collections.sort(increments);
        } else {
//            increments.add(196L);
//            increments.add(289L);
//            increments.add(379L);
//            increments.add(485L);
            char[] chars1 = new char[196];
            Arrays.fill(chars1, '0');
            increments.add(chars1);
            char[] chars2 = new char[289];
            Arrays.fill(chars2, '0');
            increments.add(chars2);
            char[] chars3 = new char[379];
            Arrays.fill(chars3, '0');
            increments.add(chars3);
            char[] chars4 = new char[485];
            Arrays.fill(chars4, '0');
            increments.add(chars4);
        }

        //solve:
        exponent = first;

        StringBuilder binaryNumber = new StringBuilder("1");
        char[] chars = new char[90];
        Arrays.fill(chars, '0');
        binaryNumber.append(chars);

        long counterTime = System.nanoTime();
        outer:
        for (long count = 1; count < max; count++) {
            if (System.nanoTime() - counterTime > 1_000_000_000) {
                counterTime = System.nanoTime();
                System.out.printf("%.2f", (float) count / max * 100);
                System.out.println(" %");
            }
            for (int i = 0; ; i++) {
                StringBuilder tempString = new StringBuilder(binaryNumber);
                tempString.append(increments.get(i));
                BigInteger digit = new BigInteger(tempString.toString(), 2);
                if (digit.toString().startsWith(pattern)) {
                    binaryNumber.append(increments.get(i));
                    exponent = binaryNumber.length();
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
