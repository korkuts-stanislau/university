#include <stdio.h>
#include <math.h>

float x,y;
int main(){
	puts("Enter x and y");
	scanf("%f%f",&x,&y);
	if(y>=0){
		if(y>=1)
	    puts("Point belongs to the selected area.");
		else if(y==x)
		puts("Point belongs to the selected area.");
		else if(fabs(x)<y && fabs(x)>0)
		puts("Point belongs to the selected area.");
	//	else if(x<0 && y>=-x)
	//	puts("Point belongs to the selected area.");
		else
		puts("Point NOT belongs to the selected area.");
	}
	else
	puts("Point NOT belongs to the selected area.");
	getch();
	return(0);
	
}
