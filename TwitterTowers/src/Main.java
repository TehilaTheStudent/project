import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static boolean is123(String str) {
        return "1".equals(str) || "2".equals(str) || "3".equals(str);
    }

    public static boolean isInteger(double number) {
        return number == (int) number;
    }

    public static void printLines(int lineLength, int startsLength, int linesCount) {
        String line;
        for (int i = 0; i < linesCount; i++) {
            line = "";
            for (int j = 0; j < (lineLength - startsLength) / 2; j++) {
                line = line + " ";
            }
            for (int j = 0; j < startsLength; j++) {
                line = line + "*";
            }
            System.out.println(line);
        }
    }

    public static void problematicCase(int width, int height) {
        System.out.println("this is a problematic case, cause the single * line must appear more than once");
        if (height == 2) {
            System.out.println("*\n*");
            return;
        }
        if (width == 1)
        {
            for(int i=0;i<height;i++)
                System.out.println("*");
            return;
        }
        //width==3
        for (int i = 0; i < height - 1; i++) {
            System.out.println(" *");
        }
        System.out.println("***");
    }

    public static void printTriangle(int width, int height) {
        //width: odd,<=height*2
        //height// >=2, (not 1)
        if (width == 1 || (width == 3 && height > 2)) {
            problematicCase(width, height);
            return;
        }
        printLines(width, 1, 1);
        int partsCount = (width - 2) / 2;
        if (partsCount > 0) {
            int partsHeight = height - 2;
            int otherParts = partsHeight / partsCount;
            int firstPart = otherParts + partsHeight % partsCount;
            printLines(width, 3, firstPart);

            for (int i = partsCount - 1; i >= 1; i--) {
                printLines(width, width - i * 2, otherParts);
            }
        }
        printLines(width, width, 1);
    }

    public static boolean isPositiveDouble(String str) {
        try {
            double number = Double.parseDouble(str);
            if (number > 0) {
                return true;
            }
        } catch (NumberFormatException e) {
        }
        return false;
    }

    public static boolean is12(String str) {
        return "1".equals(str) || "2".equals(str);
    }

    public static void main(String[] args) {
        String option;
        Scanner scanner = new Scanner(System.in);
        while (true) {
            while (true) {
                System.out.println("enter 1 for rectangle, 2 for triangle, or 3-to exit");
                option = scanner.next();
                if (is123(option))
                    break;
                System.out.println("invalid input!");
            }
            if (option.equals(("3"))) {
                System.out.println("exiting the program...");
                System.exit(0);
            }
            double height;
            double width;
            String stringHeight;
            String stringWidth;
            if (option.equals("1")) {//rectangle
                while (true) {
                    System.out.println("enter height and width of rectangle tower");
                    //height>=2, positive integers
                    stringHeight = scanner.next();
                    stringWidth = scanner.next();
                    if (isPositiveDouble(stringWidth) && isPositiveDouble(stringHeight)) {
                        width = Double.parseDouble(stringWidth);
                        height = Double.parseDouble(stringHeight);
                        break;
                    }
                    System.out.println("invalid input!");
                }
                if (Math.abs(height - width) > 5 || height == width) {
                    System.out.println("the area is: " + height * width);
                } else {
                    System.out.println("the perimeter is: " + (height + width) * 2);
                }
                //back to menu
            } else //triangle
            {
                while (true) {
                    System.out.println("enter height (>=2) and width of triangle tower");
                    //height>=2, positive numbers
                    stringHeight = scanner.next();//|
                    stringWidth = scanner.next();//_
                    if (isPositiveDouble(stringHeight) && isPositiveDouble(stringWidth)) {
                        width = Double.parseDouble(stringWidth);
                        height = Double.parseDouble(stringHeight);
                        break;
                    }
                    System.out.println("invalid input!");
                }
                String triangleOption;
                while (true) {
                    System.out.println("enter 1 to perimeter computing or 2 for triangle printing");
                    triangleOption = scanner.next();
                    if (is12(triangleOption)) {
                        break;
                    }
                    System.out.println("invalid input!");
                }
                if (triangleOption.equals("1")) {//perimeter
                    double side = (Math.sqrt(Math.pow(height, 2) + Math.pow(width, 2)));
                    System.out.println("the perimeter of the triangle is: " + (side * 2 + width));
                } else {//printing (whole integers)
                    if (width % 2 == 0)
                        System.out.println("width is not odd number! we cant print the triangle");
                    else if (width > height * 2)
                        System.out.println("width is longer than height*2! we cant print the triangle");
                    else if (!isInteger(height) || !isInteger(width))
                        System.out.println("width and height are not integers! we cant print the triangle");
                    else {//print
                        printTriangle((int) width, (int) height);
                    }
                }
                System.out.println("back to main menu:");
                //back to menu
            }
        }

    }
}