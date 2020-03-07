public class Problem0027 {

    public Problem0027() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int nMax = 0;

        for (int a = -1000; a <= 1000; a++) {
            for (int b = -1000; b <= 1000; b++) {
                int n = 0;
                while (this.isPrim(this.formula(a, b, n))) {
                    n++;
                }
                if (n > nMax) {
                    result = a * b;
                    nMax = n;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long formula(long a, long b, long n) {
        return n * n + a * n + b;
    }

    private boolean isPrim(long n) {
        if (n < 2) {
            return false;
        } else if (n == 2 || n == 3) {
            return true;
        }
        if (n % 2 == 0 || n % 3 == 0) {
            return false;
        }
        long root = (long) Math.sqrt(n) + 1;
        for (long i = 6L; i <= root; i += 6) {
            if (n % (i - 1) == 0 || n % (i + 1) == 0) {
                return false;
            }
        }
        return true;
    }
}
