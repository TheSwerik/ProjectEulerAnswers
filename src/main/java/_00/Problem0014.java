package _00;

public class Problem0014 {
    public Problem0014() {
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
//        HashMap<Integer, Integer> map = new HashMap<>();
//        int maxCount = 0;
//        for (int i = 2; i <= 1000000; i++) {
//            long test = i;
//            int count = 0;
//            do {
//                if (map.containsKey(test)) {
//                    count += map.get(test);
//                    break;
//                }
//                if ((test & 1) == 0) {
//                    test /= 2;
//                } else {
//                    test = test * 3 + 1;
//                }
//                count++;
//            } while (test != 1);
//            map.put(i, count);
//            if (count > maxCount) {
//                maxCount = count;
//                result = i;
//            }
//        }


        //faster: array > map
        int[] map = new int[1000001];
        int maxCount = 0;
        for (int i = 2; i <= 1000000; i++) {
            long test = i;
            int count = 0;
            do {
                if (test < 1000001 && map[(int) test] != 0) {
                    count += map[(int) test];
                    break;
                }
                if ((test & 1) == 0) {
                    test /= 2;
                } else {
                    test = test * 3 + 1;
                }
                count++;
            } while (test != 1);
            map[i] = count;
            if (count > maxCount) {
                maxCount = count;
                result = i;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }
}
