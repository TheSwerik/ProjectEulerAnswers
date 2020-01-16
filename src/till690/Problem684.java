package till690;

import java.math.BigInteger;

public class Problem684 {

    private int[] oneToNine = new int[]{0, 1, 3, 6, 10, 15, 21, 28, 36, 45};

    public Problem684() {
        long startTime = System.nanoTime();
        BigInteger result = BigInteger.ZERO;

        // Solution:
        System.out.println("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999".length());
        long[] fibo = findFibos(90);
        for (int i = 10000; i < 100000; ) {
            result = result.add(findSmallestDigitSum(i));
            if (i++ % 9999 == 0) {
                System.out.println(result.toString());
                bigS(i);
                result = BigInteger.ZERO;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result.toString() + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long[] findFibos(int n) {
        long[] result = new long[n];

        result[0] = 1;
        result[1] = 1;
        for (int i = 2; i < n; i++) {
            result[i] = result[i - 1] + result[i - 2];
        }

        return result;
    }

    private BigInteger findSmallestDigitSum(long n) {
        return new BigInteger(n % 9 + "9".repeat((int) n / 9));
    }

    private long bigS(long n) {
        BigInteger result = new BigInteger("0");

        String temp = n + "";

        int firstNumberOfNines = 0;
        if (temp.length() > 1) {
            firstNumberOfNines = Integer.parseInt("1".repeat((n + "").length() - 2) + "0");
        }
        int nextNumberOfNines = 0;
        if (temp.length() > 2) {
            for (int i = 0; i < temp.length() - 2; i++) {
                nextNumberOfNines += Integer.parseInt("9".repeat(i));
            }
        }
        int lastNumberOfNines = temp.length() - 1;
        while (n > 0) {
            String test = n + "";
            switch (test.length()) {
                case 1:
                    result = result.add(BigInteger.valueOf(oneToNine[(int) n]));
                    n -= n;
                case 2:
                    result = result.add(new BigInteger("5" + "9".repeat(0) + "3" + "".repeat(Integer.parseInt(test.substring(0, 1))) + "9".repeat(Integer.parseInt(test.substring(0, 1)) - 1) + "1")); //1
                    n -= (test.charAt(0) - 48) * 10;
                case 3:
                    result = result.add(new BigInteger("5" + "9".repeat(10) + "3" + "999999999".repeat(Integer.parseInt(test.substring(0, 1))) + "99".repeat(Integer.parseInt(test.substring(0, 1)) - 1) + "01")); // 9
                    n -= (test.charAt(0) - 48) * 100;
                case 4:
                    result = result.add(new BigInteger("5" + "9".repeat(110) + "3" + "999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999".repeat(Integer.parseInt(test.substring(0, 1))) + "999".repeat(Integer.parseInt(test.substring(0, 1)) - 1) + "001")); // 9+99
                    n -= (test.charAt(0) - 48) * 1000;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                default:
                    result = result.add(new BigInteger("5" + "9".repeat(firstNumberOfNines) + "3" + ("9".repeat(nextNumberOfNines)).repeat(Integer.parseInt(test.substring(0, 1))) + ("9".repeat(lastNumberOfNines++)).repeat(Integer.parseInt(test.substring(0, 1)) - 1) + "0".repeat(lastNumberOfNines - 2) + "1"));
                    firstNumberOfNines = Integer.parseInt((firstNumberOfNines + "").substring(1));
                    nextNumberOfNines -= Integer.parseInt("9".repeat(test.length() - 2));

                    n -= (test.charAt(0) - 48) * 1000;
            }
        }
        return Long.parseLong(result.mod(new BigInteger("1000000007")).toString());
    }

}
