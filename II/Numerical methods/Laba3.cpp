#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;
int main()
{
	long double e = 0.00001;
	double a = 0, b, c = 0, y, x = 0;
	cout << "a:";
	cin >> a;
	cout << "b:";
	cin >> b;
//	y = x * x * x + 2 * x * x - 11;
	cout << "Метод хорд" << endl;
	double aa = a * a * a + 2 * a * a - 11;


	double x0 , x1;
	while ((abs(a - b)) > e) {
		if ((aa * (6 * a + 4) )< 0) {
			x0 = b;

			double x0x0 = x0 * x0 * x0 + 2 * x0 * x0 - 11;
			x1 = x0 - (x0 - a) * (x0x0 / (x0x0 - aa));
		}
		else {
			x0 = a;
			double bb = b * b * b + 2 * b * b - 11;
			double x0x0 = x0 * x0 * x0 + 2 * x0 * x0 - 11;
			x1 = x0 - (b - x0) * (x0x0 / (bb - x0x0));
		}
	}
	cout << "Root: " << b << endl;
	return 0;
}

//void sum(int n, double x[100], double y[100])
//{
//    double sum = 0;
//    for (int i = 0; i <= n; i++)
//    {
//        double pr;
//        pr = 1;
//        for (int j = 0; j <= n; j++)
//        {
//            if (i != j)
//                pr *= (-x[j]) / (x[i] - x[j]);
//        }
//        sum += y[i] * pr;
//    }
//    cout << "Sum=" << setprecision(5) << sum << endl;
//    double prov;
//    prov = exp(-sum) - sum;
//    cout << setprecision(5) << prov << endl;
//
//}
//int main()
//{
//    int n;
//    double a, b;
//    double x[100], y[100];
//    cout << "n:";
//    cin >> n;
//    cout << "a:";
//    cin >> a;
//    cout << "b:";
//    cin >> b;
//    double h = 0.05;
//    cout << "x:" << endl;
//    for (int i = 0; i < n; i++)
//    {
//        x[i] = a;
//        a += h;
//        cout << x[i] << endl;
//    }
//    cout << "y:" << endl;
//    for (int i = 0; i < n; i++)
//    {
//        y[i] = exp(-x[i]) - x[i];
//        cout << setprecision(5) << y[i] << endl;
//    }
//    sum(n, y, x);
//}