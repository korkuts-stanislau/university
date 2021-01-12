#include<math.h>
#include<stdio.h>
#include<conio.h>
typedef float(*func)(float);
float f(float x);
float integral(float a,float b,int n,func f);
int main()
{float E,S1,S2,a,b;
int n;
puts("Vvedite intervali");
scanf("%f %f",&a,&b);
puts("Vvedite tochnost");
scanf("%f",&E);
n=2;
S1=integral(a,b,n,*f);
do
{
 n=n*2;
 S2=S1;
 S1=integral(a,b,n,*f);
}
while(fabs(S1-S2)>E);
printf("a=%6.3f b=%6.3f E=%E\n",a,b,E);
printf("integral:%8.6f\n",S1);
return 0;
}

float f (float x)
{
  return((x*x+1.5)/tan(x));
}

float integral(float a,float b,int n ,func f)
{
 float S,h;
 int i;
 h=(b-a)/n;
 S=(f(a)+f(b))/2;
 for(i=1;i<n;i++)
  S=S+f(h*i+a);
 return(S*h);
}

