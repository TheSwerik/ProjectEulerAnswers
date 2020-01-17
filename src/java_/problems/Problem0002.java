package java_.problems;

public class Problem0002 {
    public Problem0002() {
        long startTime = System.nanoTime();
        long result = 0;
        long fibo1 = 1;
        long fibo2 = 1;
        while (fibo2 < 4000000) {
            if ((fibo1 = fibo2 + (fibo2 = fibo1)) % 2 == 0) result += fibo1;
//            long help = fibo2;
//            if ((fibo2 += fibo1) % 2 == 0) {
//            result += fibo2;
//            }
//            fibo1 = help;
        }
        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
    }
}
