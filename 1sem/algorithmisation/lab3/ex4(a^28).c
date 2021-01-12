#include <stdio.h>                   
#include <conio.h>                  
#include <windows.h>

main()
{
   float a,b;
	puts("Enter a");
	scanf("%f",&a);
	b=pow(a,28);
	printf("a^28= %.4f",b);
	getch();
   return(0);
}
