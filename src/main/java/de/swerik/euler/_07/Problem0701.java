package de.swerik.euler._07;

public class Problem0701 {
    public Problem0701() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        result += 49;
        for (int i = 0; i < 49; i++) {
            for (int j = 0; j < 48; j++) {
                if (i != j && i != j + 1 && i != j - 1 && i != j % 7) {
                    result++;
                }
            }
        }
        result /= 2401;

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
