#include <stdio.h>
#include <math.h>
#include <locale.h>

float x1,x2,yONE,y2,x,y;
int main(){
	setlocale(LC_ALL,"Rus");
	puts("������� ���������� ����� ������ ����� �������������� x1 � y1.");
	scanf("%f%f",&x1,&yONE);
	puts("������� ���������� ������ ������� ����� �������������� x2 � y2.");
	scanf("%f%f",&x2,&y2);
	puts("������� ���������� ����� x � y.");
	scanf("%f%f",&x,&y);
	if(x>=x1 && y>=yONE && x<=x2 && y<=y2)
	printf("�����(%f;%f) ����������� ��������������.",x,y);
	else
	printf("�����(%f;%f) �� ����������� ��������������.",x,y);
	getch();
	return(0);
}
