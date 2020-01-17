package manage;

import java.lang.reflect.InvocationTargetException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("\nWhich do you want to try out?");
            String input = sc.next();
            if (input.equals("0")) {
                System.exit(0);
            }

            //start Problems:
            if (input.charAt(0) == 'j' || input.charAt(0) == 'J') {
                startJava(input.substring(1));
            } else if (input.charAt(0) == 'c' || input.charAt(0) == 'C') {
                startCpp(input.substring(1));
            } else if (input.matches("\\d+")) {
                startJava(input);
            }
        }
    }

    private static void startJava(String inputString) {
        try {
            int inputInt = Integer.parseInt(inputString);
            Class.forName("java_.problems" + (inputInt / 10 * 10 + 1) + "_" + ((inputInt / 10) + 1) * 10 + ".Problem" + inputString).getDeclaredConstructor().newInstance();
        } catch (ClassNotFoundException | InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }

    private static void startCpp(String inputString) {
        try {
            int inputInt = Integer.parseInt(inputString);
            Class.forName("cpp.problems" + (inputInt / 10 * 10 + 1) + "_" + ((inputInt / 10) + 1) * 10 + ".Problem" + inputString).getDeclaredConstructor().newInstance();
        } catch (ClassNotFoundException | InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }
}
