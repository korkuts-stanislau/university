#include <stdio.h>

int main()
{
	float A;
	int i,elementsQuantity,flag;
	
	puts("Enter quantity of arrays elements.");
	scanf("%i",&elementsQuantity);
	puts("Enter A value");
	scanf("%f",&A);
	
	float array[elementsQuantity];
	
	puts("Enter elements of your array...");
	for(i=0;i<elementsQuantity;i++)
	{
		scanf("%f",&array[i]);
	}
	
	puts("");
	
	printf("Your array: ");
	for(i=0;i<elementsQuantity;i++)
	{
		if(i==elementsQuantity-1)
		    printf("%.2f.\n",array[i]);
		else
		    printf("%.2f, ",array[i]);
	}
	
	flag = 1;
	i=0;
	while(i<elementsQuantity-1 && flag)
	{
		if(array[i]<array[i+1])
			flag = 0;
		else
			i++;
	}
	
	if(flag == 0)
	{
		puts("You're enter incorrect array!");
	}
	else
	{
		int biggerThanA = 0;
		
		if(array[elementsQuantity-1]<0)
		{
			puts("There is a negative numbers in this array.");
		}
		flag=1;
		i=0;
		while(i<elementsQuantity && flag)
		{
			if(array[i]>A)
			{
				biggerThanA++;
				i++;
			}
			else
				flag=0;
		}
		
		printf("Quantity of numbers, bigger than A is equal to %i\n",biggerThanA);
	}
	
	getch(0);
	return 0;
}
