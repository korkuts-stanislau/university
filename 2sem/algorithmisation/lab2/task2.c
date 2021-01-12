#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char str[250];
	puts("Enter your string...");
	gets(str);
	int n=strlen(str),i,pos,flag=1;
	puts("Your string after changes...");
	for(i=n-1;i>=0;i--)
		if(str[i]==' ' && flag)
		{
			pos=i;
			flag=0;
		}
	for(i=pos+1;i<n;i++)
	{
		printf("%c",str[i]);
	}	
	printf(" ");
	for(i=0;i<pos;i++)
	{
		printf("%c",str[i]);
	}	
	return 0;
}
