import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Stream;

public class Utils {

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

    public static Integer[] primeSieve(int range) {
        ArrayList<Integer> primes = new ArrayList<>();
        boolean[] bools = new boolean[range + 1];
        Arrays.fill(bools, true);

        for (int i = 2; i < bools.length; i++) {
            if (bools[i]) {
                primes.add(i);
                for (int j = i; j < bools.length; j += i) {
                    bools[j] = false;
                }
            }
        }
        return primes.toArray(new Integer[0]);
    }

    public static Integer[] genPrimesWithStreams(int range) {
        return Stream.concat(
                Stream.of(2),
                Stream.iterate(3, n -> n + 2)
                        .limit(range / 2 - 1)
                        .filter(n ->
                                Stream.iterate(2, x -> x + 1)
                                        .limit((int) (Math.sqrt(n)))
                                        .noneMatch(x -> n % x == 0)))
                .toArray(Integer[]::new);
    }

    public int findBiggestPrimFactor(long input) {
        int i;
        long maxNumber = input;

        for (i = 2; i <= maxNumber; i++) {
            if (maxNumber % i == 0) {
                maxNumber /= i;
                i--;
            }
        }
        return i;
    }

    public int genPrimes(int range) {
        ArrayList<Integer> primes = new ArrayList<>();
        primes.add(2);
        outer:
        for (int i = 3; primes.size() < range; i += 2) {
            int sqrt = (int) Math.sqrt(i);
            for (int j = 0; j < primes.size() && primes.get(j) <= sqrt; j++) {
                if (i % primes.get(j) == 0) {
                    continue outer;
                }
            }
            primes.add(i);
        }
//        return primes.toArray(); //würde alle geben
        return primes.get(primes.size() - 1);
    }
}
