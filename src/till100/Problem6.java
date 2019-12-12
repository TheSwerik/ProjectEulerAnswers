package till100;

public class Problem6 {
    public Problem6() {
        long startTime = System.nanoTime();
        long result = 0;

        int a = 0;
        int b = 0;
        for (int i = 1; i < 101; i++) {
            a += i;
            b += i * i;
        }
        result = a * a - b;

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
