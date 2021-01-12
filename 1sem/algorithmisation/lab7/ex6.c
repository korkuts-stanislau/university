#include <stdio.h>

int main()
{
	puts("Enter the quantity of array's elements");
	int n,i;
	scanf("%i",&n);
	
	float array[n];
	
	puts("Enter your array...");
	for(i=0;i<n;i++)
	{
		scanf("%f",&array[i]);
	}
	
	float max=array[0];
	
	for(i=1;i<n;i++)
	{
		if(array[i]>max)
		{
			max = array[i];
		}
	}
	
	int newArray[n];
	
	i=0;
	int j=0;
	while(i<n)
	{
		if(array[i]==max)
		{
			newArray[j]=i+1;
			j++;
		}
		i++;
	}
	
	puts("");
	printf("Max is equal to %.2f\n",max);
	printf("New array is:");
	
	for(i=0;i<j;i++)
	{
		if(i!=j-1)
		{
			printf(" %i,",newArray[i]);
		}
		else
		{
			printf(" %i.",newArray[i]);
		}
	}
	
	getch(0);
	return 0;
}
