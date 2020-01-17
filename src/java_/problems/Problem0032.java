package java_.problems;

import java.util.HashSet;

public class Problem0032 {

    private int counter = 0;

    public Problem0032() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int n = 362880;
        String[] permutations = new String[n];
        String first = "123456789";

        this.permute(permutations, "", first);

        HashSet<Long> numbers = new HashSet<>();
        for (String s : permutations) {
            for (int i = 1; i < s.length() - 2; i++) {
                for (int j = i + 1; j < s.length() - 1; j++) {
                    if (Long.parseLong(s.substring(0, i)) *
                            Long.parseLong(s.substring(i, j)) ==
                            Long.parseLong(s.substring(j))) {
                        numbers.add(Long.parseLong(s.substring(j)));
                    }
                }
            }
        }
        for (Long l : numbers) {
            result += l;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private void permute(String[] permutations, String prefix, String s) {
        if (counter >= 362880) {
            return;
        }
        int n = s.length();
        if (n == 0) {
            permutations[this.counter++] = prefix;
        } else {
            for (int i = 0; i < n; i++) {
                permute(permutations, prefix + s.charAt(i), s.substring(0, i) + s.substring(i + 1, n));
            }
        }
    }
}
