package till20;

import java.util.HashMap;

public class Problem19 {
    public Problem19() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        //for every year:
        long count = -1;
        boolean once = false;
        for (int i = 0; i <= 100; i++) {
            if (!once && i == 1) {
                result = 0;
                once = true;
            }
            for (int j = 0; j < 12; j++) {
                int days = switch (j) {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                    case 7:
                    case 9:
                    case 11:
                        yield 31;
                    case 3:
                    case 5:
                    case 8:
                    case 10:
                        yield 30;
                    case 1:
                        yield ((i) % 4 == 0) && !once ? 29 : 28;
                    default:
                        throw new IllegalStateException("Unexpected value: " + j);
                };
                for (int k = 0; k < days; k++) {
                    if (++count == 7) {
                        count = 0;
                        if (k == 0) {
                            result++;
                        }
                    }
                }
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
