package java_.problems1_10;

public class Problem9 {
    public Problem9() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        outer:
        for (int i = 1; i < 500; i++) {
            for (int j = i; j < 500; j++) {
                for (int k = j; k < 500; k++) {
                    if (i * i + j * j == k * k && i + j + k == 1000) {
                        result = i * j * k;
//                        System.out.println(i + " " + j + " " + k);
                        break outer;
                    }
                }
            }
        }
        // was ultra easy (?)
        // 20 or 45 ms
/*
        // Maurice Solution:
        outer:
        for (int i = 1; i < 500; i++) {
            for (int j = i; j < 500; j++) {
                int k = 1000 - i - j;
                if (i * i + j * j == k * k) {
                    result = i * j * k;
//                        System.out.println(i + " " + j + " " + k);
                    break outer;
                }
            }
        }
        // was ultra ultra easy
        */

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
