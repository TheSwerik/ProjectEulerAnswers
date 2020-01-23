package java_.problems;

import java.util.Arrays;

public class Problem0044 {

    public Problem0044() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long[] arr = fillarr(2500);
        outer:
        for (int i = 1; ; i++) {
            long l1 = arr[i];
            for (int j = 1; j <= i; j++) {
                long l2 = arr[j];
                if (isPartOfFormular(arr,l1 + l2) && isPartOfFormular(arr,l1 - l2)) {
                    result = l1 - l2 > 0 ? l1 - l2 : l2 - l1;
                    System.out.println(l1 + " at " + i);
                    System.out.println(l2 + " at " + j);
                    break outer;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
//    private boolean isPartOfFormular(long n) {
//        if (n < 0) {
//            n = -n;
//        }
//
//        double r = BigDecimal.valueOf(1. / 36. + Math.sqrt(1. / 36. + (2. * n) / 3.))
//                .setScale(3, RoundingMode.HALF_UP)
//                .doubleValue();
//        return r % 1 == 0;
//    }

    private long[] fillarr(int n) {
        long[] arr = new long[n];

        for (int i = 1; i <= n; i++) {
            arr[i - 1] = i * (3 * i - 1) / 2L;
        }

        return arr;
    }

    private boolean isPartOfFormular(long[] pentagonal, long value) {
        return Arrays.binarySearch(pentagonal, value) >= 0;
    }

}
