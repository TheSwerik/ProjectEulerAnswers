package java_.till40;

public class Problem39 {
    public Problem39() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int maxSolutions = 0;
        for (int i = 1000; i > 2; i--) {
            int solutions = numberOfSolutions(i);
            if (solutions > maxSolutions) {
                maxSolutions = solutions;
                result = i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private int numberOfSolutions(int n) {
        int result = 0;

        for (int c = n / 2; c > 2; c--) {
            for (int b = c; b > 1; b--) {
                double a = Math.sqrt(c * c - b * b);
                if (a + b + c == n) {
                    result++;
                }
            }
        }

        return result;
    }
}
