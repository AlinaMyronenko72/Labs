#include<iostream>
#include<cmath>
using namespace std;
double f(double x)
{
	//return 1 / (1 + 3 * x * x);
	return sin(x);
	//return cos(x) + (x / 20);
}
double f1(double x)
{
	return cos(x);
	//return (-6 * x) / ((1 + 3 * x * x) * (1 + 3 * x * x));
	//return (1 / 20) - sin(x);
}
//double Sum(int n,double x1, double x[100], double y[100])
//{
//    double sum = 0;
//    for (int i = 0; i <= n; i++)
//    {
//        double pr;
//        pr = 1;
//        for (int j = 0; j <= n; j++)
//        {
//            if (i != j)
//                pr *= (x1-x[j]) / (x[i] - x[j]);
//        }
//        sum += y[i] * pr;
//    }
//
//	return sum;
//}
void Three (double x[],double y[], int M,double h)
{
	cout << "По 3 узлам:"<<endl;
	
	double Y[50];
	
	Y[0] = 1 / (2.0 * h) * (-3 * y[0] + 4 * y[1] - y[2]);
	for (int i = 1; i <= M-1 ; i++)
	{
		Y[i] = 1 / (2 * h) * (-y[i - 1] + y[i + 1]);
	}
	Y[M] = 1 / (2.0 * h) * (y[M - 2] - 4 * y[M - 1] + 3 * y[M]);
	for (int i = 0; i <=M; i++)
	{
		 cout<< Y[i]<<"              "<<f1(x[i]) << endl;
	}

}
void Four(double x[], double y[], int M, double h)
{
	cout << "По 4 узлам:"<<endl;

	double Y[50];
	Y[0] = 1.0 / (6.0 * h) * (-11 * y[0] + 18 * y[1] - 9*y[2]+2*y[3]);
	Y[1] = 1.0 / (6.0 * h) * (-2 * y[0] - 3 * y[1] + 6 * y[2] - y[3]);
	for (int i = 2; i < M - 1; i++)
	{
		Y[i] = 1.0 / (6.0 * h) * ( y[i - 2] - 6 * y[i-1] + 3 * y[i] + 2*y[i +1]);
		//Y[i] = (1 / (6 * h)) * (-2 * y[i - 1] - 3 * y[i] + 6 * y[i + 1]-y[i+2]);
	}
	Y[M - 1] = 1.0 / (6.0 * h) * (y[M - 3] - 6 * y[M - 2] + 3 * y[M - 1] + 2 * y[M]);
	Y[M] = 1.0 / (6.0 * h) * (-2 * y[M - 3] + 9 * y[M - 2] - 18 * y[M - 1] + 11 * y[M]);
	for (int i = 0; i <= M; i++)
	{
		cout << Y[i] << "              " << f1(x[i]) << endl;
	}

}
void Five (double x[], double y[], int M, double h)
{
	cout << "По 5 узлам:" << endl;

	double Y[50];
	Y[0] = 1.0 / (12.0 * h) * (-25 * y[0] + 48 * y[1] - 36 * y[2] + 16 * y[3]-3*y[4]);
	Y[1] = 1.0 / (12.0 * h) * (-3 * y[0] - 10 * y[1] + 18 * y[2] - 6 * y[3] + y[4]);
	for (int i = 2; i < M-1 ; i++)
	{
		Y[i] =1.0 / (12.0 * h) * (y[i - 2] - 8 * y[i - 1] + 8 * y[i + 1] - y[i + 2]);
	}
	Y[M - 1] = 1.0 / (12.0 * h) * (-y[M - 4] + 6* y[M - 3] - 18 * y[M - 2] + 10 * y[M - 1] + 3 * y[M]);
	Y[M] = 1.0 / (12.0 * h) * (3*y[M - 4] -16 * y[M - 3] + 36 * y[M - 2] - 48 * y[M - 1] + 25 * y[M]);
	for (int i = 0; i <= M; i++)
	{
		cout << Y[i] << "              " << f1(x[i]) << endl;
	}

}
void Apro(double x[50], double y[50], int M, double h)
{
	cout << "Апроксимация:" << endl;

	double Y[50];
	Y[0]= 1.0 / (70.0 * h) * (-54 * y[0] + 13 * y[1] + 40 * y[2] + 27 * y[3] - 26 * y[4]);
	Y[1] = 1.0 / (70.0 * h) * (-34 * y[0] +3 * y[1] + 20 * y[2] +17 * y[3] -6* y[4]);
	for (int i = 2; i < M - 1; i++)
	{
		//Y[i] = (1 / (70 * h))* (-14*y[i - 2] - 7 * y[i - 1] + 7 * y[i + 1] +14*y[i + 2]);
		Y[i] =1.0 / (10.0 * h) * (-2 * y[i - 2] - y[i - 1] + y[i + 1] + 2 * y[i + 2]);
	}
	Y[M - 1] = 1.0 / (70.0 * h) * (6*y[M - 4] -17 * y[M - 3] - 20 * y[M - 2] -3*  y[M - 1] + 34 * y[M]);
	Y[M] = 1.0 / (70.0 * h) * (26 * y[M - 4] - 27 * y[M - 3] -40 * y[M - 2] - 13 * y[M - 1] + 54 * y[M]);
	for (int i = 0; i <= M; i++)
	{
		cout << Y[i] << "              " << f1(x[i]) << endl;
	}

}
int main()
{
	setlocale(LC_ALL, "Russian");
	double x[50];
	double y[50];
	double pi = 3.14159265;
	double h = 0.1;
	//double h = pi/20;
	int M = 30;
	//int M = 41;
	x[0] = -pi/2.0;
	//x[0] = -pi;
	y[0] = f(x[0]);
	/*cout << y[0] << endl;
	cout << x[0] << endl;*/
	for (int i = 1; i <31; i++)
	{
		x[i] = x[i-1] + h;
		y[i] = f(x[i]);
		//cout << y[i] << endl;
		//cout  << endl;
		//cout << x[i] << endl;
	
	}

	//cout << "Аналитически:"<<endl;

	/*cout << f1(x[0]) << endl;;
	for (int i = 1; i <=31; i++)
	{
		cout<<f1(x[i])<<endl;
	}*/
	Three(x, y, M, h);
	Four(x, y, M, h);
	Five(x, y, M, h);
	Apro(x, y, M, h);

	

	return 0;
}