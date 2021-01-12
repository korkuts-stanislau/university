#include <stdio.h>

int main()
{
	int i,n,number;
	float x,c,sum,production;
	puts("Enter element quantity");
	scanf("%i",&n);
	puts("Enter number C");
	scanf("%f",&c);
	
	float array[n];
	
	puts("Enter elements of your array...");
	for(i=0;i<n;i++)
	{
		scanf("%f",&array[i]);
	}
	
	sum = 0; 
	number=n;
	
	for(i=0;i<n;i++)
	{
		if(array[i]!=c)
		{
			sum+=array[i];
		}
		else
		{
			number--;
		}
	}
	
	if(number!=0)
	{
		sum/=number;
		printf("Arithmetic mean equal to %.2f\n",sum);
		
		int flag = 0;
		production=1;
		
		for(i=1;i<n;i+=2)
		{
			if(array[i]<0)
			{
				production*=array[i];
				flag=1;
			}
		}
		if(flag==0)
		{
			puts("There are no unpositive numbers on the even positions.");
		}
		else
		{
			printf("Production unpositive numbers equal to %.2f",production);
		}
			
	}
	else
	{
		puts("\nThere are all numbers equal to C.");
	}
	
	
	getch(0);
	return 0;
}
