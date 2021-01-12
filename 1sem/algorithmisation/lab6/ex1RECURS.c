#include <stdio.h>
#include <math.h>

int main()
{
	int k;
	float x,x1,x2;
	
	puts("Enter k");
	scanf("%d",&k);
	puts("Enter x1");
	scanf("%f",&x1);
	puts("Enter x2");
	scanf("%f",&x2);
	
	float rec(k)
	{
		if(k==1)
		{
			return x1;
		}
		if(k==2)
		{
			return x2;
		}
		else
		{
			x=rec(k-1)+(2*rec(k-1))/(3-rec(k-2));
			return x;
		}
	}
	
	x = rec(k);
	printf("Your number is %f",x);
	
	getch(0);
	return 0;
}
