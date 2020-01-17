package java_.problems;

public class Problem0018 {
    public Problem0018() {
        int[][] arr = fill();

        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        for (int i = arr.length - 1; i > 0; i--) {
            for (int j = 0; j < arr[i].length-1; j++) {
                arr[i - 1][j] += Math.max(arr[i][j], arr[i][1 + j]);
            }
        }
        result = arr[0][0];

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private int[][] fill() {
        int[][] result = new int[pyramid.split("\n").length][];

        int i = 0;
        for (String s : pyramid.split("\n")) {
            int j = 0;
            result[i] = new int[s.split(" ").length];
            for (String number : s.split(" ")) {
                result[i][j] = Integer.parseInt(number);
                j++;
            }
            i++;
        }

        return result;
    }

    private String pyramid =
            "75\n" +
                    "95 64\n" +
                    "17 47 82\n" +
                    "18 35 87 10\n" +
                    "20 04 82 47 65\n" +
                    "19 01 23 75 03 34\n" +
                    "88 02 77 73 07 63 67\n" +
                    "99 65 04 28 06 16 70 92\n" +
                    "41 41 26 56 83 40 80 70 33\n" +
                    "41 48 72 33 47 32 37 16 94 29\n" +
                    "53 71 44 65 25 43 91 52 97 51 14\n" +
                    "70 11 33 28 77 73 17 78 39 68 17 57\n" +
                    "91 71 52 38 17 14 91 43 58 50 27 29 48\n" +
                    "63 66 04 68 89 53 67 30 73 16 69 87 40 31\n" +
                    "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
}
