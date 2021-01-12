#include<stdio.h>
#include<math.h>

int main(){
	float x,y,z,b;
	puts("Enter x,y,z");
	scanf("%f %f %f",&x,&y,&z);
	b=exp(fabs(x-y))*pow((pow(tan(z),2)+1),x);
	printf("b= %.4f",b);
	getch();
    return(0);
}
