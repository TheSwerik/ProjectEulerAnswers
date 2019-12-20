package till30;

import java.util.HashSet;

public class Problem30 {

    public Problem30() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        HashSet<Long> numbers = new HashSet<>();
        for (int i = 0; i < 10; i++) {
            long a = (long) Math.pow(i, 5);
            for (int j = 0; j < 10; j++) {
                long b = (long) Math.pow(j, 5);
                for (int k = 0; k < 10; k++) {
                    long c = (long) Math.pow(k, 5);
                    for (int l = 0; l < 10; l++) {
                        long d = (long) Math.pow(l, 5);
                        String testString = i + "" + j + "" + k + "" + l;
                        long testNumber = a + b + c + d;

                        if ((testNumber + "").equals(testString)) {
                            numbers.add(testNumber);
                        }
                        for (int m = 0; m < 10; m++) {
                            long e = (long) Math.pow(m, 5);
                            testString = i + "" + j + "" + k + "" + l + "" + m;
                            testNumber = a + b + c + d + e;

                            if ((testNumber + "").equals(testString)) {
                                numbers.add(testNumber);
                            }
                            for (int n = 0; n < 10; n++) {
                                long f = (long) Math.pow(n, 5);
                                testString = i + "" + j + "" + k + "" + l + "" + m + n;
                                testNumber = a + b + c + d + e + f;

                                if ((testNumber + "").equals(testString)) {
                                    numbers.add(testNumber);
                                }
                            }
                        }
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
}
