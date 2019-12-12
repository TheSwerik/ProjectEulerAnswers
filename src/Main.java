import till100.*;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.println("\nWhich do you want to try out?");
            int input = sc.nextInt();
            if (input == 0) {
                System.exit(0);
            }
            try {
                Class.forName("till100.Problem" + input).newInstance();
            } catch (InstantiationException | IllegalAccessException | ClassNotFoundException e) {
                try {
                    Class.forName("till200.Problem" + input).newInstance();
                } catch (InstantiationException | IllegalAccessException | ClassNotFoundException ex) {
                    System.out.println("not valid\n");
                    e.printStackTrace();
                }
            }
        }
    }
}
