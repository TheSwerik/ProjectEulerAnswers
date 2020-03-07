import java.math.BigInteger;

public class Problem0684 {

    private final int[] oneToNine = {0, 1, 3, 6, 10, 15, 21, 28, 36, 45};

    public Problem0684() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long[] fibo = this.findFibos(90);
        float i = 1;
        for (long f : fibo) {
            result += this.bigS(f) % 1_000_000_007;
            System.out.println(i++ / 90 * 100 + " %");
//            i++;
        }
        //TODO finish

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
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
            for (int i = 1; i <= temp.length() - 2; i++) {
                nextNumberOfNines += Integer.parseInt("9".repeat(i));
            }
        }

        while (n > 0) {
            String test = n + "";
            if (test.length() == 1) {
                result = result.add(BigInteger.valueOf(this.oneToNine[(int) n]));
                n -= n;
            } else {
                result = result.add(new BigInteger("5" + "9".repeat(firstNumberOfNines) + "3" +
                        ("9".repeat(nextNumberOfNines)).repeat(Integer.parseInt(test.substring(0, 1))) +
                        ("9".repeat(test.length() - 1)).repeat(Integer.parseInt(test.substring(0, 1)) - 1) +
                        "0".repeat(test.length() - 2) + "1"));
                if (firstNumberOfNines > 0)
                    firstNumberOfNines = Integer.parseInt((firstNumberOfNines + "").substring(1));
                if (test.length() > 2)
                    nextNumberOfNines -= Integer.parseInt("9".repeat(test.length() - 2));

                n -= (test.charAt(0) - 48) * Integer.parseInt("1" + "0".repeat(test.length() - 1));
            }
        }
        return Long.parseLong(result.mod(new BigInteger("1000000007")).toString());
    }

}
