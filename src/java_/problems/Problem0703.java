package java_.problems;

import java.util.ArrayList;
import java.util.Arrays;

public class Problem0703 {
    private final int n = 3;

    public Problem0703() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        boolean[][] b = b();
        // S:
        outer:
        for (boolean[] boolArr : b) {
            boolean[] f = f(boolArr);
            for (int i = 0; i < boolArr.length; i++) {
                if ((boolArr[i] && f[i])) continue outer;
            }
            result++;
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean[][] b() {
        boolean[][] b = new boolean[(int) Math.pow(2, n)][n];
        int ic = 0;
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                for (int k = 0; k < 2; k++) {
                    if (n == 4)
                        for (int l = 0; l < 2; l++) {
                            b[ic][0] = k == 0;
                            b[ic][1] = j == 0;
                            b[ic][2] = l == 0;
                            b[ic++][3] = i == 0;
                        }
                    else if (n == 3) {
                        b[ic][0] = k == 0;
                        b[ic][1] = j == 0;
                        b[ic++][2] = i == 0;
                    }
                }
            }
        }
        return b;
    }

    private boolean[] f(boolean[] b) {
        boolean[] c = new boolean[n];
        if (b.length - 1 >= 0) System.arraycopy(b, 1, c, 0, b.length - 1);
        c[n - 1] = b[0] && (b[1] ^ b[2]);
//        System.out.println(Arrays.toString(b));
//        System.out.println(Arrays.toString(c) + "\n");
        return c;
    }
}
