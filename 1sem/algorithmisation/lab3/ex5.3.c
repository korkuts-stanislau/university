#include <stdio.h>
#include <locale.h>

int main(){
	setlocale(LC_ALL,"Rus");
	int k;
	int a,b,c,d,e,f,g;
	puts("Введите целое четырехзначное число k");
    scanf("%d",&k);
    if(k>999 && k<10000) //1465
    {
    a=k/1000;//aXXX      1  
    b=k%1000;//XXX       465  
    c=b/100; //cXX       4  
    d=b%100; //XX        65  
    f=d/10;  //fX        6
	g=d%10;  //g         5
	
	e=a+c+f+g;
    printf("Число k=%d\nСумма цифр k=%d\n",k,e);
    }
    else
    {
    puts("Вы ввели неправильное k");
    }
    getch();
    return(0);
    
}
