#include <stdio.h>
#include <math.h>
#include <locale.h>

float x1,x2,yONE,y2,x,y;
int main(){
	setlocale(LC_ALL,"Rus");
	puts("Введите координаты левой нижней части прямоугольника x1 и y1.");
	scanf("%f%f",&x1,&yONE);
	puts("Введите координаты правой верхней части прямоугольника x2 и y2.");
	scanf("%f%f",&x2,&y2);
	puts("Введите координаты точки x и y.");
	scanf("%f%f",&x,&y);
	if(x>=x1 && y>=yONE && x<=x2 && y<=y2)
	printf("Точка(%f;%f) принадлежит прямоугольнику.",x,y);
	else
	printf("Точка(%f;%f) НЕ принадлежит прямоугольнику.",x,y);
	getch();
	return(0);
}
