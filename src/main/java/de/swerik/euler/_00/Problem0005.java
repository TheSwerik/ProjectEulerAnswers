package de.swerik.euler._00;

public class Problem0005 {
    public Problem0005() {
        long startTime = System.nanoTime();
        long result = 1;

//        outer:
//        for (int i = 20; ; i += 20) {
//            for (int j = 1; j < 21; j++) {
//                if (i % j != 0) {
//                    continue outer;
//                }
//            }
//            result = i;
//            break;
//        }

        int[] primes = {3, 5, 7, 11, 13, 17, 19};
        for (int p : primes) {
            result *= p * (20 / p);
        }

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
//        (int n=((double) timeToResolve / 1_000_000))>1000?n:n/1000
    }
}
