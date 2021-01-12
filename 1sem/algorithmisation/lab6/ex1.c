#include <stdio.h>
#include <math.h>

int main()
{
	int k,i;
	float x,x1,x2;
	
	puts("Enter k");
	scanf("%d",&k);
	puts("Enter x1");
	scanf("%f",&x1);
	puts("Enter x2");
	scanf("%f",&x2);
	
	for(i=3;i<k;i++)
	{
		x=x2+(2*x2/(3-x1));
		x1=x2;
		x2=x;
	}
	
	printf("Your number is %.2f ...",x);
	
	getch(0);
	return 0;
}
