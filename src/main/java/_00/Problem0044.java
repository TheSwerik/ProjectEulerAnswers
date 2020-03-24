package _00;

import java.util.Arrays;

public class Problem0044 {

    public Problem0044() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long[] arr = this.fillarr(2500);
        outer:
        for (int i = 1; ; i++) {
            long l1 = arr[i];
            for (int j = 1; j <= i; j++) {
                long l2 = arr[j];
                if (this.isPartOfFormular(arr,l1 + l2) && this.isPartOfFormular(arr,l1 - l2)) {
                    result = l1 - l2 > 0 ? l1 - l2 : l2 - l1;
//                    System.out.println(l1 + " at " + i);
//                    System.out.println(l2 + " at " + j);
                    break outer;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

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
