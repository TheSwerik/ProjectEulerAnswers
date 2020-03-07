import java.io.*;
import java.util.ArrayList;

public class Problem0042 {
    public Problem0042() {
        String[] words = this.readWords();
        long startTime = System.nanoTime();
        long result = 0;

        // Solution:
        ArrayList<Integer> triangles = this.generateTriangles(15 * 26);
        for (String word : words) {
            if (triangles.contains((int) this.wordValue(word))) {
                result++;
            }
        }

        long timeToResolve = System.nanoTime() - startTime;
        System.out.println("Result:\t" + result + "\tTime:\t" + (((double) timeToResolve / 1_000_000) > 1000 ?
                (((double) timeToResolve / 1_000_000_000) + "s") :
                (((double) timeToResolve / 1_000_000) + "ms")));
    }

    private ArrayList<Integer> generateTriangles(long range) {
        ArrayList<Integer> triangles = new ArrayList<>();

        for (int i = 1; i <= range; i++) {
            triangles.add((int) (0.5 * i * (i + 1)));
        }

        return triangles;
    }

    private long wordValue(String word) {
        long result = 0;

        for (char c : word.toCharArray()) {
            result += (c - 64);
        }

        return result;
    }

    private String[] readWords() {
        try {
            File file = new File("src/main/resources/problem0042_words.txt");
            BufferedReader br = new BufferedReader(new FileReader(file));

            StringBuilder st = new StringBuilder();
            String temp = "";
            while ((temp = br.readLine()) != null) {
                st.append(temp);
            }
            return (st.toString().replace("\"", "")).split(",");
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
}
