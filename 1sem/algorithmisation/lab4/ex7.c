#include <stdio.h>
#include <math.h>

float x,y,z;
int main(){
	puts("Enter x,y,z");
	scanf("%f%f%f",&x,&y,&z);
	printf("X=%f,Y=%f,Z=%f\n",x,y,z);
	if(x>y && y>z){
		x*=2;
		y*=2;
		z*=2;
		printf("Numbers go down.\nX=%f,Y=%f,Z=%f",x,y,z);
	}
	else{
		x=-x;
		y=-y;
		z=-z;
		printf("Numbers do not go down.\nX=%f,Y=%f,Z=%f",x,y,z);
	}
	getch();
	return(0);
}
