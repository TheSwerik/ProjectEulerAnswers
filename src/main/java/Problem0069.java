import java.text.DecimalFormat;

public class Problem0069 {
    public Problem0069() {
        long startTime = System.nanoTime();
        int result = 0;

        // Solution:
        DecimalFormat format = new DecimalFormat("0.##%");
        double max = 0;
        for (int i = 990990; i > 0; i -= 60060) {
            int count = 0;
            for (int j = 1; j < i; j++) {
                if (this.gcd(i, j) == 1) {
                    count++;
                }
            }
            double f = (double) i / count;
            if (f > max) {
                max = f;
                result = i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private int gcd(int a, int b) {
        int t;
        while (b != 0) {
            t = a;
            a = b;
            b = t % b;
        }
        return a;
    }
}
