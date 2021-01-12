#include <stdio.h>
#include <math.h>

void enterAr(float *array, int *n,char name);

float sqrSum(float *array, float firstEl, float lastEl);

int main()
{
	float x[100],y[100],z[100];
	int i=1,j=1,k,n,m,l=15;
	puts("Enter quantity of the X array elements...");
	scanf("%i",&n);
	puts("Enter quantity of the Y array elements...");
	scanf("%i",&m);
	puts("Quantity of the Z array elements...\n15");
	puts("Enter starting point of the Y array...");
	scanf("%i",&k);
	enterAr(x,&n,'X');
	enterAr(y,&m,'Y');
	enterAr(z,&l,'Z');
	float b=sin(sqrSum(x,j,n))*cos(sqrSum(y,k,m))-sqrSum(z,i,15);
	printf("Function is equal to - %f",b);
	return 0;
}

void enterAr(float *array, int *n,char name)
{
	int i;
	printf("\nEnter elements of %c array...\n",name);
	for(i=0;i<*n;i++)
		scanf("%f",(array+i));
}

float sqrSum(float *array, float firstEl, float lastEl)
{
	float sum=0;
	int i;
	for(i=firstEl-1;i<=lastEl-1;i++)
		sum+=(*(array+i))*(*(array+i));
	return sum;
}
