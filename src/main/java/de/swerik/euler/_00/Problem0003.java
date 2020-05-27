package de.swerik.euler._00;

public class Problem0003 {
    public Problem0003() {
        long startTime = System.nanoTime();
        long result = 0;
//        for (int i = (int) Math.sqrt(600851475143L); i > 2; i--) {
//            if (600851475143L % i != 0) {
//                continue;
//            }
//            for (int j = 2; j < Math.sqrt(i); j++) {
//                if (i % j == 0) {
//                    break;
//                }
//                if (j == (int) Math.sqrt(i)) {
//                    result = i;
//                    break;
//                }
//            }
//            if (result != 0) {
//                break;
//            }
//        }

        int i;
        long maxNumber = 600851475143L;

        for (i = 2; i <= maxNumber; i++) {
            if (maxNumber % i == 0) {
                maxNumber /= i;
                i--;
            }
        }
        result = i;

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
