#include <stdio.h>
#include <math.h>

int main()
{
	int i;
	float x,eps,sum,u;
	
	puts("Enter x");
	scanf("%f",&x);
	puts("Enter eps");
	scanf("%f",&eps);
	
	sum = 1-x*x/8;
	u = -x*x/8;
	
	for(i=2;fabs(u)>=eps;i++)
	{
		u=(-x*x*(i-1)*u)/(i+1);
		sum+=u;
	}
	
	printf("Sum is equal to %f",sum);
	
	getch(0);
	return 0;
}
