package java_.till30;

import java.util.ArrayList;

public class Problem23 {
    public Problem23() {
        long startTime = System.nanoTime();
        long result = 1;

        // Solution:
        ArrayList<Integer> abundant = new ArrayList<>();
//        ArrayList<Boolean> sumOfTwo = new ArrayList<>();
        boolean[] sumOfTwo = new boolean[28123 + 1];
        for (int i = 2; i <= 28123; i++) {
            long sum = 1;
            double root = Math.sqrt(i);
            for (int j = 2; j <= root; j++) {
                if (i % j == 0) {
                    sum += j + (root == j ? 0 : (i / j));
                }
            }
            if (sum > i) {
                abundant.add(i);
            }
        }
        for (int i = 0; i < abundant.size(); i++) {
            for (int j = i; j < abundant.size(); j++) {
                sumOfTwo[(abundant.get(i) + abundant.get(j)) < 28123 ? abundant.get(i) + abundant.get(j) : 24] = true;
            }
        }

        for (int i = 2; i < 28123; i++) {
            if (!sumOfTwo[i]) {
                result += i;
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
