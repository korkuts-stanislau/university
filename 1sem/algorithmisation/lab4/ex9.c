#include <stdio.h>
#include <math.h>

float l,f,d;
int n;
int main(){
	puts("Enter distance(meters).");
	scanf("%f",&l);
	puts("Enter 1 for transform in foots\nEnter 2 for transform in inch");
	scanf("%d",&n);
	if(n!=1 && n!=2){
		puts("You are enter incorrect number.");
	}
	else{
		if(n==1){
			f=l/0.3048;
			printf("You are enter the distance value %f meters. Foot value=%f.",l,f);
		}
		else{
			d=l/0.3048*12;
			printf("You are enter the distance value %f meters. Inch value=%f.",l,d);
		}
		
	}
	getch();
	return(0);
}
