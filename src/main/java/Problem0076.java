public class Problem0076 {

    private long result = 0L;

    public Problem0076() {
        long startTime = System.nanoTime();
        long result = 0L;
        // Solution:
        result = fastCombinations(100, 0);

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private void combinations(int rest, int number) {       //should work but not enough memory
        if (rest == 0) {
            result++;
            return;
        }
        for (int a = number; a < 100; a++) {
            if (rest - a >= 0) {
                combinations(rest - a, a);
            }
        }
    }

    private long fastCombinations(int rest, int number) {
        int[] ways = new int[rest + 1];
        ways[0] = 1;
        for (int i = 1; i < rest; i++) {
            for (int j = i; j <= rest; j++) {
                ways[j] += ways[j - i];
            }
        }
        return ways[rest];
    }
    /*
    coins [1..8] = { 1, 2 , 5 , 10 , 20 , 50 , 100 , 200 }
amount = 200
ways [0.. amount ] = { uninitialized array }
ways [0] = 1;
for i = 1 to 8 do :
for j = coins [i] to amount do :
ways [j] = ways [j] + ways [j - coins [ i ]]
print ways [ amount ]

     */
}
