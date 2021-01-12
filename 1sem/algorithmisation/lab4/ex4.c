#include <stdio.h>
#include <math.h>

int k,f,e;
float g,h,a,b,c,d;
int main()
	{
	puts("Enter 4-digit number.Second and fourth digit are not equal to 0.");
	scanf("%d",&k);
	printf("Your number=%d\n",k);
	if(k<1000 || k>9999)
		puts("You enter not 4-digit number.");
	else
	{
		a=k/1000;
		e=k%1000;
		b=e/100;
		f=e%100;
		c=f/10;
		d=f%10;
		g=a/b;
		h=c/d;
		if(b==0||d==0)
			puts("Error.Second or fourth digit equal to 0.");
		else 
			if(g==h)
				puts("First digit divine Second digit is equal to Third digit divine Fourth digit.");
			else
				puts("First digit divine Second digit is not equal to Third digit divine Fourth digit.");
	}
	getch();
	return(0);
}

