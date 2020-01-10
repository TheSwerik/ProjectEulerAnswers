package till40;

public class Problem40 {
    public Problem40() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int n = 1;
        String concatenated = concatenate(1_000_000);
        result = concatenated.charAt(n) - 48;
        for (int i = 0; i < 6; i++) {
            n = Integer.parseInt(n + "0");
            result *= concatenated.charAt(n) - 48;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private String concatenate(long n) {
        StringBuilder result = new StringBuilder(".");
        for (int i = 1; i <= n; i++) {
            result.append(i);
        }
        return result.toString();
    }
}
