package de.swerik.euler._00;

public class Problem0036 {

    public Problem0036() {
        long startTime = System.nanoTime();
        long result = 25;

        // Solution:
        int counter = 0;
        String nines = "99";
        String tens = "0";
        // under 10,000:
        for (long i = 11; i < 10_000; ) {
            String binary = Integer.toBinaryString((int) i);
            if (binary.equals(new StringBuilder(binary).reverse().toString())) {
                result += i;
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
        // over 10,000:
        counter = 0;
        long lastI = 10001;
        int addNumber1 = 1010;
        int addNumber2 = 100;
        int addNumber3 = 9001;
        for (long i = lastI, j = 0; i < 1_000_000; ) {
            if (Integer.toBinaryString((int) i).equals(new StringBuilder(Integer.toBinaryString((int) i)).reverse().toString())) {
                result += i;
            }
            i += addNumber1;
            // when middle number(s) are 9 (xx9xx or xx99xx):
            if (++counter == 10) {
                i = lastI + addNumber2;
                lastI = (int) i;
                counter = 0;
                j++;
            }
            // when all inner numbers are 9 (x999x or x9999x):
            if (j == 10) {
                j = 0;
                i += addNumber3;
                lastI = (int) i;
            }
            // change numbers when over 100,000:
            if (i == 100010) {
                lastI = i = 100001;
                counter = 0;
                addNumber1 = 10010;
                addNumber2 = 1100;
                addNumber3 = 89001;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
