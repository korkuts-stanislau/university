#include<stdio.h>

float a,b,c,d,e,f,min;
int main()
{
puts("Enter a,b,c,d");
scanf("%f%f%f%f",&a,&b,&c,&d);
if(a>b)
e=a;
else 
e=b;
if(c>d)
f=c;
else
f=d;
if(e<f)
min=e;
else
min=f;
printf("%.4f",min);
getch();
return(0);	
}
