import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Utils {
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

    public Integer[] primeSieve(int range) {
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
}
