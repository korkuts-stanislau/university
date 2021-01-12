#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char str[250];
	puts("Enter your string...");
	gets(str);
	int i,j,k,n;
	int first,last;
	int flag;
	n=strlen(str);
	puts("Palindromes in string are...");
	for(i=0;i<n;i++)
	{
		first=i;
		while(str[i]!=' ' && str[i]!=(char)0)
			i++;
		last=i-1;
		j=first;
		flag=1;
		while(j<=(last+first)/2 && flag)
		{
			if(str[j]==str[last-(j-first)])
			{
				flag=1;
				j++;
			}
			else
				flag=0;	
		}
		if(flag==1)
		{
			for(k=first;k<=last;k++)
				printf("%c",str[k]);
			printf(" ");	
		}				
	}
	return 0;
}
