import java.lang.Math;
import java.text.DecimalFormat;
import java.util.Scanner;

public class Laba4 {
    public static void main(String args[]) {

        int N = 10;
        double[] a = new double[N];
        double[] b = new double[N+1];
        double[] c = new double[N];
        a = random(N);
        b = linearCongruentGenerator2(N+1);
        b[0]=b[1];
        b[1]=b[2];
        b[2]=b[3];
        b[3]=b[4];
        b[4]=b[5];
        b[5]=b[6];
        b[6]=b[7];
        b[7]=b[8];
        b[8]=b[9];
        b[9]=b[10];
        c = mixedGenerator(N);
        for (int i = 0; i < N+1; i++) {
            System.out.println(b[i]);
        }

        check(b, 4, N, 0.05);
        //correlation(a, b, c, N);



    }

    static double[] random(int N) {
        double[] a = new double[N];
        for (int i = 0; i < N; i++) {
            a[i] = Math.random();

        }
        return a;
    }

    static double[] mixedGenerator(int N) {
        double[] z1 = new double[N];
        double[] z2 = new double[N];
        double[] y = new double[N];
        z1[0] = 123;
        z1[1] = 343;
        z1[2] = 567;
        z2[0] = 214;
        z2[1] = 245;
        z2[2] = 467;
        double mod1 = Math.pow(2, 32) - 209;
        double mod2 = Math.pow(2, 32) - 22853;
        for (int i = 3; i < N; i++) {
            z1[i] = (1403580 * z1[i - 2] - 810728 * z1[i - 3]) % mod1;
            z2[i] = (527612 * z2[i - 1] - 1370589 * z2[i - 3]) % mod2;
        }
        for (int i = 0; i < N; i++) {
            y[i] = (z1[i] - z2[i]) % mod1;
        }
        for (int i = 0; i < N; i++) {
            y[i] = Math.abs(y[i] / mod1);
        }
        return y;
    }


    static double[] linearCongruentGenerator(int N) {
        double[] z = new double[N];
        z[0] = 4;
        double mod = Math.pow(2, 31) - 1;
        for (int i = 1; i < N; i++) {
            z[i] = (630360016 * z[i - 1]) % mod;
        }
        for (int i = 0; i < N; i++) {
            z[i] = z[i] / mod;
        }
        return z;

    }
    static double[] linearCongruentGenerator2(int N) {
        double[] z = new double[N];
        z[0] = 442;
        double mod = 32;
        for (int i = 1; i < N; i++) {
            z[i] = (243 * z[i - 1]+72) % mod;
        }
        for (int i = 0; i < N; i++) {
            z[i] = z[i] / (mod-1);
        }
        return z;

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
        System.out.println("sampleAverage " +sampleAverage);
        double sampleVariance = 0;
        for (int i = 0; i < k; i++) {
            sampleVariance += middleinter[i] * middleinter[i] * inter[i];
        }
        sampleVariance = (sampleVariance / N) - (sampleAverage * sampleAverage);
        System.out.println("sampleVariance " +sampleVariance);
        double sampleStandardDeviation = Math.sqrt(sampleVariance);
        System.out.println("sampleStandardDeviation " +sampleStandardDeviation);
        double a1 = sampleAverage - (Math.sqrt(3) * sampleStandardDeviation);
        System.out.println("a1 " +a1);
        double b1 = sampleAverage + (Math.sqrt(3) * sampleStandardDeviation);
        System.out.println("b1 " +b1);
        double f = 1 / (b1 - a1);
        System.out.println("f " +f);
        double[] n = new double[k];
        n[0] = N * f * (x1[0] - a1);
        for (int i = 1; i < k - 1; i++) {
            n[i] = N * f * (x1[i] - x[i]);

        }
        n[k - 1] = N * f * (b1 - x1[k - 2]);


        for (int i = 0; i < 4; i++) {
            System.out.println("n " + n[i]+"x1 "+x1[i]);

        }

        double res = 0;
        for (int i = 0; i < k; i++) {
            //res += ((n[i] - inter[i]) * (n[i] - inter[i])) / inter[i];
            res += ((n[i] - inter[i]) * (n[i] - inter[i])) / n[i];

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


    static void correlation(double[] a, double[] b, double[] c, int N) {
        double x = 0;
        for (int i = 0; i < N; i++) {
            x += a[i];

        }
        x = x / N;
        double y = 0;
        for (int i = 0; i < N; i++) {
            y += b[i];

        }
        y = y / N;

        double z = 0;
        for (int i = 0; i < N; i++) {
            z += c[i];

        }
        z = z / N;

        double xy = 0;
        for (int i = 0; i < N; i++) {
            xy += a[i] * b[i];
        }
        xy = xy / N;

        double xz = 0;
        for (int i = 0; i < N; i++) {
            xz += a[i] * c[i];
        }
        xz = xz / N;

        double sampleVarianceForA = 0;
        for (int i = 0; i < N; i++) {
            sampleVarianceForA += a[i] * a[i];
        }
        sampleVarianceForA = (sampleVarianceForA / N) - (x * x);
        double sampleStandardDeviationForA = Math.sqrt(sampleVarianceForA);
        double sampleVarianceForB = 0;
        for (int i = 0; i < N; i++) {
            sampleVarianceForB += b[i] * b[i];
        }
        sampleVarianceForB = (sampleVarianceForB / N) - (y * y);

        double sampleVarianceForC = 0;
        for (int i = 0; i < N; i++) {
            sampleVarianceForC += c[i] * c[i];
        }
        sampleVarianceForC = (sampleVarianceForC / N) - (z * z);
        double sampleStandardDeviationForC = Math.sqrt(sampleVarianceForC);

        double sampleStandardDeviationForB = Math.sqrt(sampleVarianceForB);

        double correlationAB = (xy - x * y) / (sampleStandardDeviationForA * sampleStandardDeviationForB);
        System.out.println("Корреляция(встроеный генератор и смешаный генератор): " + Math.abs(correlationAB));

        double correlationAC = (xz - x * z) / (sampleStandardDeviationForA * sampleStandardDeviationForC);
        System.out.println("Корреляция(встроеный генератор и ЛКГ): " + Math.abs(correlationAC));


    }

}
