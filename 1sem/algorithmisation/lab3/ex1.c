#include <stdio.h>
//���������� ������� ������ ���-11 ������ ��������� ��������
int main()
{  
  float a,V,S;
  puts("Input a:");
  scanf("%f",&a);
  V=a*a*a;
  S=6*a*a;
  printf("Volume equal to %.2f",V);
  printf("Square equal to %.2f\n",S);
  getch(); 
  return(0);    
    
}
