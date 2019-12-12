public class Utils {
    public int findBiggestPrimFactor(long input) {
        int i;
        long maxNumber = input;

        for (i = 2; i <= maxNumber; i++) {
            if (maxNumber % i == 0) {
                maxNumber /= i;
                i--;
            }
        }
        return i;
    }

}
