package manage;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.lang.reflect.InvocationTargetException;
import java.util.Arrays;

public class Benchmark {

    private static final int max = 699;
    private static final int[] skip = {684, 688, 699};
    private static int skipIndex = 0;

    public static void main(String[] args) {
        // Create a stream to hold the output
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        PrintStream ps = new PrintStream(baos);

        // Save the old System.out
        PrintStream old = System.out;

        // Tell Java to use your special stream
        System.setOut(ps);

        // Benchmark Problems:
        for (int i = 1; i <= max; i++) {
            if (i == skip[skipIndex]) {
                skipIndex++;
                System.out.println("/");
                continue;
            }
            try {
                startJava(i + "");
            } catch (InstantiationException | InvocationTargetException | NoSuchMethodException | IllegalAccessException | ClassNotFoundException e) {
                System.out.println("/");
            }
        }

        // convert all Lines to String-Array of Times:
        String[] lines = baos.toString().split("\n");
        String[] jTimes = new String[lines.length];
        for (int i = 0; i < lines.length; i++) {
            if (lines[i] != null && !lines[i].equals("")) {
                if (lines[i].contains("/")) {
                    jTimes[i] = lines[i];
                } else {
                    String s = lines[i].substring(lines[i].indexOf("Time:\t") + 6);
                    if (s.substring(s.indexOf("s") - 1).contains("ms")) {
                        jTimes[i] = s.substring(0, s.indexOf("s") - 1);
                    } else {
                        jTimes[i] = (Double.parseDouble(s.substring(0, s.indexOf("s") - 1)) * 1000) + "";
                    }
                }
            }
        }

        // Put things back
        System.out.flush();
        System.setOut(old);

        // create Worksheet:
        String[] cTimes = new String[lines.length];
        Arrays.fill(cTimes, "/");
        writeToExcel(jTimes, cTimes);
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
        for (int i = 0; i < max; i++) {
            row = spreadsheet.createRow(1 + i);

            // Problem number:
            cell = row.createCell(0);
            cell.setCellValue(i + "");
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
        } catch (IOException e) {
            e.printStackTrace();
        }

        System.out.println("EulerBenchmark.xlsx written successfully.");
    }
}
