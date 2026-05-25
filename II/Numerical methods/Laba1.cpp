#include <iostream>
using namespace std;


const int n = 5;
int main()
{
	setlocale(LC_ALL, "Russian");
	double sum = 0;
	double x[5] = { 0, 1.8,3.6,5.4,7.2 };
	double y[5] = { -11.8,11.9,-12.6,-2.6,7.4 };
	double p[5] = { 0.9,2.7,4.5,6.3,0 };
	double sum1 = 0;
	double b = 7.2;
	cout << "Лагранж:" << endl;
	for (int h = 0; h < 5; h++)
	{
		if ((p[h] > b) || (p[h] < x[0]))
		{
			p[h] = x[0];
		}
		sum1 = 0;
		for (int i = 0; i < 5; ++i)
		{
			double pr = 1;
			for (int j = 0; j < 5; ++j)

				if (i != j)
				{


					pr *= (p[h] - x[j]) / (x[i] - x[j]);

				}
			sum1 += y[i] * pr;

		}
		cout << sum1 << endl;
	}
	cout << "Ньютон:" << endl;
	for (int k = 0; k < 5; k++) {

		double h, q;
		h = (x[4] - x[0]) / 4;

		q = (p[k] - x[0]) / h;


		double arr[5][5];

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				arr[i][j] = 0;
			}


		}

		for (int i = 0; i < n; i++)
		{
			arr[i][0] = y[i];
		}




		for (int i = n; i > 0; i--)
		{
			for (int j = 0; j <= n - i - 1; j++)
			{
				arr[i - 1][j + 1] = arr[i][j] - arr[i - 1][j];


			}
		}

		double l = 1;
		double lm[5];
		for (int j = 0; j < 5; j++)
		{

			if (j == 0)
				l = q;



			else
				l = l * (q - j);
			lm[j] = l;

		}

		double PN = 0;

		double i = 1;

		double pn = 0;

		for (int j = 1; j < 5; ++j) {

			i = i * j;

			pn += (((arr[0][j]) / i) * lm[j - 1]);



		}

		pn = pn + y[0];


		cout << pn << endl;
	}
	cout << "Гаусс:" << endl;
	for (int k = 0; k < 5; k++) {
		double h, q;
		h = (x[4] - x[0]) / 4;
		q = (p[k] - x[2]) / h;


		double arr[5][5];


		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				arr[i][j] = 0;
			}


		}

		for (int i = 0; i < n; i++)
		{
			arr[i][0] = y[i];
		}




		for (int i = n; i > 0; i--)
		{
			for (int j = 0; j <= n - i - 1; j++)
			{
				arr[i - 1][j + 1] = arr[i][j] - arr[i - 1][j];


			}
		}


		double arr1[n];

		arr1[0] = arr[2][0];
		arr1[1] = arr[2][1];
		arr1[2] = arr[1][2];
		arr1[3] = arr[1][3];
		arr1[4] = arr[0][4];



		double l = 1;
		double lm[5];
		for (int j = 0; j < 5; j++)
		{

			if (j == 0)
				l = q;
			else
				l = (q + j) * l * (q - j);
			lm[j] = l;

		}
		double l1 = 1;
		double lm1[5];
		for (int j = 0; j < 5; j++)
		{

			if (j == 0)
				l1 = q;
			else
				l1 = l1 * (q - j);
			lm1[j] = l1;

		}
		double Lm[4];
		Lm[0] = lm[0];
		Lm[1] = lm1[1];
		Lm[2] = lm[1];
		Lm[3] = lm1[2] * (q + 1);



		double i = 1;
		double pn = 0;
		for (int j = 1; j < 5; ++j) {
			i = i * j;
			pn += (((arr1[j]) / i) * Lm[j - 1]);
		}
		pn = pn + y[2];
		cout << pn << endl;

	}

	return 0;
}
