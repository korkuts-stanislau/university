#include <stdio.h>
#include <math.h>

int main()
{
	int n,k,sum1 = 0,sum2 = 0,i,j,n1,n2;
	puts("Enter the first value(n) and the last value(k)\n");
	scanf("%d%d",&n,&k);
	if(k%1==0 && n%1==0 && k>-1 && n>-1)
	{
		for(i=n; i<=k; i++)
		{
			n1=i;
			for(j=1;j<n1;j++)//Сумма делителей
			{
				if(n1%j == 0)
				{
					sum1 += j;
				}
			}
			n2 = sum1;
			for(j=1;j<n2;j++)//Сумма делителей
			{
				if(n2%j == 0)
				{
					sum2 += j;
				}
			}
			if(sum2 == n1 && n1 != n2 && n2>n1)
			{
				printf("Number %d and number %d are friendly numbers.\n",n1,n2);
			}
			sum1 = 0;
			sum2 = 0;
		}
		
	}
	else
	{
		puts("\nError!");
	}
	getch(0);
	return(0);
}
