#include<iostream>
#include<cmath>
using namespace std;
double f(double x)
{
	//return x * x * x + 2 * x * x - 11;
	return x * x * x - 12 * x * x - 15 * x + 26;
}
double f1(double x)
{
	//return 3 * x * x + 4 * x;
	return 3 * x * x - 24 * x - 15;
}
double f2(double x)
{
	//return 6 * x + 4;
	return 6 * x-24;
}
double g(double x, double L)
{

	return (x + L * f(x));
}
double Dihot (double a,double b,double c,double e)
{
	int k = 0;
	do {
		c = (a + b) / 2;

		if (f(c) == 0) {
			cout << "Root: " << c;
			break;
		}
		else {
			if (f(a) * f(c) > 0) {
				a = c;
			}
			else
				b = c;
		}
			k++;
	} while (abs(a - b) > e);
	cout << "Количество итераций:" << k << endl;
	return c;
}
double Hord (double a, double b, double c, double e)
{

	int k = 0;
	double x, x0;
	if (f(a) * f2(a) > 0)
	{
		x0 = b;
		x = x0 - (x0-a) * f(x0) / (f(x0)-f(a) );
		k++;
		while (abs(x - x0) > e) {
			x0 = x;
			x = x0 - (x0 - a) * f(x0) / (f(x0) - f(a));
			k++;
		}
	}
	else
	{
		x0 = a;

		x = x0 - (b - x0) * f(x0) / (f(b) - f(x0));
		k++;
		while (abs(x - x0) > e) {
			x0 = x;
			x = x0 - (b - x0) * f(x0) / (f(b) - f(x0));
			k++;
		}
	}

	return x;
}
double Kasat(double a, double b, double e)
{
	int k = 0;
	double x, x0;
	if(f(a)*f2(a)>0)
		x0=a;
	else
		x0=b;
	x = x0 - f(x0) / f1(x0);
	k++;
	while (abs(x-x0) > e) {
		x0 = x;
		x = x0 - f(x0) / f1(x0);
		k++;
	} 
	cout << "Количество итераций:" << k << endl;
	return x;
}
double Combain(double a, double b, double c, double e)
{
	int k = 0;
	double a1 = a, b1 = b;
	if ((f(a) * f2(a)) > 0) {
		a1 = a - f(a) / f1(a);
		b1= b - f(b) * (b - a) / (f(b) - f(a));
		while (abs(a1 - b1) > e)
		{
			a = a1;
			b = b1;
			a1 = a - f(a) / f1(a);
			b1 = b - f(b) * (b - a) / (f(b) - f(a));
			k++;
		}
	}
	else {
		a1 = a - f(a) * (b - a) / (f(b) - f(a));
		b1 = b - f(b) / f1(b);
		while (abs(a1 - b1) > e)
		{
			a = a1;
			b = b1;
			a1 = a - f(a) * (b - a) / (f(b) - f(a));
			b1 = b - f(b) / f1(b);
			k++;
		}
	}
	
	c =( a1 + b1) / 2.0;
	cout << "Количество итераций:" << k << endl;
		return c;
}
double Iter(double a, double b, double x, double L, double e)
{
	int k = 0;
	double x1;
	do {
		x1 = x;
		x = g(x1, L);
		k++;
	} while (abs(x1 - x) >= e);
	
	cout << "Количество итераций:" << k << endl;
		return x;

}

int main()
{
	setlocale(LC_ALL,"Russian");
	
	long double e = 0.00001;
	double a, b,a1,a2,b1,b2;
	double c = 0;
	double min = 1000000;
	double max = -1000000;
	cout << "a:";
	cin >> a;
	cout << "b:";
	cin >> b;
	cout << "Метод хорд" << endl;
	cout << Hord(a, b, c, e) << endl;
	cout << "a1:";
	cin >> a1;
	cout << "b1:";
	cin >> b1;
	cout << "Метод хорд" << endl;
	cout << Hord(a1, b1, c, e) << endl;
	cout << "a2:";
	cin >> a2;
	cout << "b2:";
	cin >> b2;
	cout << "Метод хорд" << endl;
	cout << Hord(a2, b2, c, e) << endl;
	for (int i = a; i <= b; i++) {
		double f = f1(i);
		if (f <min)
			min = f;
		if(f>max)
			max = f;

	}
	cout << "Min: " << min << endl;
	cout << "Max: " << max << endl;
	double L = -2 / (min +max);
	cout << L << endl;
	cout << "Метод Дихотомии" << endl;
	cout << Dihot(a, b, c, e) << endl;
	cout << "Метод хорд" << endl;
	cout << Hord(a, b, c, e) << endl;
	cout << "Метод Касательных" << endl;
	cout <<Kasat(a, b, e) << endl;
	cout << "Комбинированый метод" << endl;
	cout << Combain(a, b, c, e) << endl;
	cout << "Метод простых итераций" << endl;
	cout << Iter(a,b,c,L,e) << endl;
	cout<<"g(x)=x+"<<L<<"(x*x*x+2*x-11)";
	return 0;

}
