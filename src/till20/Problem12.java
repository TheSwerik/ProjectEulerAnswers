package till20;

public class Problem12 {
    public Problem12() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int divisors = 500;
        long n = 1;
        for (long i = 2; ; i++) {
            n += i;
            double root = Math.sqrt(n);
            int count = (int) root == root ? 1 : 0;
            for (long j = 1; j < root; j++) {
                if (n % j == 0) {
                    count += 2;
                }
            }
            if (count > 500) {
                result = n;
                break;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
