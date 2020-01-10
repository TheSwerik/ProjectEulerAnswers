package till40;

import java.util.Arrays;

public class Problem38 {

    private int counter = 0;

    public Problem38() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int n = 362880;
        String[] permutations = new String[n];
        String first = "987654321";

        this.permute(permutations, "", first);

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
                if (concatenate(i).equals(number)) {
                    result = Integer.parseInt(number);
                    break loop;
                }
            }
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

    private String concatenate(int n) {
        StringBuilder result = new StringBuilder();

        for (int i = 1; result.length() < 9; i++) {
            result.append(n * i);
        }

        return result.toString();
    }
}
