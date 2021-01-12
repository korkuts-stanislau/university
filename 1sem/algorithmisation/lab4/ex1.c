#include <stdio.h>
#include <math.h>

int main(){
	float x,y;
	int n;
	puts("Enter x");
	scanf("%f",&x);
	if(x>=4)
	{y=sqrt(x);n=1;}
	else if(x<=1)
	{y=2*x+3;n=2;}
	else
	{y=fabs(pow(x,3)-4);n=3;}
    printf("x=%.4f\ny=%.4f\nn=%d",x,y,n);
    getch();
    return(0);
}
