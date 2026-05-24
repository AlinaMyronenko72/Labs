#include<iostream>
#include<cmath>
# define PI           3.14159265358979323846
using namespace std;

double f(double x)
{
	return sin(x*x);
}
double CH(double a, double b, int n)
{
	double x[6] = { -0.866247, -0.422519, -0.266636, 0.266636, 0.422519 ,0.866247 };
	double sum = 0;
	for (int i = 1; i <= n; i++)
	{

		sum += f(((a + b) / 2) + (((b - a) / 2) * x[i - 1]));

	}
	return sum;
}
double Gaus(double a, double b, int n)
{
	double x[6] = { -0.9324695, -0.6612093, -0.2386192,0.2386192 ,0.6612093,0.9324695 };
	double c[6] = { 0.1713245, 0.3607616, 0.4679131,0.4679131,0.3607616,0.1713245 };
	double sum = 0;
	for (int i = 1; i <= n; i++)
	{

		sum += c[i - 1] * (f(((a + b) / 2) + (((b - a) / 2) * x[i - 1])));

	}
	return sum;
}
void Parabol(double a, double b, int n)
{
	double temp = 2 * n;
	double h1 = (b - a) / (temp);
	double S4 = 0, S5 = 0;
	for (int i = 1; i <= n; i++)
	{
		double temp1 = 2 * i;
		double x1 = (a + (temp1 - 1) * h1);

		S4 = S4 + f(x1);
		double x2 = x1 + h1;
		S5 = S5 + f(x2);
	}
	double S6 = ((h1 / 3) * (f(a) + 4 * S4 + 2 * S5 - f(b)));
	cout << S6 << endl;
}
int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Метод Чебышова:" << endl;
	double a = 0.0, b = PI/4;
	int n2 = 6;
	double l2 = (b - a) / n2;
	double L= (b - a) / 2;
	double sum2=0;
	double sumg2 = 0;
	sum2 = CH(a, b, n2);
	sumg2 = Gaus(a, b, n2);
	double Sum2,Sumg2;
	Sum2 = l2 * sum2;
	Sumg2 = L * sumg2;
	cout << Sum2 << endl;
	cout << "Метод Гаусса:" << endl;
	cout << Sumg2 << endl;
	cout << "Метод парабол:" << endl;
	Parabol(a, b, n2);
	return 0;



}