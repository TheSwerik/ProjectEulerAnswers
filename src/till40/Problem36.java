package till40;

import java.util.ArrayList;

public class Problem36 {

    public Problem36() {
        long startTime = System.nanoTime();
        long result = 25;

        // Solution:
        int counter = 0;
        String nines = "99";
        String tens = "0";
        for (long i = 11; i < 10_000; ) {
            String binary = Integer.toBinaryString((int) i);
            if (binary.equals(new StringBuilder(binary).reverse().toString())) {
                result += i;
                System.out.println(i);
            }
            // 99 or 999 or 9999 or 99999
            if (i % Integer.parseInt(nines) == 0) {
                nines += "9";
                tens = "1" + tens;
                i += 2;
                counter = 0;
                continue;
            }

            // 111 & 2222 & 33333 & 444444:
            if (i > 100) {
                if (++counter == 10) {
                    i += 11;
                    counter = 0;
                } else {
                    i += Integer.parseInt(tens);
                }
                continue;
            }

            // < 100:
            if (i < 99) {
                i += 11;
            }
        }
/*        // for 10101:
        int compare = 19191;
        int lastI = 100001;
        for (long i = 10101; i < 100_000; ) {
            if (!checkList.contains((int) i)) {
                if (Integer.toBinaryString((int) i).equals(new StringBuilder(Integer.toBinaryString((int) i)).reverse().toString())) {
                    result += i;
                    System.out.println(i);
                }
            }
            //TODO find 11x11 & 22x22 & 15x51 etc

            // 19191 and 29292 etc
            if (i % compare == 0) {
                compare += 10101;
                i += 1011;
                counter = 0;
                continue;
            }

            if (++counter == 10) {
                i += 11;
                counter = 0;
            } else {
                i += 1010;
            }
            System.out.println(i + " " + counter);
        }*/
        // for 10101 and 11011:
        counter = 0;
        long lastI = 10001;
        for (long i = lastI, j = 0; i < 100_000; ) {
            if (Integer.toBinaryString((int) i).equals(new StringBuilder(Integer.toBinaryString((int) i)).reverse().toString())) {
                result += i;
//                System.out.println(i);
            }
            i += 1010;
            if (++counter == 10) {
                i = lastI + 100;
                lastI = (int) i;
                counter = 0;
                j++;
            } // 19991 and 29992 etc
            if (j == 10) {
                j = 0;
                i += 9001;
                lastI = (int) i;
            }
            System.out.println(i);
        }
        // for 101101 and 110011:
        counter = 0;
        lastI = 100001;
        for (long i = lastI, j = 0; i < 1_000_000; ) {
            if (Integer.toBinaryString((int) i).equals(new StringBuilder(Integer.toBinaryString((int) i)).reverse().toString())) {
                result += i;
//                System.out.println(i);
            }
            i += 10010;
            if (++counter == 10) {
                i = lastI + 1100;
                lastI = (int) i;
                counter = 0;
                j++;
            } // 199991 and 299992 etc
            if (j == 10) {
                j = 0;
                i += 89001;
                lastI = (int) i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
