package till40;

public class Problem31 {

    private final int[] coins = new int[]{200, 100, 50, 20, 10, 5, 2, 1};
    private long result = 0L;

    public Problem31() {
        long startTime = System.nanoTime();

        // Solution:
        combinations(200, 0);

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private void combinations(int rest, int coin) {
        if (rest == 0) {
            result++;
            return;
        }
        for (int a = coin; a < coins.length; a++) {
            if (rest - coins[a] >= 0) {
                combinations(rest - coins[a], a);
            }
        }
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
