#include <stdio.h>
#include <locale.h>

int main(){
	setlocale(LC_ALL,"Rus");
	int s,k;
	int a,b,c,d,e,f;
	puts("������� ����� s � ���������� ����� k");
    scanf("%d%d",&s,&k);
    if(k>99 && k<1000)
    {
    a=k/100;//aXX       
    b=k%100;//XX         
    c=b/10; //cX         
    d=b%10; //d          
    e=a+c+d;
    f=e+s;
    printf("����� s=%d\n����� k=%d\n����� ���� k=%d\n����� ����� k � s=%d",s,k,e,f);
    }
    else
    {
    puts("�� ����� ������������ k");
    }
    getch();
    return(0);
    
}
