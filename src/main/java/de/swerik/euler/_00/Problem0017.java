package de.swerik.euler._00;

import java.util.HashMap;

public class Problem0017 {
    public Problem0017() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        HashMap<Integer, Integer> map = new HashMap<>();
        map.put(0, 0);
        map.put(1, 3);
        map.put(2, 3);
        map.put(3, 5);
        map.put(4, 4);
        map.put(5, 4);
        map.put(6, 3);
        map.put(7, 5);
        map.put(8, 5);
        map.put(9, 4);
        map.put(10, 3);
        map.put(11, 6);
        map.put(12, 6);
        map.put(13, 8);
        map.put(15, 7);
        map.put(18, 8);
        for (int i = 1; i < 1000; i++) {
            long test = result;
            String rest = i + "";
            if (i >= 100) {
                result += map.get(rest.charAt(0) - 48);     // first digit
                result += 7;                                // hundred
                rest = rest.substring(1);                   // keep last two digits
                if (rest.equals("00")) {
                    continue;
                }
                result += 3;                                // and
            }
            int restInt = Integer.parseInt(rest);
            if (restInt < 14 || restInt == 15 || restInt == 18) {
                result += map.get(restInt);                 // below 14, or 15 or 18
            } else if (restInt < 20) {
                result += map.get(rest.charAt(1) - 48);     // last digit
                result += 4;                                // teen
            } else {
                if (rest.charAt(0) - 48 == 2 || rest.charAt(0) - 48 == 3 || rest.charAt(0) - 48 == 8) {
                    result += 4;                            // twen- or thir- or eigh-
                } else if (rest.charAt(0) - 48 == 5 || rest.charAt(0) - 48 == 4) {
                    result += 3;                            // fif- or for-
                } else {
                    result += map.get(rest.charAt(0) - 48); // first digit
                }
                result += 2;                                // -ty
                result += map.get(rest.charAt(1) - 48);     // last digit
            }
        }
        result += 11;                                       // one thousand

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
