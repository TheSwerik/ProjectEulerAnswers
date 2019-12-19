package till30;

import java.util.Arrays;

public class Problem28 {

    public Problem28() {
        long startTime = System.nanoTime();
        long result = 1;

        // Grid:
/*        int n = 1001;
        long[][] spiral = new long[n][n];
        long counter = n * n;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n - i; j++) {
                if (i % 4 == 0) { // go right
                    spiral[j][i] = counter--;
                } else if (i % 4 == 3) {
                    spiral[1000 - i][j] = counter--;
                } else if (i % 4 == 2) {
                    spiral[1000 - j][1000 - i] = counter--;
                } else {
                    spiral[i][1000 - j - i] = counter--;
                }
            }
        }
        System.out.println(Arrays.deepToString(spiral));*/

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
