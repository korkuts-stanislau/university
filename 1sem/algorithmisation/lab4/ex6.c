#include <stdio.h>
#include <math.h>

int k,a,b,c,d,f,e;
int main()
{
	puts("Enter a four-digit positive number.");
	scanf("%d",&k);
	printf("Your number: %d\n",k);
	if(k<1000 || k>9999)
		puts("You does not enter four-digit number.");
	else
	{
		a=k/1000;
		e=k%1000;
		b=e/100;
		f=e%100;
		c=f/10;
		d=f%10;
		if(a+b == c+d)
			puts("True");
		else
			puts("False");
	}
	getch();
	return(0);

}
