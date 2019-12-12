package till10;

public class Problem5 {
    public Problem5() {
        long startTime = System.nanoTime();
        long result = 0;

        outer:
        for (int i = 20; ; i++) {
            for (int j = 1; j < 21; j++) {
                if (i % j != 0) {
                    continue outer;
                }
            }
            result = i;
            break;
        }
        //TODO make not trash

        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
