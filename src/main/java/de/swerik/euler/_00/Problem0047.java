package de.swerik.euler._00;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem0047 {
    private final Integer[] primes;

    public Problem0047() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        this.primes = primeSieveButFast(150_000);
        for (int i = 20; ; i++) {
            if (Arrays.binarySearch(this.primes, i) >= 0) continue;
            if (this.numberOfPrimFactors(new long[]{i, i + 1, i + 2, i + 3})) {
                result = i;
                break;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean numberOfPrimFactors(long[] numbers) {
        for (var j = 0; j < numbers.length; j++) {
            var count = 0;
            var n = numbers[j];
            for (int i = 0; this.primes[i] <= n; i++) {
                if (n % this.primes[i] == 0) count++;

                while (n % this.primes[i] == 0) n /= this.primes[i];
            }

            if (count != 4) return false;
        }

        return true;
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
