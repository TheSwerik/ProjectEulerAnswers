package de.swerik.euler._00;

public class Problem0021 {

    public Problem0021() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        for (long i = 2; i <= 10000; i += 2) {
            long sum1 = 1;
//            for (int j = 2; j <= i / 2; j++) {
//                if (i % j == 0) {
//                    sum1 += j;
//                }
//            }
            double root = Math.sqrt(i);
            for (int j = 2; j <= root; j++) {
                if (i % j == 0) {
                    sum1 += j + (i / j);
                }
            }
            if (sum1 == i) {
                continue;
            }
            long sum2 = 1;
//            for (int j = 2; j <= sum1 / 2; j++) {
//                if (sum1 % j == 0) {
//                    sum2 += j;
//                }
//            }
            root = Math.sqrt(sum1);
            for (int j = 2; j <= root; j++) {
                if (sum1 % j == 0) {
                    sum2 += j + (sum1 / j);
                }
            }
            if (sum2 == i) {
//                System.out.println(i + " " + sum1 + " " + sum2);
                result += i;
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }


//        ArrayList<Integer> newList = (ArrayList<Integer>) list.stream()
//                .distinct()
//                .collect(Collectors.toList());
}
