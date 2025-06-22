using System;

class FinancialForecast
{
    public static double FutureValue(double principal, double rate, int years)
    {
        if (years == 0)
            return principal;

        return (1 + rate) * FutureValue(principal, rate, years - 1);
    }

    static void Main(string[] args)
    {
        double principal = 10000;
        double rate = 0.05;
        int years = 5;

        double futureVal = FutureValue(principal, rate, years);
        Console.WriteLine($"Future Value after {years} years: {futureVal:F2}");
    }
}

