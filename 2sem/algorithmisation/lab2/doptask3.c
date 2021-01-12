#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char s[250];
	puts("Enter your string...");
	gets(s);
	int i,n=strlen(s),max=0;
	int first,last;
	for(i=0;i<n;i++)
	{
		first=i;
		while(s[i]!=' ' && s[i]!=0)
			i++;
		last=i;
		if(last-first>max)
			max=last-first;	
	}
	int j,flag=1;
	puts("Max-length word in string is...");
	for(i=0;i<n && flag;i++)
	{
		first=i;
		while(s[i]!=' ' && s[i]!=0)
			i++;
		last=i;
		j=first;
		if(last-first==max)
			while(j<=last)
			{
				printf("%c",s[j]);
				flag=0;
				j++;	
			}	
	}			
	return 0;
}
