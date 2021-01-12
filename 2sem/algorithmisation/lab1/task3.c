#include <stdio.h>
#include <math.h>

int main()
{
	int i,j,n,m,count=0,sum=0;
	puts("Enter your N and M...");
	scanf("%i%i",&n,&m);
	int array[n+2][m+2];
	for(i=0;i<n+2;i++)
		for(j=0;j<m+2;j++)
			array[i][j]=1000000000;
	puts("Enter elements of your array...");
	for(i=1;i<n+1;i++)
		for(j=1;j<m+1;j++)
			scanf("%i",&array[i][j]);
	for(i=1;i<n+1;i++)
		for(j=1;j<m+1;j++)
			if(array[i][j]<array[i-1][j] && array[i][j]<array[i+1][j] && array[i][j]<array[i][j-1] && array[i][j]<array[i][j+1])		
				count++;
	for(i=1;i<n+1;i++)
		for(j=1;j<m+1;j++)
			if(i<j)
				sum+=abs(array[i][j]);
	printf("Number of local minimums is %i\n"
	"Sum element higher than main diagonal is iqual to %i",count,sum);						
	return 0;
}
