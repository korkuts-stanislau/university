#include <stdio.h>
#include <math.h>
int d,i,j,n,k,i2;
int main()
{		
	puts("Enter the start number");
	scanf("%d",&n);
	puts("Enter the finish number");
	scanf("%d",&k);
	puts("Your numbers are:");
	if(n%1==0 && k%1==0 && n>=0 && k>=0 && k>n)
	{
		for(i2=n;i2<=k;i2++)
		{
			int dividersQuantity = 0;
			for(j=1;j<=i2;j++)
			{
				dividersQuantity++;
			}
			
			int simpleDividersQuantity = 0;
			for(i=1;i<dividersQuantity;i++)
			{
				if(dividersQuantity%i==0)
				{
					simpleDividersQuantity++;	
				}
			}
			if(simpleDividersQuantity == 3)
			{
				d = 1;
			}
			else
			{
				d = 0;
			}
			
			if(d)
			{
				printf("%d\n",i2);
			}
		}
	}
	else
	{
		puts("\nError!");
	}
		
	
	getch(0);
	return(0);
}
