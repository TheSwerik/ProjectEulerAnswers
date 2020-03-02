import java.util.ArrayList;

public class Problem0026 {

    public Problem0026() {
        long startTime = System.nanoTime();
        long result = 0;
        long resultCounter = 0;

        // Solution:
        for (int i = 10; i < 1000; i++) {
            long counter = 0;

            //find periode
            boolean found = false;
            int rest = 10;
            ArrayList<Integer> list = new ArrayList<>();
            long patternIndex = 0;
            while (true) {
                if (rest % i != 0) {
                    counter++;
                    int divisor = rest / i;
                    if (rest > divisor * i) {
                        rest -= divisor * i;
                    }
                    rest *= 10;
                    if (list.contains(rest)) {
                        break;
                    }
                    list.add(rest);
                } else {
                    counter = 0;
                    break;
                }
            }
            if (counter > resultCounter) {
                resultCounter = counter;
                result = i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
