import java.math.BigInteger;
import java.util.ArrayList;
import java.util.LinkedHashSet;

public class Problem0029 {

    public Problem0029() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        LinkedHashSet<BigInteger> set = new LinkedHashSet<>();
        for (int i = 2; i <= 100; i++) {
            for (int j = 2; j <= 100; j++) {
                set.add(new BigInteger(String.valueOf(j)).pow(i));
            }
        }
        ArrayList<BigInteger> list = new ArrayList<>(set);
        result = list.size();

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
