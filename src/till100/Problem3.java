package till100;

public class Problem3 {
    public Problem3() {
        long startTime = System.nanoTime();
        long result = 0;
        for (int i = (int) Math.sqrt(600851475143L); i > 2; i--) {
            if (600851475143L % i != 0) {
                continue;
            }
            for (int j = 2; j < Math.sqrt(i); j++) {
                if (i % j == 0) {
                    break;
                }
                if (j == (int) Math.sqrt(i)) {
                    result = i;
                    break;
                }
            }
            if (result != 0) {
                break;
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
