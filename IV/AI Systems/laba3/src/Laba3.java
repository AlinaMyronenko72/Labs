import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Laba3 {
    static Scanner scanner = new Scanner(System.in);
    static double[][] X = new double[10][5];
    static ArrayList<double[]> e = new ArrayList<>();
    //static ArrayList<double[]> prevE = new ArrayList<>();
    static double[] Y;
    static ArrayList<Integer> W = new ArrayList<>();
    static int klaster;


    static int index;

    public static void main(String[] args) {
        enterData();
        print(X);
        System.out.println("На скільки кластерів поділити вибірку?");
        klaster = scanner.nextInt();
        initialValues();
        CalculateProcess();
        Clacification();
        // printList(e);
        // System.out.println(W);
        // double[]test=calculateAllDistances();

        /*for (int i=0;i<klaster;i++){
            System.out.println(test[i]);
        }*/

       /* double a=calculateDistance(X,klaster,e.get(0));
        System.out.println(a);*/
        //double[]test=calculateDistance(X,klaster);

        /*for (int i=0;i<5;i++){
            System.out.println(test[i]);
        }*/

        //printList(e);
        //System.out.println(W);


    }

    private static void Clacification() {
        Y = new double[X[0].length];
        while (true) {
            System.out.println("Введіть оцінки:");
            Y[0] = scanner.nextInt();
            Y[1] = scanner.nextInt();
            Y[2] = scanner.nextInt();
            Y[3] = scanner.nextInt();
            Y[4] = scanner.nextInt();
            double dist[] = calculateDistanceY(Y);
            int min = chooseIndexMin(dist);
            System.out.println("Це відноситься до " + (min + 1) + " кластеру");
        }
    }

    private static void CalculateProcess() {
        double[] distances = new double[klaster];
        double[] prevE = new double[e.get(0).length];
        int indexMin = 0;
        double krit = 1;
        index = klaster;
        ArrayList<double[]> temp = new ArrayList<>();
        //for (int i=0;i<10;i++){
        while (krit > 0.1) {
            if (index == X.length)
                index = 0;
            /*System.out.println("----------e-----------");
            printList(e);
            System.out.println("----------X-----------");
            print(X);*/
            distances = calculateAllDistances();
            /*System.out.println("----------dis-----------");
            print2(distances);*/
            indexMin = chooseIndexMin(distances);
            /*System.out.println("----------minindex-----------");
            System.out.println(indexMin);*/
           /* System.out.println("e-------------------------------");
            printList(e);*/
            //prevE = e;
            //temp.addAll(e);
            //temp= (ArrayList<double[]>) e.clone();
            //prevE.addAll(temp);
            //prevE= (ArrayList<double[]>) temp.clone();
            //prevE.addAll(e);
            prevE = e.get(indexMin).clone();
            //System.out.println("----------preve-----------");
            //printList(prevE);
           /* System.out.println("preve-------------------------------");
            printList(prevE);*/
            calculateNewE(indexMin, index);
            /*System.out.println("----------newe-----------");
            printList(e);*/
            CalculateNewW(indexMin);
            //System.out.println("----------newW-----------");
            //print(W);
            index++;
           /* System.out.println("e-------------------------------");
            printList(e);
            System.out.println("preve-------------------------------");
            printList(prevE);*/
            krit = calculateDistanceE(indexMin, prevE);
            /*System.out.println("krit-------------------------------");
            System.out.println(krit);*/
            //prevE=new ArrayList<>();
            prevE = new double[e.get(0).length];
            temp = new ArrayList<>();
            //krit=0;
        }
        /*System.out.println("krit-------------------------------");
        System.out.println(krit);*/
        System.out.println("-----------------е-------------------");
        printList(e);
        for (int i=0;i<klaster;i++) {
            System.out.println("W"+(i+1)+": "+W.get(i));
        }

    }

    private static double calculateDistanceE(int indexMin, double[] array1) {
        /*double[] a1 = new double[X[0].length];

        for (int i = 0; i < X[0].length; i++) {
            a1[i] = A[index][i];
        }*/
        double distance = 0;
        // double[]array1=prevE.get(indexMin);
        double[] array2 = e.get(indexMin);
        /*System.out.println("eee----eee----eee----");
        printList(e);
        System.out.println("ppppppppppppppppppppppeee----eee----eee----");
        printList(prevE);*/
        for (int i = 0; i < e.get(indexMin).length; i++) {

            distance += Math.abs(array1[i] - array2[i]);
        }
        return distance;
    }

    private static void CalculateNewW(int indexMin) {
        int temp = W.get(indexMin);
        temp++;
        W.set(indexMin, temp);
    }

    private static void calculateNewE(int indexMin, int index) {
        double[] temp = mulScalar(W.get(indexMin), e.get(indexMin));
        temp = sum(temp, X[index]);
        double[] temp2 = divScalar(W.get(indexMin) + 1, temp);
        e.set(indexMin, temp2);
       /* System.out.println("------------------e--------------------");
        printList(e);*/
        //temp=

    }

    private static double[] mulScalar(int scalar, double[] array) {
        for (int i = 0; i < array.length; i++) {
            array[i] = array[i] * scalar;
        }
        return array;

    }

    private static double[] divScalar(int scalar, double[] array) {
        for (int i = 0; i < array.length; i++) {
            array[i] = array[i] / scalar;
        }
        return array;

    }

    private static double[] sum(double[] array1, double[] array2) {
        double[] result = new double[array1.length];
        for (int i = 0; i < result.length; i++) {
            result[i] = array1[i] + array2[i];
        }
        return result;

    }

    private static double[] sub(double[] array1, double[] array2) {
        double[] result = new double[array1.length];
        for (int i = 0; i < result.length; i++) {
            result[i] = array1[i] - array2[i];
        }
        return result;

    }

    private static double[] calculateDistanceY(double[] Y) {
        double[] distance = new double[klaster];

        for (int i = 0; i < klaster; i++) {
            distance[i] = calculateDistance2(Y, e.get(i));
        }
        return distance;


    }

    private static double[] calculateAllDistances() {
        double[] distance = new double[klaster];
        //index = klaster;
        for (int i = 0; i < klaster; i++) {
            distance[i] = calculateDistance(X, index, e.get(i));
        }

        return distance;
    }


    private static double chooseMin(double[] array) {
        double min = 0;
        for (int i = 0; i < array.length; i++) {
            if (array[i] < min)
                min = array[i];
        }
        return min;
    }

    private static int chooseIndexMin(double[] array) {
        double min = array[0];
        int indexMin = 0;
        for (int i = 0; i < array.length; i++) {
            if (array[i] < min) {
                min = array[i];
                indexMin = i;
            }

        }
        return indexMin;
    }

    private static double calculateDistance(double[][] A, int index, double[] a2) {
        double[] a1 = new double[X[0].length];
        double distance = 0;
        for (int i = 0; i < X[0].length; i++) {
            a1[i] = A[index][i];
        }
        for (int i = 0; i < X[0].length; i++) {
            distance += Math.abs(a1[i] - a2[i]);
        }
        return distance;

    }

    private static double calculateDistance2(double[] Y, double[] a2) {
        //double[] a1 = new double[X[0].length];
        double distance = 0;
        /*for (int i = 0; i < X[0].length; i++) {
            a1[i] = A[index][i];
        }*/
        for (int i = 0; i < X[0].length; i++) {
            distance += Math.abs(Y[i] - a2[i]);
        }
        return distance;

    }


    private static void printList(ArrayList<double[]> e) {
        for (int i = 0; i < klaster; i++) {
            System.out.println(Arrays.toString(e.get(i)));
        }
    }

    private static void initialValues() {
        for (int i = 0; i < klaster; i++) {
            W.add(1);
            e.add(X[i]);
        }
    }

    private static void print(double[][] arr) {
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[i].length; j++) {

                System.out.print(" " + arr[i][j] + " ");
            }
            System.out.println();
        }

    }

    private static void print2(double[] arr) {
        for (int i = 0; i < arr.length; i++) {
            System.out.println(" " + arr[i] + " ");
        }

    }

    private static void enterData() {
        //X1
        X[0][0] = 5;
        X[0][1] = 4;
        X[0][2] = 3;
        X[0][3] = 4;
        X[0][4] = 3;
        //X2
        X[1][0] = 3;
        X[1][1] = 4;
        X[1][2] = 3;
        X[1][3] = 3;
        X[1][4] = 3;
        //X3
        X[2][0] = 4;
        X[2][1] = 5;
        X[2][2] = 3;
        X[2][3] = 5;
        X[2][4] = 5;
        //X5
        X[3][0] = 5;
        X[3][1] = 4;
        X[3][2] = 5;
        X[3][3] = 5;
        X[3][4] = 5;
        //X6
        X[4][0] = 5;
        X[4][1] = 5;
        X[4][2] = 5;
        X[4][3] = 5;
        X[4][4] = 5;
        //X7
        X[5][0] = 3;
        X[5][1] = 3;
        X[5][2] = 3;
        X[5][3] = 3;
        X[5][4] = 3;
        //X8
        X[6][0] = 2;
        X[6][1] = 5;
        X[6][2] = 4;
        X[6][3] = 3;
        X[6][4] = 4;
        //X9
        X[7][0] = 5;
        X[7][1] = 4;
        X[7][2] = 3;
        X[7][3] = 3;
        X[7][4] = 3;
        //X10
        X[8][0] = 4;
        X[8][1] = 4;
        X[8][2] = 4;
        X[8][3] = 4;
        X[8][4] = 4;
        //X2
        X[9][0] = 5;
        X[9][1] = 5;
        X[9][2] = 4;
        X[9][3] = 4;
        X[9][4] = 4;
//X1
       /* X[0][0] = 5;
        X[0][1] = 4;
        X[0][2] = 3;
        X[0][3] = 4;
        X[0][4] = 5;
        //X2
        X[1][0] = 3;
        X[1][1] = 4;
        X[1][2] = 3;
        X[1][3] = 3;
        X[1][4] = 3;
        //X3
        X[2][0] = 4;
        X[2][1] = 5;
        X[2][2] = 4;
        X[2][3] = 3;
        X[2][4] = 3;
        //X5
        X[3][0] = 5;
        X[3][1] = 4;
        X[3][2] = 5;
        X[3][3] = 5;
        X[3][4] = 5;
        //X6
        X[4][0] = 5;
        X[4][1] = 5;
        X[4][2] = 5;
        X[4][3] = 5;
        X[4][4] = 5;
        //X7
        X[5][0] = 3;
        X[5][1] = 3;
        X[5][2] = 3;
        X[5][3] = 3;
        X[5][4] = 3;
        //X8
        X[6][0] = 2;
        X[6][1] = 2;
        X[6][2] = 3;
        X[6][3] = 3;
        X[6][4] = 3;
        //X9
        X[7][0] = 5;
        X[7][1] = 4;
        X[7][2] = 3;
        X[7][3] = 3;
        X[7][4] = 3;
        //X10
        X[8][0] = 4;
        X[8][1] = 4;
        X[8][2] = 4;
        X[8][3] = 4;
        X[8][4] = 4;
        //X2
        X[9][0] = 5;
        X[9][1] = 5;
        X[9][2] = 4;
        X[9][3] = 4;
        X[9][4] = 4;*/

    }
}
