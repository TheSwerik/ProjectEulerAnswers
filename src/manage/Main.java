package manage;

import java.lang.reflect.InvocationTargetException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
//        Problem.solve();
        while (true) {
            System.out.println("\nWhich do you want to try out?");
            int input = sc.nextInt();
            if (input == 0) {
                System.exit(0);
            }
            try {
                String inputString = input + "";
                int start = 0;
                String till = "";
                if (input > 99) {
                    till += inputString.charAt(start++) - 48 + "";
                }
                if (inputString.length() == 1) {
                    till = "10";
                } else {
                    if (inputString.charAt(start + 1) - 48 == 0) {
                        till += inputString.charAt(start) - 48 + "0";
                    } else {
                        till += inputString.charAt(start) - 48 + 1 + "0";
                    }
                }
                Class.forName("till" + till + ".Problem" + input).getDeclaredConstructor().newInstance();
            } catch (InstantiationException | IllegalAccessException | ClassNotFoundException | NoSuchMethodException | InvocationTargetException e) {
                System.out.println("not valid\n");
                e.printStackTrace();
            }
        }
    }
}
