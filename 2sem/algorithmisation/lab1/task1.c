#include <stdio.h>

int main()
{
	int i,j,n,m;
	puts("Enter N and M...");
	scanf("%i%i",&n,&m);
	int array[150][150];
	puts("Enter elements of your array");
	for(i=0;i<n;i++)
		for(j=0;j<m;j++)
			scanf("%i",&array[i][j]);
	puts("Your array is...");
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
			printf("%5i ",array[i][j]);
		printf("\n");	
	}			
	int f,count=0;
	puts("Enter f...");		
	scanf("%i",&f);
	long int prod=1;
	for(i=0;i<n;i+=2)
		for(j=0;j<m;j++)
		{
			if(array[i][j]<=f)
			{
				prod*=array[i][j];
				count++;
			}			
		}
	if(count==0)
		puts("There is no elements smaller than f...");	
	else
		printf("Your production is %li",prod);	
			
	return 0;
}
