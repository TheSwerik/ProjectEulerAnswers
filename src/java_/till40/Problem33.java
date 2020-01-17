package java_.till40;

public class Problem33 {

    public Problem33() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int counter = 0;
        int[] numerators = new int[4];
        int[] denominators = new int[4];
        for (int denominator = 12; denominator < 100; denominator++) {
            if (denominator % 10 == 0) continue;
            for (int numerator = 11; numerator < denominator; numerator++) {
                if (numerator % 10 == 0) continue;
                char[] numeratorChars = (numerator + "").toCharArray();
                char[] denominatorChars = (denominator + "").toCharArray();
                char numeratorC;
                char denominatorC;
                if (denominatorChars[0] == numeratorChars[0]) {
                    denominatorC = denominatorChars[1];
                    numeratorC = numeratorChars[1];
                } else if (denominatorChars[1] == numeratorChars[0]) {
                    denominatorC = denominatorChars[0];
                    numeratorC = numeratorChars[1];
                } else if (denominatorChars[0] == numeratorChars[1]) {
                    denominatorC = denominatorChars[1];
                    numeratorC = numeratorChars[0];
                } else if (denominatorChars[1] == numeratorChars[1]) {
                    denominatorC = denominatorChars[0];
                    numeratorC = numeratorChars[0];
                } else {
                    continue;
                }
                double fractal = (double) numerator / denominator;
                if (fractal == (double) (numeratorC - 48) / (denominatorC - 48)) {
                    numerators[counter] = (numeratorC - 48);
                    denominators[counter++] = (denominatorC - 48);
                }
            }
        }
        result = getLowestDenominatorProduct(numerators, denominators);

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private long getLowestDenominatorProduct(int[] numerators, int[] denominators) {
        int num = 0;
        int denom = 0;
        for (int i = 0; i < numerators.length; i++) {
            for (int j = 2; j < denominators[i]; j++) {
                if (numerators[i] % j == 0 && denominators[i] % j == 0) {
                    numerators[i] /= j;
                    denominators[i] /= j;
                    j = 1;
                }
            }
            if (i == 0) {
                denom = denominators[i];
                num = numerators[i];
            } else {
                denom *= denominators[i];
                num *= numerators[i];
            }
        }
        return getLowestDenominatorProduct(num, denom);
    }

    private long getLowestDenominatorProduct(int numerator, int denominator) {
        for (int j = 2; j < denominator; j++) {
            if (numerator % j == 0 && denominator % j == 0) {
                numerator /= j;
                denominator /= j;
                j = 1;
            }
        }
        return denominator;
    }
}
