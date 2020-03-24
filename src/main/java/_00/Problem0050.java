package _00;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem0050 {
    public Problem0050() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        var primes = primeSieveButFast(1_000_000);
        var maxNumber = 0;
        for (var i = 0; i < primes.length - 1; i++) {
            var count = 1;
            var sum = primes[i];
            while (sum < 1_000_000) sum += primes[i + count++];
            sum -= primes[i + count - 1];

            if (maxNumber < count && Arrays.binarySearch(primes, sum) >= 0) {
                maxNumber = count;
                result = sum;
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
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
