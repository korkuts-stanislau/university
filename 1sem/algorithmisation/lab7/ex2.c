#include <stdio.h>

int main()
{
	int i,n,elementPosition,changePosition;
	
	puts("Enter numbers quantity");
	scanf("%i",&n);
	
	if(n<5)
	{
		puts("\nEnter n > 4 please.");
	}
	else
	{
		changePosition = n-4;
		
		float array[n];
		
		puts("Enter elements of your array...");
		for(i=0;i<n;i++)
		{
			scanf("%f",&array[i]);
		}
		
		puts("\n");
		puts("Your array is");
		
		for(i=0;i<n;i++)
		{
			printf("%.2f  ",array[i]);
		}
		
		puts("\n");
		
		float tmp = array[0];
		
		for(i=0;i<n;i++)
		{
			if(array[i]>tmp)
			{
				tmp = array[i];
				elementPosition = i;
			}
		}
		
		array[elementPosition] = array[changePosition-1];
		array[changePosition-1] = tmp;
		
		puts("Your array after transformations is");
		
		for(i=0;i<n;i++)
		{
			printf("%.2f  ",array[i]);
		}
	}
		
	
	getch();
	return 0;
}
