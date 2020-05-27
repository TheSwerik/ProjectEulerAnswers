package de.swerik.euler._00;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem0046 {
    private final Integer[] primes;

    public Problem0046() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        this.primes = primeSieveButFast(10_000);

        for (long i = 9; ; i += 2)
            if (this.isComposite(i) && !this.IsGoldbach(i)) {
                result = i;
                break;
            }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean IsGoldbach(long n) {
        for (var i = 0; i < this.primes.length; i++) {
            var p = this.primes[i];
            if (p > (int) n - 2) break;

            for (var j = 1; ; j++) {
                var func = (long) (p + 2 * j * j);
                if (n == func)
                    return true;
                if (n < func) break;
            }
        }

        return false;
    }

    private boolean isComposite(long n) {
        var max = (long) Math.sqrt(n);
        for (long divisor = 2; divisor <= max; divisor++)
            if (n % divisor == 0)
                return true;

        return false;
    }

    public static Integer[] primeSieveButFast(int range) {
        boolean[] bools = new boolean[range + 1];
        Arrays.fill(bools, true);
        double root = Math.sqrt(range) + 0.5;
        for (int i = 3; i < root; i += 2) {
            if (bools[i]) {
                for (int j = i * i; j < range; j += i * 2) {
                    bools[j] = false;
                }
            }
        }
        ArrayList<Integer> primes = new ArrayList<>();
        primes.add(2);
        for (int i = 3; i < range; i += 2) {
            if (bools[i]) {
                primes.add(i);
            }
        }
        return primes.toArray(new Integer[0]);
    }
}
