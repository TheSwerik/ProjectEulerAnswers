import java.util.Arrays;

public class Problem0010 {
    public Problem0010() {
        long startTime = System.nanoTime();
        long result = 17;

//        // Solution:
//        outer:
//        for (long i = 11; i < 2000000; i += 2) {
//            for (long j = 3; j <= (int) Math.sqrt(i); j += 2) {
//                if (i % j == 0) {
//                    continue outer;
//                }
//            }
//            result += i;
//        }

        //better (Maurice):
        result = 0;
        boolean[] bools = new boolean[2000000];
        Arrays.fill(bools, true);

        for (int i = 2; i < bools.length; i++) {
            if (bools[i]) {
                result += i;
                for (int j = i; j < bools.length; j += i) {
                    bools[j] = false;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
