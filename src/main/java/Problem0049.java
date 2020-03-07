import java.util.ArrayList;
import java.util.Arrays;

public class Problem0049 {
    private int[] _primes;

    public Problem0049() {
        long startTime = System.nanoTime();
        String result = "";

        // Solution:
        this.GenPrimes();
        outer:
        for (var j : this._primes)
            for (var i = 45; ; i++) {
                if (i == 3330 && j == 1487) continue;
                var b = j + i;
                var c = b + i;
                if (c > 9999) break;
                if (this.ArePermutes(j, b, c) && this.ArePrimes(j, b, c)) {
                    result = "" + j + b + c;
                    break outer;
                }
            }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private boolean ArePrimes(int a, int b, int c) {
        return Arrays.binarySearch(this._primes, a) >= 0 && Arrays.binarySearch(this._primes, b) >= 0 && Arrays.binarySearch(this._primes, c) >= 0;
    }

    private boolean ArePermutes(int a, int b, int c) {
        var aS = a + "";
        var bS = (b + "").toCharArray();
        var cS = (c + "").toCharArray();
        var digits = aS.toCharArray();

        var bIndices = new boolean[4];
        var cIndices = new boolean[4];
        for (var i = 0; i < 4; i++) {
            for (var j = 0; j < 4; j++) {
                if (bIndices[j]) continue;
                if (digits[i] == bS[j]) {
                    bIndices[j] = true;
                    break;
                }
            }

            for (var j = 0; j < 4; j++) {
                if (cIndices[j]) continue;
                if (digits[i] == cS[j]) {
                    cIndices[j] = true;
                    break;
                }
            }
        }

        return bIndices[0] && bIndices[1] && bIndices[2] && bIndices[3] && cIndices[0] && cIndices[1] && cIndices[2] && cIndices[3];
    }

    private void GenPrimes() {
        var allPrimes = primeSieveButFast(10_000);
        this._primes = new int[0];
        var i = 0;
        for (; i < allPrimes.length; i++)
            if (allPrimes[i] >= 1000) {
                this._primes = new int[allPrimes.length - i];
                break;
            }

        for (var j = 0; j < this._primes.length; j++, i++) this._primes[j] = allPrimes[i];
    }

    public static Integer[] primeSieveButFast(int range) {
        boolean[] bools = new boolean[range + 1];
        Arrays.fill(bools, true);
        double root = Math.sqrt(range) + 0.5;
        for (int i = 3; i < root; i += 2) {
            if (bools[i]) {
                for (int j = i * i; j < range; j += i * 2) {
                    bools[j] = false;
                }
            }
        }
        ArrayList<Integer> primes = new ArrayList<>();
        primes.add(2);
        for (int i = 3; i < range; i += 2) {
            if (bools[i]) {
                primes.add(i);
            }
        }
        return primes.toArray(new Integer[0]);
    }
}
