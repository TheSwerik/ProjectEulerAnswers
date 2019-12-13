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
                String inputString = input + "";
                int start = 0;
                Class.forName("till" +
                        (input > 99 ? (inputString.charAt(start++) - 48) : "") +
                        (1 + inputString.charAt(start) - 48) +
                        "0.Problem" + input).newInstance();
            } catch (InstantiationException | IllegalAccessException | ClassNotFoundException e) {
                System.out.println("not valid\n");
                e.printStackTrace();
            }
        }
    }
}
