package de.swerik.euler;

public class ProblemTemplate {
    public ProblemTemplate() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
