package manage;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.DoubleStream;

public class Benchmark {

    private static final boolean printPercentages = true;
    private static final boolean printBenchmarkPercentages = true;
    private static final int max = 700;
    private static final int checks = 5;
    private static final ArrayList<Integer> skip = new ArrayList<>(Arrays.asList(684, 688, 699));

    public static void main(String[] args) {
        PrintStream dummyPS = new PrintStream(new OutputStream() {
            public void write(int b) {
            }
        });
        // Create a stream to hold the output
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        PrintStream filePS = new PrintStream(baos);

        // Save the old System.out
        PrintStream consolePS = System.out;

        // Tell Java to use your special stream
        System.setOut(filePS);

        // Benchmark Problems:
        consolePS.println("Starting Benchmark...");
        for (int i = 1; i <= max; i++) {
            if (printBenchmarkPercentages || printPercentages) {
                consolePS.print("\b".repeat(30));
                consolePS.print(String.format("%.2f", (double) i / max * 100) + "%");
            }
            if (skip.contains(i)) {
                filePS.println("/");
                continue;
            }
            try {
                for (int j = 0; j < (2 + checks); j++) {
                    if (j == 0) {
                        System.setOut(dummyPS);
                    } else if (j == 2) {
                        System.setOut(filePS);
                    }
                    startJava(i + "");
                }
            } catch (InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException | ClassNotFoundException e) {
                filePS.println("/");
            }
        }

        // Put things back
        filePS.flush();
        dummyPS.flush();
        System.setOut(consolePS);
        consolePS.println("\nBenchmark Complete.\n");

        // convert all Lines to String-Array of Times:
        String[] lines = baos.toString().split("\n");

        // create Worksheet:
        String[] cTimes = new String[lines.length];
        Arrays.fill(cTimes, "/");
        writeToExcel(fillArr(lines), cTimes);
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
            if (printPercentages) {
                System.out.print("\b".repeat(30));
                System.out.print(String.format("%.2f", (double) (i + 1) / jTimes.length * 100) + "%");
            }
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

    private static String[] fillArr(String[] lines) {
        System.out.println("Calculating averages...");
        ArrayList<String> jTimes = new ArrayList<>();
        for (int i = 0; i < lines.length; i++) {
            if (printPercentages) {
                System.out.print("\b".repeat(30));
                System.out.print(String.format("%.2f", (double) (i + 1) / lines.length * 100) + "%");
            }
            if (lines[i] != null && !lines[i].equals("")) {
                if (lines[i].contains("/")) {
                    jTimes.add("/");
                } else {
                    double[] problemTimes = new double[checks];
                    for (int j = 0; j < problemTimes.length; j++) {
                        String s = lines[i].substring(lines[i].indexOf("Time:\t") + 6);
                        problemTimes[j] = Double.parseDouble(s.substring(0, s.indexOf("s") - 1)) * ((s.substring(s.indexOf("s") - 1).contains("ms")) ? 1 : 1000);
                        i++;
                    }
                    jTimes.add(String.format("%f", DoubleStream.of(problemTimes).average().orElse(-1)));
                    i--;
                }
            }
        }
        System.out.println("\nAverages calculated.\n");
        return jTimes.toArray(new String[0]);
    }
}
