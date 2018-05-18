using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Проверка_однородности_выборок
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    /// <summary>
    /// Тип критической области
    /// </summary>
    public enum CriticalAreaType
    { OneSidedLeft, OneSidedRight, DoubleSided}

    /// <summary>
    /// Класс для проверки гипотезы об однородности выборок
    /// </summary>
    public class Criterions
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Criterions() { }
        
        /// <summary>
        /// Инициализация полей класса
        /// </summary>
        /// <param name="x"> Массив, представляющий первую выборку </param>
        /// <param name="y"> Массив, представляющий вторую выборку </param>
        /// <param name="alpha"> Уровень значимости </param>
        public Criterions(float[] x, float[] y, float alpha)
        {
            this.x = x;
            nx = x.Length;
            this.y = y;
            ny = y.Length;
            this.alpha = alpha;
        }

        /// <summary>
        /// Массивы, вещественных чисел, представляющие выборки и объемы выборок
        /// </summary>
        public float[] x, y;
        private int nx, ny;

        /// <summary>
        /// Уровень значимости (размер критерия)
        /// </summary>
        public float alpha;

        /// <summary>
        /// Наблюдаемое значение критерия
        /// </summary>
        public float criterion;

        /// <summary>
        /// Границы доверительного интервала
        /// </summary>
        public float leftBound;
        public float rightBound;

        /// <summary>
        /// Переменная, показывающая, верна ли нулевая гипотеза
        /// </summary>
        public bool result;

        /// <summary>
        /// Критерий рандомизации компонент Фишера
        /// </summary>
        public void F(CriticalAreaType ca)
        {
            int i, j, k, n = nx + ny, m;
            float comb, mins, s1 = 0, s2 = 0, sum, N = 0;
            bool[] z;
            Random rand = new Random();

            // Определение выборки с минимальной суммой
            for (i = 0; i < nx; i++) s1 += x[i];
            for (j = 0; j < ny; j++) s2 += y[j];
            if (s1 < s2)
            {
                mins = s1;
                m = nx;
            }
            else
            {
                mins = s2;
                m = ny;
            }
            z = new bool[n];
            comb = C(n, m);
            for (i = 0; i < comb; i++)
            {
                // Случайный выбор элементов из объединенной выборки
                for (j = 0; j < n; j++) z[j] = false;
                sum = 0;
                for (j = 0; j < m; j++)
                {
                    do k = rand.Next() % n;
                    while (z[k] == true);
                    z[k] = true;
                    if (k < nx) sum += x[k];
                    else sum += y[k - nx];
                }
                // Подсчет числа благоприятных исходов
                if (sum > mins) N++;
                if (sum == mins) N += 0.5F;
            }

            criterion = N / comb;
            if (ca == CriticalAreaType.OneSidedLeft)
            {
                leftBound = alpha;
                rightBound = 1;
            }
            if (ca == CriticalAreaType.OneSidedRight)
            {
                leftBound = 0;
                rightBound = 1 - alpha;
            }
            if (ca == CriticalAreaType.DoubleSided)
            {
                leftBound = alpha / 2;
                rightBound = 1 - alpha / 2;
            }
            if (criterion >= leftBound && criterion <= rightBound) result = true;
            else result = false;
        }

        /// <summary>
        /// Критерий Вилкоксона
        /// </summary>
        /// <param name="ca"> Тип критической области </param>
        /// <param name="repeats"> Количество итераций при вычислении наблюдаемого значения </param>
        /// <returns> Наблюдаемое значение критерия Вилкоксона </returns>
        public void W(CriticalAreaType ca, int repeats)
        {
            int[] r;        // Массив с текущими рангами xi
            float[] z;		// Объединенный массив
            float p;		// Вероятность отклонения нулевой гипотезы
            int[] ns;		// Массив с частотами появления сумм рангов
            int sum, minSum, maxSum, i, j;
            Random rand = new Random();

            for (minSum = 0, i = 1; i <= nx; i++) minSum += i;
            for (maxSum = 0, i = ny + 1; i <= nx + ny; i++) maxSum += i;
            r = new int[nx];
            ns = new int[maxSum - minSum + 1];
            z = new float[nx + ny];
            for (i = 0; i < nx; i++) r[i] = i + 1;
            for (i = 0; i <= maxSum - minSum; i++) ns[i] = 0;

            // Построение закона распределения для суммы рангов
            i = nx - 1;
            while (true)
            {
                for (sum = 0, j = 0; j < nx; j++) sum += r[j];
                ns[sum - minSum] += 1;
                if (r[nx - 1] == nx + ny)
                {
                    i = nx - 2;
                    while (i != -1 && r[i + 1] - r[i] < 2) i--;
                    if (i == -1) break;
                    r[i]++;
                    for (j = i + 1; j < nx; j++) r[j] = r[j - 1] + 1;
                }
                else r[nx - 1]++;
            }

            // Общее количество комбинаций
            for (i = 0; i <= maxSum - minSum; i++) j += ns[i];

            // Вычисление доверительного интервала
            p = 0;
            if (ca == CriticalAreaType.DoubleSided)
            {
                for (i = 0; p < alpha; i++)
                    p += (float)(ns[i] + ns[maxSum - minSum - i]) / j;
                i--;
                leftBound = minSum + i;
                rightBound = maxSum - i;
            }

            if (ca == CriticalAreaType.OneSidedLeft)
            {
                for (i = 0; p < alpha; i++)
                    p += (float)ns[maxSum - minSum - i] / j;
                i--;
                leftBound = int.MinValue;
                rightBound = maxSum - i;
            }

            if (ca == CriticalAreaType.OneSidedRight)
            {
                for (i = 0; p < alpha; i++)
                    p += (float)ns[i] / j;
                i--;
                leftBound = minSum + i;
                rightBound = int.MaxValue;
            }

            // Нахождение наблюдаемого значения критерия
            sum = 0;
            for (int k = 0; k < repeats; k++)
            {
                for (i = 0; i < nx; i++) z[i] = x[i];
                for (i = 0; i < ny; i++) z[i + nx] = y[i];
                for (i = 0; i < nx; i++) r[i] = i + 1;
                for (i = 0; i < nx + ny; i++)
                    for (j = 0; j < nx + ny - 1; j++)
                        if (z[j] > z[j + 1] || (z[j] == z[j + 1] && rand.Next() % 2 == 0))
                        {
                            int k1, k2;
                            for (k1 = 0; k1 < nx; k1++) if (r[k1] == j + 1) break;
                            for (k2 = 0; k2 < nx; k2++) if (r[k2] == j + 2) break;
                            if (k1 < nx) r[k1]++;
                            if (k2 < nx) r[k2]--;
                            p = z[j];
                            z[j] = z[j + 1];
                            z[j + 1] = z[j];
                        }
                for (i = 0; i < nx; i++) sum += r[i];
            }

            criterion = sum / repeats;
            if (criterion >= leftBound && criterion <= rightBound) result = true;
            else result = false;
        }

        /// <summary>
        /// Критерий, основанный на знаках разностей
        /// </summary>
        /// <returns> Наблюдаемое значение критерия, основанного на знаках разностей </returns>
        public void Q()
        {
            float zAv = 0, s = 0, Q;
            int i;
            for (i = 0; i < nx; i++) zAv += x[i] - y[i];
            zAv /= nx;
            for (i = 0; i < nx; i++) s += (x[i] - y[i] - zAv) * (x[i] - y[i] - zAv);
            s /= nx - 1;
            s = (float)Math.Pow((double)s, 0.5F);
            Q = (float)Math.Pow((float)ny, 0.5f) * zAv / s;

            criterion = Q;
            leftBound = 0;
            rightBound = StudentDistribution(nx, alpha);
            if (criterion >= leftBound && criterion <= rightBound) result = true;
            else result = false;
        }

        /// <summary>
        /// Критетрий ранговой рандомизации Ансари-Бредли
        /// </summary>
        /// <returns> Наблюдаемое значение критерия Ансари-Бредли </returns>
        public void A()
        {
            int i, j, k, l, n = nx + ny;
            int[] p = new int[nx];	    // r - массив позиций x в объединенной выборке
            int numr = (n + 1) / 2;     // количество рангов
            float[] z = new float[nx + ny]; // объединенный массив
            float tmp, sum, W;
            for (i = 0; i < nx; i++)
            {
                z[i] = x[i];
                p[i] = i;
            }
            for (i = 0; i < ny; i++) z[nx + i] = y[i];
            for (i = 0; i < n; i++)
                for (j = 0; j < n - 1; j++)
                    if (z[j + 1] < z[j])
                    {
                        for (k = 0; k < nx; k++) if (p[k] == j) break;
                        for (l = 0; l < nx; l++) if (p[l] == j) break;
                        if (k != nx && l != nx)
                        {
                            p[k]++;
                            p[l]--;
                        }
                        if (k != nx && l == nx) p[k]++;
                        if (k == nx && l != nx) p[l]--;
                        tmp = z[j];
                        z[j] = z[j + 1];
                        z[j + 1] = tmp;
                    }
            sum = 0;
            for (i = 0; i < nx; i++)
                if (numr - p[i] > 0) sum += numr - p[i];
                else sum += p[i] - numr + 1;
            if ((n / 2) * 2 == n)
                W = (sum - (n + 2) / 4) * (float)Math.Sqrt((double)48 * nx * (n - 1) / (ny * (n - 2) * (n + 2)));
            else
                W = (sum - (n + 1) * (n + 1) / (4 * n)) *
                    (float)Math.Sqrt((double)48 * nx * (n - 1) / (ny * (n + 1) * (n + 3)));

            criterion = W;
            leftBound = 0;
            rightBound = 26.15F;
            if (criterion >= leftBound && criterion <= rightBound) result = true;
            else result = false;
        }

        /// <summary>
        /// Подсчет числа сочетаний
        /// </summary>
        /// <param name="n"> Общее количество элементов </param>
        /// <param name="m"> Выбранное количество элементов </param>
        /// <returns> Число сочетаний из n по m </returns>
        private float C(int n, int m)
        {
            int i;
            double res = 1;
            for (i = 0; i < m; i++)
            {
                res *= n - i;
                res /= m - i;
            }
            return (float)res;
        }

        /// <summary>
        /// Вычисление интегральной функции стандартного нормального распределения
        /// </summary>
        /// <param name="x"></param>
        /// <returns> Значение интегральной функции стандартного нормального распределения в точке x </returns>
        public float NormalDistribution(float x)
        {
            float res = 0, dz = 0.000001F;
            for (float z = 0; z < x; z += dz)
                res += dz * (float)Math.Pow(2 * Math.PI, -0.5) * (float)Math.Pow(Math.E, -z * z / 2);
            return 2 * res;
        }

        /// <summary>
        /// Критические точки распределения Стьюдента
        /// </summary>
        /// <param name="n"> Число степеней свободы </param>
        /// <param name="alpha"> Уровень значимости </param>
        /// <returns> Критическая точка распределения Стьюдента для заданного n и alpha </returns>
        public float StudentDistribution(int n, float alpha)
        {
            int i;
            alpha = (float)Math.Round(alpha, 3);
            for (i = 0; (float)stTable[i][0] != alpha; i++) ;
            if (n > stTable[i].Length - 1) return (float)stTable[i][stTable[i].Length - 1];
            else return (float)stTable[i][n];
        }

        /// <summary>
        /// Таблица критических точек Стьюдента
        /// </summary>
        static double[][] stTable =    // В начале строки таблицы - уровень значимости для двусторонней критической области,
                                // в конце строки таблицы - критическая точка для n, равного бесконечности
            new double[][] {
            new double[] {0.10,  6.31,  2.92,  2.35,  2.13, 2.01, 1.94, 1.89, 1.86, 1.83, 1.81, 1.80, 1.78, 1.77, 1.76, 1.75},
            new double[] {0.05,  12.7,  4.30,  3.18,  2.78, 2.57, 2.45, 2.36, 2.31, 2.26, 2.23, 2.20, 2.18, 2.16, 2.14, 2.13},
            new double[] {0.02,  31.82, 6.97,  4.54,  3.75, 3.37, 3.14, 3.00, 2.90, 2.82, 2.76, 2.72, 2.68, 2.65, 2.62, 2.60},
            new double[] {0.01,  9.92,  5.84,  4.60,  4.03, 3.71, 3.50, 3.36, 3.25, 3.17, 3.11, 3.05, 3.01, 2.98, 2.95, 2.92},
            new double[] {0.002, 63.7,  22.33, 10.22, 7.17, 5.89, 5.21, 4.79, 4.50, 4.30, 4.14, 4.03, 3.93, 3.85, 3.79, 3.73},
            new double[] {0.001, 637.0, 31.6,  12.9,  8.61, 6.86, 5.96, 5.40, 5.04, 4.78, 4.59, 4.44, 4.32, 4.22, 4.14, 4.07}
        };
    }
}
