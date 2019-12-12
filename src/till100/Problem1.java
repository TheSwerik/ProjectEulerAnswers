package till100;

import java.util.HashSet;
import java.util.stream.Stream;

public class Problem1 {
    public Problem1() {
        long startTime = System.nanoTime();
        long result = 0;
//        HashSet<Integer> set = new HashSet<>();
//        for (int i = 3; i < 1000; i += 3) {
//            set.add(i);
//        }
//        for (int i = 5; i < 1000; i += 5) {
//            set.add(i);
//        }
//        for (Integer i : set) {
//            result += i;
//        }

        for (int i = 3; i < 1000; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                result += i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + ((double) timeToResolve / 1_000_000) + "ms");
    }
}
