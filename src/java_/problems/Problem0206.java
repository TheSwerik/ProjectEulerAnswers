package java_.problems;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem0206 {

    public Problem0206() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        long start = (long) Math.sqrt(1020304050607080900.0);
        long end = (long) Math.sqrt(1929394959697989990.0);
//        String pattern = "1.2.3.4.5.6.7.8.9.0";
//        Matcher matcher = Pattern.compile(pattern).matcher("");

        for (long i = start; i <= end; i += 10) {
//            if (matcher.reset((i * i) + "").matches()) {
//                result = i;
//                break;
//            }
            String s = "" + (i * i);
            if (s.length() != 19) {
                continue;
            }
            if (s.charAt(16) == '9' &&
                    s.charAt(14) == '8' &&
                    s.charAt(12) == '7' &&
                    s.charAt(10) == '6' &&
                    s.charAt(8) == '5' &&
                    s.charAt(6) == '4' &&
                    s.charAt(4) == '3' &&
                    s.charAt(2) == '2' &&
                    s.charAt(0) == '1' &&
                    s.charAt(18) == '0') {
                result = i;
                break;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
