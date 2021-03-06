package de.swerik.euler._00;

public class Problem0040 {
    public Problem0040() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        String concatenated = this.concatenate(1_000_000);
        int n = 1;
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
        for (int i = 1; result.length() <= n + 1; i++) {
            result.append(i);
        }
        return result.toString();
    }
}
