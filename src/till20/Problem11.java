package till20;

public class Problem11 {
    public Problem11() {

        //TODO hier
//        int[][] grid = new int{{8}};

        long startTime = System.nanoTime();
        long result = 0;

        // Solution:



        long timeToResolve = System.nanoTime() - startTime;
        if (((double) timeToResolve / 1_000_000) >= 1000) {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000_000) + "s");
        } else {
            System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
        }
    }
}
