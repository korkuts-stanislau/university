#include <stdio.h>
#include <locale.h>

int main(){
	setlocale(LC_ALL,"Rus");
	int a,b,c,d,e,f,g,h;
	puts("Введите четырехзначное число");
    scanf("%d",&a);
    if(a>999 && a<10000)
    {
    	b=a/1000; //bXXX
    	c=a%1000; //XXX
    	d=c/100;  //dXX
    	e=c%100;  //XX
    	f=e/10;  //fX
    	g=e%10;  //X
    	d*=10;
    	f*=100;
    	g*=1000;
    	h=g+f+d+b;
		printf("Ваше число равно     %d\nОбратное число равно %d",a,h);
		 }
    else
    puts("Вы ввели не четырехзначное число");
    
    getch();
    return(0);
    
}
