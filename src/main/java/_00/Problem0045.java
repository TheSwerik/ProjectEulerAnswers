package _00;

public class Problem0045 {

    public Problem0045() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        outer:
        for (int i = 144; ; i++) {
            long h = i * (2 * i - 2);

            long p = 0;
            for (long j = 165; p != h; j++) {
                p = j / 2 * (3 * j + 1);
                if (p > h) {
                    continue outer;
                }
            }

            long t = 0;
            for (long j = 285; t != h; j++) {
                t = j / 2 * (j + 1);
                if (t > h) {
                    continue outer;
                }
            }
            result = t;
            break;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("\rResult:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
