package till40;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem37 {
    public Problem37() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
//        result = solveSlow();
//        result = solveSlowButOptimized();

        int count = 0;
        String[] firstPrimesArr = new String[]{"2", "3", "5", "7"};
        ArrayList<String> firstPrimes = new ArrayList<>(Arrays.asList(firstPrimesArr));
        ArrayList<Integer> primes = new ArrayList<Integer>(Arrays.asList(primeSieveButFast(1_000_000)));
        for (int i = 0; i < 11; ) {
            ArrayList<String> newPrimes = new ArrayList<>();

            for (String prime : firstPrimes) {
                outer:
                for (int j = 0; j < 10; j++) {
                    String s = j + "" + prime;
                    if (primes.contains(Integer.parseInt(s))) {
                        newPrimes.add(s);
                    }

                    for (int k = 1; k < s.length(); k++) {
                        if (!primes.contains(Integer.parseInt(s.substring(k))) ||
                                !primes.contains(Integer.parseInt(s.substring(0, s.length() - k)))) {
                            continue outer;
                        }
                    }
                    i++;
                    result += Integer.parseInt(s);
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long solveSlow() {
        long result = 0;
        outer:
        for (int k = 2; ; k++) {
            int count = 0;
            result = 0;
            ArrayList<Integer> primes = new ArrayList<Integer>(Arrays.asList(primeSieveButFast((int) Math.pow(10.0, (double) k))));
            middle:
            for (Integer i : primes) {
                if (i < 10) {
                    continue;
                }
                String testString = i + "";
                for (int j = 1; j < testString.length(); j++) {
                    if (!primes.contains(Integer.parseInt(testString.substring(j))) ||
                            !primes.contains(Integer.parseInt(testString.substring(0, testString.length() - j)))) {
                        continue middle;
                    }
                }
                System.out.println(i);
                result += i;
                if (++count == 11) {
                    break outer;
                }
            }
        }
        return result;
    }

    private long solveSlowButOptimized() {
        long result = 0;

        int count = 0;
        ArrayList<Integer> primes = new ArrayList<Integer>(Arrays.asList(primeSieveButFast(1_000_000)));
        outer:
        for (Integer i : primes) {
            String testString = i + "";
            if (i < 10 ||
                    testString.substring(1).contains("5")) {
                continue;
            }
            for (int j = 1; j < testString.length(); j++) {
                if (!primes.contains(Integer.parseInt(testString.substring(j))) ||
                        !primes.contains(Integer.parseInt(testString.substring(0, testString.length() - j)))) {
                    continue outer;
                }
            }
            System.out.println(i);
            result += i;
            if (++count == 11) {
                break;
            }
        }

        return result;
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

    private ArrayList<String> primeSieveButFastString(int range) {
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
        ArrayList<String> primes = new ArrayList<>();
        primes.add("2");
        for (int i = 3; i < range; i += 2) {
            if (bools[i]) {
                primes.add(i + "");
            }
        }
        return primes;
    }
}
