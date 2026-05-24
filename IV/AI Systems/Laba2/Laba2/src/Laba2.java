import java.util.Arrays;
import java.util.Scanner;

public class Laba2 {
    static Scanner scanner = new Scanner(System.in);
    static double[][] X = new double[2][8];
    static double[][] Y = new double[2][8];
    static double[][] Y0 = new double[2][8];
    static double[][] W = new double[2][2];
    static double[][] W0 = new double[2][1];

    static double[][] deltW = new double[2][2];
    static double[][] deltW0 = new double[2][1];
    static double[][] E = new double[2][1];
    static double[][] O = {{0}, {0}};
    static int[] res = {1, 1, 1, 1, 1, 1, 1, 1};
    static double maxX1;
    static double maxX2;

    private static double chooseMaxX1() {
        double maxX1 = 0;
        for (int i = 0; i < 8; i++) {
            if (X[0][i] > maxX1)
                maxX1 = X[0][i];
        }
        return maxX1;
    }

    private static double chooseMaxX2() {
        double maxX2 = 0;
        for (int i = 0; i < 8; i++) {
            if (X[1][i] > maxX2)
                maxX2 = X[1][i];
        }
        return maxX2;
    }

    public static void main(String[] args) {
        chooseData();
        System.out.println("--------------------------- X ----------------------");
        print(X);
        System.out.println("--------------------------- Y ----------------------");
        print(Y);
        maxX1 = chooseMaxX1();
        maxX2 = chooseMaxX2();
        //System.out.println(maxX1+"     "+maxX2);
        normalizeData();
        //test();
        //print(X);
        //func(X);
        teach();

        while(true) {
            show();
        }
        //print(deltW);


    }

    private static void show() {
        double[][] test1 = {{1}, {1}};
        double[][] test2 = {{0}, {0}};
        System.out.println("Введіть кількість осіб:");
        double x1 = scanner.nextDouble();
        System.out.println("Введіть кількість сторінок:");
        double x2 = scanner.nextDouble();
        double[][] result1 = {{x1 / maxX1}, {x2 / maxX2}};
        double[][] result2 = func(result1,0);
        if (Arrays.deepEquals(result2, test1))
            System.out.println("Роман");
        else if (Arrays.deepEquals(result2, test2))
            System.out.println("Повість");
        else
            System.out.println("Інше");
    }

    private static void teach() {
        System.out.println("Навчання починається...");
        int[] result = new int[8];
        int iter = 0;
        double[][] newX = transp(X);
        for (int i = 0; i < W.length; i++) {
            for (int j = 0; j < W[i].length; j++) {
                W[i][j] = Math.random() * (2) - 1;
            }
        }
        for (int i = 0; i < W0.length; i++) {
            W0[i][0] = Math.random() * (2) - 1;
        }
        //do {
        while(!(Arrays.equals(result, res))) {
            for (int i = 0; i < 8; i++) {
                iter++;
                Y0 = func(X, i);
                E = sub(i, Y, Y0);
                deltW = mul2(i, E, newX);
                deltW0 = E;
                W = sum(W, deltW);
                W0 = sum(W0, deltW0);
                if (Arrays.deepEquals(E, O)) {
                    result[i] = 1;
                }
            }
        }
        //}while (!(Arrays.equals(result, res))) ;
        System.out.println("Навчання закінчилось.");
        /*for (int i = 0; i < 8; i++) {
            System.out.println(result[i]);
        }*/
        System.out.println("Кількість ітерацій: "+iter);
        System.out.println("--------------------------- W ----------------------");
        print(W);
        System.out.println("--------------------------- W0 ----------------------");
        print(W0);


    }

    private static void print(double[][] arr) {
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[i].length; j++) {

                System.out.print(" " + arr[i][j] + " ");
            }
            System.out.println();
        }

    }

    private static void test() {
        double[][] a = new double[2][2];
        double[][] b = new double[2][8];
        double[][] c = new double[2][1];
        a[0][0] = 1;
        a[0][1] = 1;
        a[1][0] = 1;
        a[1][1] = 1;

        b[0][0] = 1;
        b[1][0] = 2;
        b[0][1] = 3;
        b[1][1] = 4;
        b[0][2] = 5;
        b[1][2] = 6;
        b[0][3] = 7;
        b[1][3] = 8;
        b[0][4] = 9;
        b[1][4] = 10;
        b[0][5] = 11;
        b[1][5] = 12;
        b[0][6] = 13;
        b[1][6] = 14;
        b[0][7] = 15;
        b[1][7] = 16;

        c[0][0] = 4;
        c[1][0] = 4;

        //System.out.println("------------");
       // print(c);
        System.out.println("------------");
        b=transp(b);
        print(c);
        double[][] result =mul2(0,c,b);
        print(result);
        //System.out.println("------------");
       /* double[][] result = mul(2,a,b);
        print(result);
        double[][] result2=sum(result,c);

        System.out.println("-----");
        print(result2);*/

    }

    private static double[][] func(double[][] X,int index) {
        double[][] result = mul(index, W, X);
        result = sum(result, W0);
        //print(result);
        for (int i = 0; i < result.length; i++) {
            if (result[i][0] >= 0)
                result[i][0] = 1;
            else
                result[i][0] = 0;

        }
        return result;
    }
    private static double[][] mod(double[][] a) {

        //print(result);
        for (int i = 0; i < a.length; i++) {
            for (int j=0;j<a[i].length;j++)
            {
                a[i][j]=Math.abs(a[i][j]);
            }
        }
        return a;
    }
    private static double[][] mul2(int index, double[][] a, double[][] b) {
        double[][] c = new double[1][2];
        c[0][0] = b[index][0];
        c[0][1] = b[index][1];
        int m = a.length;
        int n = c[0].length;
        int o = c.length;
        double[][] result = new double[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < o; k++) {
                    result[i][j] += a[i][k] * c[k][j];
                }
            }
        }
        return result;

    }

    private static double[][] mul(int index, double[][] a, double[][] b) {
        double[][] c = new double[2][1];
        c[0][0] = b[0][index];
        c[1][0] = b[1][index];
        int m = a.length;
        int n = c[0].length;
        int o = c.length;
        double[][] result = new double[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < o; k++) {
                    result[i][j] += a[i][k] * c[k][j];
                }
            }
        }
        return result;

    }

    private static double[][] sum(double[][] a, double[][] b) {

        int m = a.length;
        int n = a[0].length;
        double[][] result = new double[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[i][j] = a[i][j] + b[i][j];
            }
        }
        return result;

    }

    private static double[][] sub(int index, double[][] a, double[][] b) {
        double[][] c = new double[2][1];
        c[0][0] = a[0][index];
        c[1][0] = a[1][index];
        int m = b.length;
        int n = b[0].length;
        double[][] result = new double[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[i][j] = c[i][j] - b[i][j];
            }
        }
        return result;

    }

    private static double[][] transp(double[][] a) {
        double[][] result = new double[a[0].length][a.length];
       /* double [][] c= new double[2][1];
        c[0][0]=a[0][index];
        c[1][0]=a[1][index];*/
        for (int i = 0; i < a.length; i++) {
            for (int j = 0; j < a[i].length; j++) {
                result[j][i] = a[i][j];
            }
        }
        return result;

    }


    private static void normalizeData() {
        for (int i = 0; i < 8; i++) {
            X[0][i] = X[0][i] / maxX1;



            X[1][i] = X[1][i] / maxX2;

        }
        print(X);


    }

    private static void chooseData() {
        double[][] X1 = new double[2][8];
        double[][] Y1 = new double[2][8];
        double[][] X2 = new double[2][8];
        double[][] Y2 = new double[2][8];
        double[][] X3 = new double[2][8];
        double[][] Y3 = new double[2][8];
            //1
            X1[0][0] = 4;
            X1[1][0] = 20;
            Y1[0][0] = 0;
            Y1[1][0] = 0;
            //2
            X1[0][1] = 1;
            X1[1][1] = 120;
            Y1[0][1] = 0;
            Y1[1][1] = 1;
            //3
            X1[0][2] = 6;
            X1[1][2] = 200;
            Y1[0][2] = 1;
            Y1[1][2] = 1;
            //4
            X1[0][3] = 10;
            X1[1][3] = 80;
            Y1[0][3] = 1;
            Y1[1][3] = 0;
            //5
            X1[0][4] = 1;
            X1[1][4] = 80;
            Y1[0][4] = 0;
            Y1[1][4] = 0;
            //6
            X1[0][5] = 4;
            X1[1][5] = 200;
            Y1[0][5] = 0;
            Y1[1][5] = 1;
            //7
            X1[0][6] = 10;
            X1[1][6] = 120;
            Y1[0][6] = 1;
            Y1[1][6] = 1;
            //8
            X1[0][7] = 6;
            X1[1][7] = 20;
            Y1[0][7] = 1;
            Y1[1][7] = 0;


        //1
        X2[0][0] = 5;
        X2[1][0] = 10;
        Y2[0][0] = 0;
        Y2[1][0] = 0;
        //2
        X2[0][1] = 1;
        X2[1][1] = 110;
        Y2[0][1] = 0;
        Y2[1][1] = 1;
        //3
        X2[0][2] = 6;
        X2[1][2] = 200;
        Y2[0][2] = 1;
        Y2[1][2] = 1;
        //4
        X2[0][3] = 10;
        X2[1][3] = 100;
        Y2[0][3] = 1;
        Y2[1][3] = 0;
        //5
        X2[0][4] = 1;
        X2[1][4] = 100;
        Y2[0][4] = 0;
        Y2[1][4] = 0;
        //6
        X2[0][5] = 5;
        X2[1][5] = 200;
        Y2[0][5] = 0;
        Y2[1][5] = 1;
        //7
        X2[0][6] = 10;
        X2[1][6] = 110;
        Y2[0][6] = 1;
        Y2[1][6] = 1;
        //8
        X2[0][7] = 6;
        X2[1][7] = 10;
        Y2[0][7] = 1;
        Y2[1][7] = 0;


        //1
        X3[0][0] = 5;
        X3[1][0] = 1;
        Y3[0][0] = 0;
        Y3[1][0] = 0;
        //2
        X3[0][1] = 1;
        X3[1][1] = 101;
        Y3[0][1] = 0;
        Y3[1][1] = 1;
        //3
        X3[0][2] = 6;
        X3[1][2] = 200;
        Y3[0][2] = 1;
        Y3[1][2] = 1;
        //4
        X3[0][3] = 10;
        X3[1][3] = 100;
        Y3[0][3] = 1;
        Y3[1][3] = 0;
        //5
        X3[0][4] = 1;
        X3[1][4] = 100;
        Y3[0][4] = 0;
        Y3[1][4] = 0;
        //6
        X3[0][5] = 5;
        X3[1][5] = 200;
        Y3[0][5] = 0;
        Y3[1][5] = 1;
        //7
        X3[0][6] = 10;
        X3[1][6] = 101;
        Y3[0][6] = 1;
        Y3[1][6] = 1;
        //8
        X3[0][7] = 6;
        X3[1][7] = 1;
        Y3[0][7] = 1;
        Y3[1][7] = 0;
        System.out.println("-------------------------    1    --------------------------");
        print(X1);
        System.out.println("-------------------------    2    --------------------------");
        print(X2);
        System.out.println("-------------------------    3    --------------------------");
        print(X3);
        System.out.println("Оберіть приклади:");
        int ch = scanner.nextInt();
        if(ch==1)
        {
            X=X1;
            Y=Y1;
        }else if(ch==2)
        {
            X=X2;
            Y=Y2;
        }else{
            X=X3;
            Y=Y3;
        }

    }
}
