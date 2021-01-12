#include <stdio.h>
#include <conio.h>
#include <math.h>

float *inMatrix(int *n,int *m,char c);
void outMatrix(float *matrix,int n,int m,char c);
void outVector(float *vector,int n,char c);
void formVector(float *matrix,float *vector,int n,int m);

int main()
{
	float *Z,*T;
	int nZ,mZ,nT,mT;
	float C[100],D[100];
	Z=inMatrix(&nZ,&mZ,'Z');
	T=inMatrix(&nT,&mT,'T');
	outMatrix(Z,nZ,mZ,'Z');
	outMatrix(T,nT,mT,'T');
	formVector(Z,C,nZ,mZ);
	formVector(T,D,nT,mT);
	outVector(C,nZ,'C');
	outVector(D,nT,'D');
	delete [] Z;
	delete [] T;
	return 0;
}

float *inMatrix(int *n,int *m,char c)
{
	int i,j;
	float *matrix;
	printf("Enter N and M of the %c matrix...\n",c);
	scanf("%i%i",n,m);
	matrix=new float[*n**m];
	printf("Enter elements of the %c matrix...\n",c);
	for(i=0;i<*n;i++)
		for(j=0;j<*m;j++)
			scanf("%f",matrix+i**m+j);
	return(matrix);		
}

void outMatrix(float *matrix,int n,int m,char c)
{
	int i,j;
	printf("Matrix %c\n",c);
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
			printf("%6.2f ",*(matrix+i*m+j));
		printf("\n");	
	}	
}

void outVector(float *vector,int n,char c)
{
	printf("Vector %c...\n",c);
	int i;
	for(i=0;i<n;i++)
		printf("%6.2f ",*(vector+i));
	printf("\n");	
}

void formVector(float *matrix,float *vector,int n,int m)
{
	int i,j;
	float max,maxWithSign;
	for(i=0;i<n;i++)
	{
		maxWithSign=*(matrix+i*m);
		max=fabs(*(matrix+i*m));
		for(j=0;j<m;j++)
			if(fabs(*(matrix+i*m+j))>max)
			{
				maxWithSign=*(matrix+i*m+j);
				max=fabs(*(matrix+i*m+j));
			}
		*(vector+i)=maxWithSign;
	}
}







