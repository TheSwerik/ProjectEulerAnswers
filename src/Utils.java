import java.util.ArrayList;
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
//        return primes.toArray();
        return primes.get(primes.size() - 1);
    }

}
