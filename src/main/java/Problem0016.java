import java.math.BigInteger;

public class Problem0016 {
    public Problem0016() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        BigInteger n = new BigInteger("2");
        n = n.pow(1000);
        for (char c : n.toString().toCharArray()) {
            result += c - 48;
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result +"\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
