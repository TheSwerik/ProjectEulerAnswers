package java_.problems;

import de.swerik.fraction.Fraction;

public class Problem0044 {

    private Fraction p = new Fraction(1, 6);

    public Problem0044() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        outer:
        for (int i = 1; ; i++) {
            long l1 = i * (3 * i - 1) / 2L;
            for (int j = 1; j < i; j++) {
                long l2 = j * (3 * j - 1) / 2L;
                if (isPartOfFormular(l1 + l2) && isPartOfFormular(l1 - l2)) {
                    result = l1 - l2 > 0 ? l1 - l2 : l2 - l1;
//                    System.out.println(l1 + " at " + i);
//                    System.out.println(l2 + " at " + j);
                    break outer;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean isPartOfFormular(long n) {
        if (n < 0) {
            n = -n;
        }
        return p.add(p.pow2().add(new Fraction(2 * n, 3)).sqrt()).getDenominator() == 1;
    }
}
