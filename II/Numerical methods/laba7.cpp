#include <iostream>
#include <cmath>
using namespace std;
double f1(double x, double y)
{
	return tan(x * y) - x * x;
}
double f2(double x, double y)
{
	return 0.6 * x * x + 2.0 * y * y - 1;
}
double f1x(double x, double y)
{
	return y / (cos(x * y) * cos(x * y)) - 2 * x;
}
double f1y(double x, double y)
{
	return x / (cos(x * y) * cos(x * y)) - x * x;
}
double f2x(double x, double y)
{
	return 1.2 * x;// +2 * y * y - 1;
}
double f2y(double x, double y)
{
	return/* 0.6 * x * x +*/ 4 * y /*-1*/;
}
void SimpleIter(double e)
{
	double x0 = 0.5, y0 = 0.5;
	double det, det1, det2,det3,det4 ,x1,y1,d1,d2,d3,d4;
	double a, b, c, d;
	det = f1x(x0,y0) * f2y(x0, y0) - f1y(x0, y0) * f2x(x0, y0);
	det1 = -f2y(x0, y0);
	det2 = f1y(x0, y0);
	a = det1 / det;
	b = det2 / det;
	det3 = f2x(x0, y0);
	det4 = -f1x(x0, y0);
	c = det3 / det;
	d = det4 / det;
	x1 = x0 + a * f1(x0,y0) + b * f2(x0, y0);
	y1 = y0 + c * f1(x0, y0) + d * f2(x0, y0);
	d1 = 1 + a * f1x(x0, y0) + b * f2x(x0, y0);
	d2 = a * f1y(x0, y0) + b * f2y(x0, y0);
	d3 = c * f1x(x0, y0) + d * f2x(x0, y0);
	d4 = 1 + c * f1y(x0, y0) + d * f2y(x0, y0);
	if (fabs(d1 + d2) < 1)
		cout << "yes" << endl;
	if (fabs(d3 + d4) < 1)
		cout << "yes" << endl;
	while ((fabs(x1 - x0) > e) && (fabs(y1 - y0) > e))
	{


		x0 = x1;
		y0 = y1;
		
		x1 = x0 + a * f1(x0, y0) + b * f2(x0, y0);
		y1 = y0 + c * f1(x0, y0) + d * f2(x0, y0);


	}
	
	cout << x1 << endl;
	cout << y1 << endl;
	

}


int main()
{
	setlocale(LC_ALL, "Russian");
	long double e = 0.0001;
	double x0 = 1, y0 = 1;
	double a1,b1,j;
	a1 = -f1(x0, y0) * f2y(x0, y0) + f2(x0, y0) * f1y(x0, y0);
	b1 = f1x(x0, y0) * (-f2(x0, y0)) + f1(x0, y0) * f2x(x0, y0);
	j = f1x(x0, y0) * f2y(x0, y0) - (f1y(x0, y0) * f2x(x0, y0));
	double x1, y1;
	x1 = x0 + a1 / j;
	y1 = y0 + b1 / j;

	while ((abs(x1-x0) >e) &&( abs(y1 - y0) > e))
	{
		
		
		x0 = x1;
		y0 = y1;
		a1 = -f1(x0, y0) * f2y(x0, y0) + f2(x0, y0) * f1y(x0, y0);
		b1 = f1x(x0, y0) * (-f2(x0, y0)) + f1(x0, y0) * f2x(x0, y0);
		j = f1x(x0, y0) * f2y(x0, y0) - (f1y(x0, y0) * f2x(x0, y0));
		x1 = x0 + a1 / j;
		y1 = y0 + b1 / j;
		
		
	}
	cout << x1 << endl;
	cout << y1 << endl;
	cout << "Простых итераций" << endl;
	SimpleIter(e);
	
	return 0;
}
