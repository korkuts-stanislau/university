#include <stdio.h>

int main()
{
	int i,j,n,m,min;
	puts("Enter your N and M...");
	scanf("%i%i",&n,&m);
	int array[150][150];
	puts("Enter elements of your array...");
	for(i=0;i<n;i++)
		for(j=0;j<m;j++)
			scanf("%i",&array[i][j]);
	for(i=0;i<n;i++)
		for(j=0;j<m;j++)
			printf("%i ",array[i][j]);		
	for(j=0;j<m;j++)
	{
		min=1000000000;
		for(i=0;i<m;i++)
		{
			if(array[i][j]<min)
				min=array[i][j];
		}
		array[n-2][j]=min;
	}
	puts("Your array after transformation...");
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
			printf("%5i",array[i][j]);
		printf("\n");	
	}
			
	return 0;
}
