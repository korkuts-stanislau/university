#include <stdio.h>

float func1(float a, float *S);
void func2(float a, float *S, float *V);

int main()
{
	float a,S,V;
	puts("Enter a...");
	scanf("%f",&a);
	func1(a,&S);
	V=func1(a,&S);
	puts("func1");
	printf("a = %f\nS = %f\nV = %f\n",a,S,V);
	func2(a,&S,&V);
	puts("func2");
	printf("a = %f\nS = %f\nV = %f",a,S,V);
	return 0;
}

float func1(float a, float *S)//Функция принимает a и возвращает V через return и S через заголовок
{
	float V;
	*S=6*a*a;
	V=a*a*a;
	return V;
}

void func2(float a, float *S, float *V)//Функция принимает a и возвращает V и S через заголовок
{
	*S=6*a*a;
	*V=a*a*a;
}
