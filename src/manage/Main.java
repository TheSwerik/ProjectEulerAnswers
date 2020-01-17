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
            }
        }
    }

    private static void startJava(String inputString) {
        try {
            int start = 0;
            String till = "";
            if (Integer.parseInt(inputString) > 99) {
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
            Class.forName("java_.till" + till + ".Problem" + inputString).getDeclaredConstructor().newInstance();
        } catch (InstantiationException | IllegalAccessException | ClassNotFoundException | NoSuchMethodException | InvocationTargetException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }

    private static void startCpp(String inputString) {
        try {
            int start = 0;
            String till = "";
            if (Integer.parseInt(inputString) > 99) {
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
            Class.forName("java_.till" + till + ".Problem" + inputString).getDeclaredConstructor().newInstance();
        } catch (InstantiationException | IllegalAccessException | ClassNotFoundException | NoSuchMethodException | InvocationTargetException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }
}
