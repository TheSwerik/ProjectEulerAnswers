package java_.problems;

public class Problem0028 {

    public Problem0028() {
        long startTime = System.nanoTime();
        long result = 1;

        //schlau
        int step = 2;
        int num = 1;
        for (int i = 0; i < 500; i++) {
            for (int j = 0; j < 4; j++) {
                num += step;
                result += num;
            }
            step += 2;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
