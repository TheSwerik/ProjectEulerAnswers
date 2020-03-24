package _00;

import java.util.ArrayList;

public class Problem0034 {

    private final int[] factorials;

    public Problem0034() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        this.factorials = new int[]{
                1, 1, 2, 6,
                this.factorial(4),
                this.factorial(5),
                this.factorial(6),
                this.factorial(7),
                this.factorial(8),
                this.factorial(9)
        };
//        System.out.println(Arrays.toString(factorials));
        ArrayList<Long> list = new ArrayList<>();
        for (long i = 3; i < 2540161; i++) {
            if (this.getDigitFactorial(i) == i) {
                list.add(i);
//                System.out.println(i);
            }
        }
        for (long n : list) {
            result += n;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long getDigitFactorial(long n) {
        String asString = n + "";
        int[] numbers = new int[asString.length()];
        for (int i = 0; i < asString.length(); i++) {
            numbers[i] = asString.charAt(i) - 48;
        }

        long result = 0;
        for (int number : numbers) {
            result += this.factorials[number];
        }
        return result;
    }

    private int factorial(int n) {
        int result = n;
        for (int i = n - 1; i > 1; i--) {
            result *= i;
        }
        return result;
    }
}
