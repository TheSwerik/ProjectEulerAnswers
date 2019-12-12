package till10;

public class Problem10 {
    public Problem10() {
        long startTime = System.nanoTime();
        long result = 17;

        // Solution:
        outer:
        for (long i = 11; i < 2000000; i += 2) {
            for (long j = 3; j <= Math.sqrt(i); j+=2) {
                if (i % j == 0) {
                    continue outer;
                }
            }
            result += i;
        }

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
