package de.swerik.euler._00;

public class Problem0004 {
    public Problem0004() {
        int biggestFactor = 9999;
        long startTime = System.nanoTime();
        long result = 0;

        /*outest:
        for (int i = 999; i > 100; i--) {
            outer:
            for (int j = 999; j > 100; j--) {
                if (j < i - 10) {
                    break;
                }
                //check if palindrome:
                String test = Integer.toString(i * j);
                for (int k = 0; k < (int) (test.length() / 2 + .5); k++) {
                    if (test.charAt(k) != test.charAt(test.length() - k - 1)) {
                        continue outer;
                    }
                }
                result = i * j;
                System.out.println(i + " " + j);
                break outest;
            }
        }*/


        outer:
        for (int i = biggestFactor * biggestFactor; i > 0; i--) {
            //check if palindrome:
//            StringBuilder test = new StringBuilder(i + "");
//            if (!test.toString().equals(test.reverse().toString())) {
//                continue;
//            }
            String test = i + "";
            for (int j = 0; j < (int) (test.length() / 2 + .5); j++) {
                if (test.charAt(j) != test.charAt(test.length() - j - 1)) {
                    continue outer;
                }
            }
            result = i;
            //check if multiple of 3-digit numbers:
            for (int j = biggestFactor; j > Math.sqrt(result); j--) {
                if (result % j == 0) {
                    break outer;
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
