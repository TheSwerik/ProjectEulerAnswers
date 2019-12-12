package till10;

public class Problem9 {
    public Problem9() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        outer:
        for (int i = 0; i < 500; i++) {
            for (int j = 0; j < 500; j++) {
                for (int k = 0; k < 500; k++) {
                    if (i * i + j * j == k * k && i + j + k == 1000) {
                        result = i * j * k;
                        break outer;
                    }
                }
            }
        }
        // was ultra easy (?)
        //  20 or 45 ms

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
