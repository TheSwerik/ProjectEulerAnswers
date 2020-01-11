package till50;

public class Problem43 {

    private int counter = 0;

    public Problem43() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        int n = 3_628_800;
        String[] permutations = new String[n];
        String first = "0123456789";
        this.permute(n, permutations, "", first);

        for (String number : permutations) {
            // skip leading 0s
            if (number.charAt(0) == '0') {
                continue;
            }
            // check 2
            if ((number.charAt(3) - 48) % 2 != 0) {
                continue;
            }
            // check 3
            int crossSum = number.charAt(2) + number.charAt(3) + number.charAt(4) - 3 * 48;
            if (crossSum % 3 != 0) {
                continue;
            }
            // check 5
            int checkDigit = number.charAt(5);
            if (checkDigit != '0' && checkDigit != '5') {
                continue;
            }
            // check 7
            int checkNumber = Integer.parseInt(number.substring(4, 7));
            if (checkNumber % 7 != 0) {
                continue;
            }
            // check 11
            checkNumber = Integer.parseInt(number.substring(5, 8));
            if (checkNumber % 11 != 0) {
                continue;
            }
            // check 13
            checkNumber = Integer.parseInt(number.substring(6, 9));
            if (checkNumber % 13 != 0) {
                continue;
            }
            // check 17
            checkNumber = Integer.parseInt(number.substring(7, 10));
            if (checkNumber % 17 != 0) {
                continue;
            }
            result += Long.parseLong(number);
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private void permute(int max, String[] permutations, String prefix, String s) {
        if (counter >= max) {
            return;
        }
        int n = s.length();
        if (n == 0) {
            permutations[this.counter++] = prefix;
        } else {
            for (int i = 0; i < n; i++) {
                permute(max, permutations, prefix + s.charAt(i), s.substring(0, i) + s.substring(i + 1, n));
            }
        }
    }
}
