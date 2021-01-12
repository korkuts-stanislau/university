#include <stdio.h>
#include <math.h>

int M,N,i,digit,n,m;

int main()
{
	int number = 1;
	for(i=10; i<100; i++)
	{
		digit=i;
		M=digit/10;
		N=digit%10;
		if(M*N == N*M)
		{
			if(N!=0)
			{
				n=N*10+M;
				m=M*10+N;
				printf("Pare number %d :(%d and %d)\n",number,n,m);
				number++;
			}
		}
		
	}
	
	getch(0);
	return(0);		
}
