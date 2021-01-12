#include <stdio.h>
#include <math.h>

float x0,x1,x2,yZERO,yONE,y2;
float x10,y10,x21,y21,x02,y02;
float AB,BC,CA;
int main(){
	puts("Enter x0,x1,x2,y0,y1,y2");
	scanf("%f%f%f%f%f%f",&x0,&x1,&x2,&yZERO,&yONE,&y2);
	x10=x1-x0;
	y10=yONE-yZERO;
	x21=x2-x1;
	y21=y2-yONE;
	x02=x0-x2;
	y02=yZERO-y2;
	AB=x10*x10+y10*y10;
	BC=x21*x21+y21*y21;
	CA=x02*x02+y02*y02;
	printf("AB=%f\nBC=%f\nCA=%f\n",AB,BC,CA);
	if(AB>=BC+CA||BC>=CA+AB||CA>=BC+AB)
	printf("Bad triangle coordinats.This triangle is not exist");
	else{
		if(AB==BC||BC==CA||CA==AB)
		puts("Ravnobedrenniy");
		else if(AB==BC==CA)
		puts("Ravnostoroniy");
		else
		puts("Ne ravnobedreniy");
	}
	
	getch();
	return(0);
	
	
}
