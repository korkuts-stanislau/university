#include <stdio.h>
#include <locale.h>

int main(){
	setlocale(LC_ALL,"Rus");
	int s,k;
	int a,b,c,d,e,f;
	puts("Введите число s и трезначное число k");
    scanf("%d%d",&s,&k);
    if(k>99 && k<1000)
    {
    a=k/100;//aXX       
    b=k%100;//XX         
    c=b/10; //cX         
    d=b%10; //d          
    e=a+c+d;
    f=e+s;
    printf("Число s=%d\nЧисло k=%d\nСумма цифр k=%d\nСумма чисел k и s=%d",s,k,e,f);
    }
    else
    {
    puts("Вы ввели неправильное k");
    }
    getch();
    return(0);
    
}
