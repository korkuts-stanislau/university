#include <stdio.h>
#include <math.h>

float pi,r,d,l,s,znachenie;
int n;
int main(){
	pi=3.14;
	puts("1-Radius(R),2-Diameter(D),3-Length(L),4-Square(S)");
	puts("Enter element number and its value.");
	scanf("%d%f",&n,&znachenie);
	if(n!=1 && n!=2 && n!=3 && n!=4)
	puts("You are enter incorrect number.");
	else{
		if(znachenie<0)
		puts("Item value cannot be less than zero.");
		else{
			if(n==1){
				r=znachenie;
				d=2*r;
				l=pi*d;
				s=pi*r*r;
				printf("You are enter radius R=%f.\nDiameter D=%f.\nLength L=%f.\nRound square S=%f",r,d,l,s);
			}
			else if(n==2){
				d=znachenie;
				r=d/2;
				l=pi*d;
				s=pi*r*r;
				printf("You are enter diameter D=%f.\nRadius R=%f.\nLength L=%f.\nRound square S=%f",d,r,l,s);
			}
			else if(n==3){
				l=znachenie;
				d=l/pi;
				r=d/2;
				s=pi*r*r;
				printf("You are enter length L=%f.\nRadius R=%f.\nDiameter D=%f.\nRound square S=%f",l,r,d,s);	
			}
			else{
				s=znachenie;
			    r=sqrt(s/pi);
				d=r*2;
				l=pi*d;
				printf("You are enter round square S=%f.\nRadius R=%f.\nDiameter D=%f.\nLength L=%f",s,r,d,l);	
			}
		
		}
	
	}
	getch();
	return 0;
}
