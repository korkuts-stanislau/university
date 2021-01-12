#include <stdio.h>
#include <math.h>

int main()
{
    int k, x, i=0, n=0, xi;
    puts("Enter k:");
    scanf("%d", &k);
    if(k>0 && k%1==0)
    {
		k+=1;
	    while(k>0)
	    {
	        x=pow(i,3);
	        xi=x;
	        do
	        {
	            xi=xi/10;
	            n++;
	        }
	            while(xi>0);
	        k=k-n;
	        i++;
	        n=0;
	    }
	
	    if(k<0)
	    {
	        k=k*-1;
	    }
	
	    if(k==0)
	    {
	        i=x%10;
	    }
	    else
	    {
	        while(k>=0)
	        {
	            i=x%10;
	            x=x/10;
	            k--;
	        }
	    }
		printf("K digit of sequence = %d",i);
	}
	else
	{
		puts("Error!!!");
	}
	    
    getch();
    return 0;
}
