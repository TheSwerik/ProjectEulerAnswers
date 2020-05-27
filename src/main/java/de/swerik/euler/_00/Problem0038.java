package de.swerik.euler._00;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem0038 {

    private int counter = 0;

    public Problem0038() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
//        result = solveOld(result);
        int n = 40_320;                         //n = 40320 bc there are 40320 Pandigital numbers that start with 9
        String[] permutations = new String[n];
        String first = "987654321";

        this.permute(n, permutations, "", first);

        ArrayList<String> permutationsList = new ArrayList<String>(Arrays.asList(permutations));
        //find number:
        for (int i = 9487; i > 0; i--) {
            if (permutationsList.contains(this.concatenate(i))) {
                result = Long.parseLong(i + "" + i * 2);
                break;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long solveOld(long result) {
//        int n = 362880; // ALL Pandigital Numbers
        int n = 40_320;                         //n = 40320 bc there are 40320 Pandigital numbers that start with 9
        String[] permutations = new String[n];
        String first = "987654321";

        this.permute(n, permutations, "", first);

        //find startIndex:
        int index = 0;
        for (int i = 0; i < permutations.length; i++) {
            if (permutations[i].equals("948765321")) {
                index = i;
                break;
            }
        }

        //find number:
        loop:
        for (int j = index; j < permutations.length; j++) {
            String number = permutations[j];
            if (Integer.parseInt(number.substring(0, 4)) * 2 > 100_000) {
                continue;
            }
//            System.out.println(number);
            for (int i = Integer.parseInt(number.substring(0, 4)); i > 0; i--) {
                if (this.concatenate(i).equals(number)) {
                    result = Integer.parseInt(number);
                    break loop;
                }
            }
        }
        return result;
    }

    private void permute(int max, String[] permutations, String prefix, String s) {
        if (this.counter >= max) {
            return;
        }
        int n = s.length();
        if (n == 0) {
            permutations[this.counter++] = prefix;
        } else {
            for (int i = 0; i < n; i++) {
                this.permute(max, permutations, prefix + s.charAt(i), s.substring(0, i) + s.substring(i + 1, n));
            }
        }
    }

    private String concatenate(int n) {
        StringBuilder result = new StringBuilder();

        for (int i = 1; result.length() < 9; i++) {
            result.append(n * i);
        }

        return result.toString();
    }
}
