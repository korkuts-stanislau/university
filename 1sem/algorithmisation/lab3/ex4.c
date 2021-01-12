#include <stdio.h>                   
#include <conio.h>                  
#include <windows.h>

main()
{
   float a,b,c,d,e,f,g;
	puts("Enter a");
	scanf("%f",&a);
	b=a*a;
	c=b*b; //a^4
	d=c*c; //a^8
	e=d*d; //a^16
	f=e*d; //a^24
	g=f*c; //a^28
	printf("a^28= %.4f",g);
	getch();
   return(0);
}
