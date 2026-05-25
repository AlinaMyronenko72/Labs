import java.lang.Math;
import java.util.Scanner;

public class Laba3 {
    public static void main(String args[]) {

        int N = 1000;
        double[] a = new double[N];
        double[] b = new double[N];
        double[] c = new double[N];
        a = random(N);
        b = middleSquares(1234, N);
        c = middleProduct(3856, 2894, N);
        /*for (int i = 0; i < N; i++) {
            System.out.println(c[i]);
        }*/
        check(a, 4, N, 0.1);



    }

    static double[] random(int N) {
        double[] a = new double[N];
        for (int i = 0; i < N; i++) {
            a[i] = Math.random();
        }
        return a;
    }

    static double[] middleProduct(int n, int n2, int N) {
        double[] c = new double[N];
        for (int i = 0; i < N; i++) {
            int product = n * n2;
            int num = (int) Math.log10(product) + 1;
            int[] a = new int[num];
            int[] b = new int[4];
            for (int j = 0; j < num; j++) {
                a[j] += product % 10;
                product /= 10;
            }
            for (int k = 0; k < a.length / 2; k++) {
                int temp = a[k];
                a[k] = a[a.length - k - 1];
                a[a.length - k - 1] = temp;
            }
            int start;
            if (a.length == 4 || a.length < 4) {
                start = 0;
            } else
                start = a.length / 4;
            b[0] = a[start];
            b[1] = a[start + 1];
            b[2] = a[start + 2];
            b[3] = a[start + 3];
            n = n2;
            n2 = 0;
            for (int p = 0; p < 4; p++)
                n2 = n2 * 10 + b[p];
            double r = (double) n2 / 10000;
            c[i] = r;
        }
        return c;

    }

    static double[] middleSquares(int n, int N) {
        double[] c = new double[N];
        for (int i = 0; i < N; i++) {
            int square = n * n;
            int num = (int) Math.log10(square) + 1;
            int[] a = new int[num];
            int[] b = new int[4];
            for (int j = 0; j < num; j++) {
                a[j] += square % 10;
                square /= 10;
            }
            for (int k = 0; k < a.length / 2; k++) {
                int temp = a[k];
                a[k] = a[a.length - k - 1];
                a[a.length - k - 1] = temp;
            }
            int start;
            if (a.length == 4 || a.length < 4) {
                start = 0;
            } else
                start = a.length / 4;
            b[0] = a[start];
            b[1] = a[start + 1];
            b[2] = a[start + 2];
            b[3] = a[start + 3];
            n = 0;
            for (int p = 0; p < 4; p++)
                n = n * 10 + b[p];
            double r = (double) n / 10000;
            c[i] = r;
        }
        return c;


    }

    static void check(double[] a, int k, int N, double significanceLevel) {
        double interval = 1 / (double) k;
        int count = 0;
        int[] inter = new int[k];
        double[] middleinter = new double[k];
        double[] x1 = new double[k];
        double[] x = new double[k];
        double j = 0;

        for (int p = 0; p < k; p++) {
            for (int i = 0; i < N; i++) {
                if (a[i] > j && a[i] < j + interval) {
                    count++;
                }
            }

            middleinter[p] = (j + j + interval) / 2;
            x1[p] = j + interval;
            x[p] = j;
            inter[p] = count;
            System.out.println("Интервал от " + x[p] + " до " + x1[p] + ": " + inter[p]);
            count = 0;

            j = j + interval;
        }

        double sampleAverage = 0;
        for (int i = 0; i < k; i++) {
            sampleAverage += middleinter[i] * inter[i];
        }
        sampleAverage = sampleAverage / N;
        double sampleVariance = 0;
        for (int i = 0; i < k; i++) {
            sampleVariance += middleinter[i] * middleinter[i] * inter[i];
        }
        sampleVariance = (sampleVariance / N) - (sampleAverage * sampleAverage);
        double sampleStandardDeviation = Math.sqrt(sampleVariance);

        double a1 = sampleAverage - (Math.sqrt(3) * sampleStandardDeviation);

        double b1 = sampleAverage + (Math.sqrt(3) * sampleStandardDeviation);

        double f = 1 / (b1 - a1);

        double[] n = new double[k];
        n[0] = N * f * (x1[0] - a1);
        for (int i = 1; i < k - 1; i++) {
            n[i] = N * f * (x1[i] - x[i]);

        }
        n[k - 1] = N * f * (b1 - x1[k - 2]);

        double res = 0;
        for (int i = 0; i < k; i++) {
            res += ((n[i] - inter[i]) * (n[i] - inter[i])) / inter[i];

        }
        System.out.println(res);
        int m = k - 3;
        Scanner in = new Scanner(System.in);
        System.out.print("Значение хи-квадрат при степени свободы: " + m + " и уровню значимости: " + significanceLevel + ": ");
        double num = in.nextDouble();
        in.close();
        if (res < num)
            System.out.println("Принимається нулевая гипотеза, выборка подчиняется равномерному закону распределению.");
        else
            System.out.println("Принимається первая гипотеза, выборка не подчиняется равномерному закону распределению.");


    }


}
