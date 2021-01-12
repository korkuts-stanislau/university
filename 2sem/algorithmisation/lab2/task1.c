#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char str[250];
	puts("Enter your string...");
	gets(str);
	int count=0,n=strlen(str),i;
	for(i=0;i<n;i++)
		if(str[i]=='.' && str[i+1]==' ')
			count++;
	puts("Your modified string is...");		
	for(i=0;i<n;i++)
	{
		if(str[i]!='S' || str[i+1]!='T')
		{
			printf("%c",str[i]);		
		}
		else
		{
			printf("P");
			i++;
		}		
	}
	printf("\nThe number of dots before the space - %i",count);
	return 0;
}
