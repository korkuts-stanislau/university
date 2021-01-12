#include <stdio.h>                   
#include <conio.h>  

main()
{
   float x,y,p;
	puts("Enter x,p");
	scanf("%f %f",&x,&p);
	y=(pow(log(x*x)+sin(p*x*x),1./4))/(pow((x*x+exp(cos(x))+sin(x)),sin(x)));
	printf("y= %.4f",y);
	getch();
   return(0);
}
