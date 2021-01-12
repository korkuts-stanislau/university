#include <stdio.h>
#include <math.h>

typedef float(*func)(float);
float integral(func f, float a, float b, float eps);
float f1(float x);  
float f2(float x);  
float f3(float x);  

int main()
{
	float a,b,eps;
	puts("Enter epsilon...");
	scanf("%f",&eps);
	puts("Enter a and b for the first integral");
	scanf("%f%f",&a,&b);
	printf("Integral f1 = %f\n",integral(*f1,a,b,eps));
	puts("Enter a and b for the second integral");
	scanf("%f%f",&a,&b);
	printf("Integral f2 = %f\n",integral(*f2,a,b,eps));
	puts("Enter a and b for the third integral");
	scanf("%f%f",&a,&b);
	printf("Integral f3 = %f\n",integral(*f3,a,b,eps));
	return 0;
}

float f1(float x)
{
	return(1/((x+1)*sqrt(x+pow(x,4))));
}

float f2(float x)
{
	return(exp(0.02*x*sin(x)));
}

float f3(float x)
{
	return(sin(x)/(x*x-2.5));
}

float integral(func f, float a, float b,float eps)
{
	int n=2;
	float h;
	h=b-a;
	float I1,I2=f(a)*h,x;
	I1=(f(a)+f(b))/2*h;
	while(fabs(I2-I1)>eps)
	{
		I2=I1;
		h=(b-a)/n;
		I1=0;
		for(x=a;x<b;x+=h)
            I1+=(f(x)+f(x+h))/2*h;
		n*=2;	 
	}
	return(I2);
}
