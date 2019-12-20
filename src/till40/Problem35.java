package till40;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;

public class Problem35 {

    private ArrayList<Integer> primes;

    public Problem35() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        primes = genPrimes(1000000);
        HashSet<Integer> circularPrimes = new HashSet<>();
        for (Integer prime : primes) {
            if (circularPrimes.contains(prime)) continue;
            Integer[] primeSwapped = swapped(prime);

            if (primeSwapped != null) {
                circularPrimes.addAll(Arrays.asList(primeSwapped));
            }
        }
        result = circularPrimes.size();

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private Integer[] swapped(int n) {
        String asString = n + "";

        //Optimized:
        if (n > 10 && (asString.contains("0") || asString.contains("2") || asString.contains("4") || asString.contains("5") || asString.contains("6") || asString.contains("8"))) {
            return null;
        }

        String[] permutations = new String[asString.length()];
        HashSet<Integer> primeSwapped = new HashSet<>();
        permutations[0] = asString;
        primeSwapped.add(Integer.parseInt(asString));

        for (int i = 1; i < permutations.length; i++) {
            permutations[i] = (permutations[i - 1].substring(1) + permutations[i - 1].charAt(0));
            if (!primes.contains(Integer.parseInt(permutations[i]))) {
                return null;
            }
            primeSwapped.add(Integer.parseInt(permutations[i]));
        }
        return primeSwapped.toArray(new Integer[0]);
    }

    public ArrayList<Integer> genPrimes(int range) {
        ArrayList<Integer> primes = new ArrayList<>();
        primes.add(2);
        outer:
        for (int i = 3; i < range; i += 2) {
            int sqrt = (int) Math.sqrt(i);
            for (int j = 0; j < primes.size() && primes.get(j) <= sqrt; j++) {
                if (i % primes.get(j) == 0) {
                    continue outer;
                }
            }
            primes.add(i);
        }
        return primes;
    }
}
