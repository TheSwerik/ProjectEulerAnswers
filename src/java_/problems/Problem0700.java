package java_.problems;

import java.awt.*;
import java.math.BigInteger;

public class Problem0700 {

    public Problem0700() {
        long startTime = System.nanoTime();
//        long result = 1504170715041707L;
        long result = 0;
        String[] arr = s.split("\n");
        for (String s : arr) {
            result += Long.parseLong(s);
        }
        System.out.println(result);

        // Solution:
        long mod = 4503599627370517L;
        long first = 1504170715041707L;
        long smallest = Long.parseLong(arr[arr.length - 1]);
        long current = smallest;

        while (smallest > 0) {
            current = (current + first) % mod;
            if (current < smallest) {
                smallest = current;
                result += current ;
                System.out.println(current);
                Toolkit.getDefaultToolkit().beep();
            }
        }


        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    String s = """
            1504170715041707
            8912517754604
            2044785486369
            1311409677241
            578033868113
            422691927098
            267349986083
            112008045068
            68674149121
            25340253174
            7346610401
            4046188430
            745766459
            428410324
            111054189
            15806432
            15397267
            14988102
            14578937
            14169772
            13760607
            13351442
            12942277
            12533112
            12123947
            11714782
            11305617
            10896452
            10487287
            10078122
            9668957
            9259792
            8850627
            8441462
            8032297
            7623132
            7213967
            6804802
            6395637
            5986472
            5577307
            5168142
            4758977
            4349812
            3940647
            3531482
            3122317
            2713152
            2303987
            1894822
            1485657
            1076492
            667327
            258162
            107159
            63315
            19471
            14569
            9667
            4765
            4628
            4491
            4354
            """;
}
