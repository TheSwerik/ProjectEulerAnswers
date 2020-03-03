package manage;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.lang.reflect.InvocationTargetException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.DoubleStream;

public class Benchmark {

    private static final int max = 700;
    private static final int checks = 25;
    private static final ArrayList<Integer> skip = new ArrayList<>(Arrays.asList(684, 688, 699));
    private static PrintStream dummyPS;
    private static PrintStream cfilePS;

    public static void main(String[] args) throws InterruptedException {
        dummyPS = new PrintStream(new OutputStream() {
            public void write(int b) {
            }
        });
        // Create a stream to hold the output
        ByteArrayOutputStream jbaos = new ByteArrayOutputStream();
        PrintStream jfilePS = new PrintStream(jbaos);
        ByteArrayOutputStream cbaos = new ByteArrayOutputStream();
        cfilePS = new PrintStream(cbaos);

        // Save the old System.out
        PrintStream consolePS = System.out;

        // Tell Java to use your special stream
        System.setOut(jfilePS);

        // Benchmark Problems:
        consolePS.println("Starting Benchmark...");
        for (int i = 1; i <= max; i++) {
            // run skip infinite loops:
            if (skip.contains(i)) {
                jfilePS.println("/");
                cfilePS.println("/");
                continue;
            }
            // run Java:
            consolePS.print("\r" + String.format("%.2f", (double) i / max * 100) + "%\t" + "Problem " + i + " in Java...");
            try {
                for (int j = 0; j < (2 + checks); j++) {
                    if (j == 0) {
                        System.setOut(dummyPS);
                    } else if (j == 2) {
                        System.setOut(jfilePS);
                    }
                    startJava(i + "");
                }
            } catch (InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException | ClassNotFoundException e) {
                jfilePS.println("/");
            }
            // run C++:
            consolePS.print("\r" + String.format("%.2f", (double) i / max * 100) + "%\t" + "Problem " + i + " in C++...");
            startCpp(i + "");
        }

        // Cleanup PrintStreams
        jfilePS.flush();
        dummyPS.flush();
        cfilePS.flush();
        System.setOut(consolePS);
        consolePS.println("\nBenchmark Complete.\n");

        // convert all Lines to String-Array of Times:
        String[] jLines = jbaos.toString().split("\n");
        String[] cLines = cbaos.toString().split("\n");

        // create Worksheet:
        String[] cArr = fillArr(cLines, false);
        writeToExcel(fillArr(jLines, true), cArr);
    }

    private static void startJava(String inputString) throws ClassNotFoundException, NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        int inputInt = Integer.parseInt(inputString);
        Class.forName("java_.problems" + ".Problem" + "0".repeat(4 - inputString.length()) + inputString).getDeclaredConstructor().newInstance();
    }

    private static void writeToExcel(String[] jTimes, String[] cTimes) {
        System.out.println("Writing Sheet...");

        XSSFWorkbook workbook = new XSSFWorkbook();
        XSSFSheet spreadsheet = workbook.createSheet("Project Euler Benchmark");
        XSSFRow row;

        //Title Row:
        row = spreadsheet.createRow(0);
        // Problem number:
        Cell cell = row.createCell(0);
        cell.setCellValue("Problem");
        // Java Time:
        cell = row.createCell(1);
        cell.setCellValue("Java Times (ms)");
        // C++ time:
        cell = row.createCell(2);
        cell.setCellValue("C++ Times (ms)");
        for (int i = 0; i < jTimes.length; i++) {
            System.out.print("\r" + String.format("%.2f", (double) (i + 1) / jTimes.length * 100) + "%");
            row = spreadsheet.createRow(1 + i);

            // Problem number:
            cell = row.createCell(0);
            cell.setCellValue((i + 1) + "");
            // Java Time:
            cell = row.createCell(1);
            cell.setCellValue(jTimes[i]);
            // C++ time:
            cell = row.createCell(2);
            cell.setCellValue(cTimes[i]);
        }

        //Write the workbook in file system
        try (FileOutputStream out = new FileOutputStream(new File("EulerBenchmark.xlsx"))) {
            workbook.write(out);
            System.out.println("\nEulerBenchmark.xlsx written successfully.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static String[] fillArr(String[] lines, boolean isJava) {
        System.out.println("Calculating " + (isJava ? "Java " : "C++ ") + "averages...");
        ArrayList<String> times = new ArrayList<>();
        for (int i = 0; i < lines.length; i++) {
            System.out.print("\r" + String.format("%.2f", (double) (i + 1) / lines.length * 100) + "%");
            if (lines[i] != null && !lines[i].equals("")) {
                if (lines[i].contains("/")) {
                    times.add("/");
                } else {
                    double[] problemTimes = new double[checks];
                    for (int j = 0; j < problemTimes.length; j++) {
                        String s = lines[i].substring(lines[i].indexOf("Time:\t") + 6);
                        problemTimes[j] = Double.parseDouble(s.substring(0, s.indexOf("s") - 1)) * ((s.substring(s.indexOf("s") - 1).contains("ms")) ? 1 : 1000);
                        i++;
                    }
                    times.add(new DecimalFormat("0.######").format(DoubleStream.of(problemTimes).average().orElse(-1)));
                    i--;
                }
            }
        }
        System.out.println("\nAverages calculated.\n");
        return times.toArray(new String[0]);
    }

    private static void startCpp(String inputString) {
        int inputInt = Integer.parseInt(inputString);
        compileAndRunC("cpp\\problems" + "\\Problem" + "0".repeat(4 - inputString.length()) + inputString);
    }

    private static void compileAndRunC(String path) {
        try {
            //get Path & Command:
            String pathIn = new File("").getAbsolutePath() + "\\src\\" + path + ".cpp";
            if (!new File(pathIn).exists()) {
                cfilePS.println("/");
                return;
            }
            String pathOut = new File("").getAbsolutePath() + "\\out\\exe" + path.substring(path.lastIndexOf('\\')) + ".exe";
            String pathToCmd = "C:\\Windows\\System32";
            String command = "g++ " + pathIn + " -o " + pathOut;

            //create folder if it doesnt exist:
            File pathOutFile = new File(new File("").getAbsolutePath() + "\\out\\exe\\");
            if (!pathOutFile.exists()) {
                pathOutFile.mkdirs();
            }

            //Start Compile Process
            Process p = new ProcessBuilder("cmd", "/c", command).directory(new File(pathToCmd)).start();
            p.waitFor();

            //Start built Process
            String s = null;
            for (int i = 0; i < 2 + checks; i++) {
                if (i == 0) {
                    System.setOut(dummyPS);
                } else if (i == 2) {
                    System.setOut(cfilePS);
                }
                p = new ProcessBuilder(pathOut).start();
                BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
                while ((s = input.readLine()) != null) {
                    System.out.println(s);
                }
            }
        } catch (IOException | InterruptedException e) {
            System.out.println("not valid\n");
            e.printStackTrace();
        }
    }
}
