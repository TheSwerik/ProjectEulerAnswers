package till100;

public class Problem7 {
    public Problem7() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int counter = 4;
        outer:
        for (int i = 11; ; i += 2) {
            //check if i is prime:
            for (int j = 3; j <= (int) Math.sqrt(i); j++) {
                if (i % j == 0) {
                    continue outer;
                }
            }
            System.out.println(i);
            //check if it's the 10001st:
            if (++counter == 10001) {
                result = i;
                break;
            }
        }
        //shaved off from 1,5sec to /3ms

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
