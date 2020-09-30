#include <stdio.h>

int Fibonacci(int n)
{
    if (n == 1)
    {
        return 0;
    }

    if (n == 2 || n == 3)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

int main()
{
    int n = 40;

    printf("Os %d primeiros termos da sequencia de Fibonacci: ", n);
    for (int i = 1; i <= n; i++)
    {
        int term = Fibonacci(i);

        if (i < n)
        {
            printf("%d, ", term);
        }
        else
        {
            printf("%d \n", term);
        }
    }

    return 0;
}
