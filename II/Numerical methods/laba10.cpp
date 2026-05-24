#include <iostream>
#include <cmath>;
using namespace std;
double f1(double x, double y, double z)
{
	return z;
}
double f2(double x, double y, double z)
{
	return exp(x) + 2.2 * z + 0.8 * y;
}

void Eiler(double x[],double y[],double z[],int n,double h)
{
	x[0] = 0;
	y[0] = 1;
	z[0] = 1;
	for (int i = 1; i < n; i++)
	{
		x[i] = x[0] + i * h;
		y[i] = y[i - 1] + h * z[i - 1];
		z[i] = z[i - 1] + h * f2(x[i - 1], y[i - 1], z[i - 1]);

	}
	for (int i = 0; i < n; i++)
	{
		cout << x[i] << "       " << y[i] << endl;
	}
}
void EilerKoshi(double x[], double y[], double z[], int n, double h)
{
	x[0] = 0;
	y[0] = 1;
	z[0] = 1;
	for (int i = 1; i < n; i++)
	{
		y[1] = y[0] * h * f2(x[i - 1], y[i - 1], z[i - 1]);
		x[i] = x[0] + i * h;
		y[i] = y[i - 1] + h * z[i - 1];
		z[i] = z[i - 1] + h / 2 * ((f2(x[i - 1], y[i - 1], z[i - 1]) + f2(x[i], y[1], z[i - 1])));

		

	}
	for (int i = 0; i < n; i++)
	{
		cout << x[i] << "       " << y[i] << endl;
	}
}
int main()
{
	setlocale(LC_ALL, "Russian");
	const int n = 8;
	double a, b;
	double x[n], y[n], z[n];
	cout << "a:";
	cin >> a;
	cout << "b:";
	cin >> b;
	double h = (b - a) / n;
	cout << "Эйлер" << endl;
	Eiler(x, y, z, n, h);
	cout << "Эйлер-Коши" << endl;
	EilerKoshi(x, y, z, n, h);
	

	return 0;
}