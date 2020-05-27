package de.swerik.euler._00;

public class Problem0024 {

    private int counter = 0;

    public Problem0024() {
        long startTime = System.nanoTime();
        String result = "";

        // Solution:
        int n = 1000000;
        String[] permutations = new String[n];
        String first = "0123456789";

        this.permute(permutations, "", first);

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + permutations[n - 1] + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private void permute(String[] permutations, String prefix, String s) {
        if (this.counter >= 1000000) {
            return;
        }
        int n = s.length();
        if (n == 0) {
            permutations[this.counter++] = prefix;
        } else {
            for (int i = 0; i < n; i++) {
                this.permute(permutations, prefix + s.charAt(i), s.substring(0, i) + s.substring(i + 1, n));
            }
        }
    }
}
