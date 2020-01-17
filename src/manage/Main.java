package manage;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
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
//            Class.forName("java_.problems" + (inputInt / 10 * 10 + 1) + "_" + ((inputInt / 10) + 1) * 10 + ".Problem" + inputString).getDeclaredConstructor().newInstance();
            Class.forName("java_.problems" + ".Problem" + "0".repeat(4 - inputString.length()) + inputString).getDeclaredConstructor().newInstance();
        } catch (ClassNotFoundException | InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }

    private static void startCpp(String inputString) {
        int inputInt = Integer.parseInt(inputString);
        compileAndRunC("cpp\\problems" + "\\Problem" + "0".repeat(4 - inputString.length()) + inputString);
    }

    private static void compileAndRunC(String path) {
        try {
            //get Path & Command:
            String pathIn = new File("").getAbsolutePath() + "\\src\\" + path + ".c";
            String pathOut = new File("").getAbsolutePath() + "\\out\\exe" + path.substring(path.lastIndexOf('\\')) + ".exe";
            String pathToCmd = "C:\\Windows\\System32";
            String command = "g++ " + pathIn + " -o " + pathOut;

            //Start Compile Process
            Process p = new ProcessBuilder("cmd", "/c", command).directory(new File(pathToCmd)).start();

            //Konsolen Output:
            String s = null;
            BufferedReader stdError = new BufferedReader(new InputStreamReader(p.getErrorStream()));
            while ((s = stdError.readLine()) != null) {
                System.out.println(s);
            }

            //Start built Process
            p = new ProcessBuilder(pathOut).start();
            BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
            while ((s = input.readLine()) != null) {
                System.out.println(s + "\n");
            }
        } catch (IOException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }
}
