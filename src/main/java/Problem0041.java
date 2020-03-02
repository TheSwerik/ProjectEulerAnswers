import java.util.ArrayList;
import java.util.Arrays;

public class Problem0041 {

    private int counter = 0;

    public Problem0041() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
//        result = solvePrimeToPan();
        result = solvePanToPrime();

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }


    private long solvePanToPrime() {
        int max = 5040;
        String[] permutes = new String[max];
        String maxS = "7654321";
        while (true) {
            this.permute(max, permutes, "", maxS);
            for (String permute : permutes) {
                if (isPrime(Long.parseLong(permute))) {
                    return Long.parseLong(permute);
                }
            }
            maxS = maxS.substring(1);
        }
    }

    private boolean isPrime(long n) {
        if (n % 2 == 0) {
            return false;
        }
        double root = Math.sqrt(n);
        for (int i = 3; i < root; i += 2) {
            if (n % i == 0) {
                return false;
            }
        }
        return true;
    }

    private void permute(int max, String[] permutations, String prefix, String s) {
        if (counter >= max) {
            return;
        }
        int n = s.length();
        if (n == 0) {
            permutations[this.counter++] = prefix;
        } else {
            for (int i = 0; i < n; i++) {
                permute(max, permutations, prefix + s.charAt(i), s.substring(0, i) + s.substring(i + 1, n));
            }
        }
    }

    private long solvePrimeToPan() {
        Integer[] primes = primeSieveButFast(7654321);
//        System.out.println("generated " + primes.length + " primes");
        for (int i = primes.length - 1; i >= 0; i--) {
            if (isPandigital(primes[i].toString())) {
                return primes[i];
            }
        }

        return 0;
    }

    private boolean isPandigital(String n) {
        if (n.contains("0") || n.contains("9") || n.contains("8")) {
            return false;
        }

        boolean[] numbers = new boolean[n.length()];
        for (int i = 0; i < n.length(); i++) {
            if (numbers[(n.charAt(i) - 49)]) {
                return false;
            }
            numbers[(n.charAt(i) - 49)] = true;
        }
        return true;
    }

    private Integer[] primeSieveButFast(int range) {
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
