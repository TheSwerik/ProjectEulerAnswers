package java_.problems;

import java.text.DecimalFormat;

public class Problem0069 {
    public Problem0069() {
        long startTime = System.nanoTime();
        double result = 0;

        // Solution:
        DecimalFormat format = new DecimalFormat("0.##%");
        for (int i = 990990; i > 0; i -= 10) {
//            if (i % 1001 == 0)
//                System.out.print("\r" + format.format((double) i / 1_000_000));
            int count = 0;
            for (int j = 1; j < i; j++) {
                if (gcd(i, j) == 1) {
                    count++;
                }
            }
            if ((double) i / count > result) {
                System.out.println(result + "\t<\t" + (double) i / count + "\t|\t" + count + "\tat\t" + i);
                result = (double) i / count;
            }
//            result = Math.max((double) i / count, result);
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private int gcd(int a, int b) {
        int t;
        while (b != 0) {
            t = a;
            a = b;
            b = t % b;
        }
        return a;
    }
}
