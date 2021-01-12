#include <stdio.h>

int main()
{
	int n=12,array[n],i,monthBiggerV=0,V,percent;
	
	puts("Enter key value");
	scanf("%i",&V);
	
	for(i=0;i<n;i++)
	{
		printf("Enter workers value of the %i month...\n",i+1);
		scanf("%i",&array[i]);
		if(array[i]>V)
		{
			monthBiggerV++;
		}
	}
	
	percent=monthBiggerV*100/12;
	printf("Percentage of months when people were more than %i is equal to %i%%",V,percent);
	
	getch(0);
	return 0;
}
