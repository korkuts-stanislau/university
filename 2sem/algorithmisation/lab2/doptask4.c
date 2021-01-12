#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char s[250];
	puts("Enter your string...");
	gets(s);
	char a;
	puts("Enter symbol a");
	a=getchar();
	int i,n=strlen(s),max=0;
	int first,last;
	int count=0;
	for(i=0;i<n;i++)
	{
		first=i;
		while(s[i]!=' ' && s[i]!=0)
			i++;
		last=i;
		if(last-first>max)
			max=last-first;	
	}
	int j;
	for(i=0;i<n;i++)
	{
		first=i;
		while(s[i]!=' ' && s[i]!=0)
			i++;
		last=i;
		j=first;
		if(last-first==max)
			while(j<=last)
			{
				if(s[j]==a)
					count++;
				j++;	
			}	
	}
	printf("Symbol %c in string is found %i times.",a,count);			
	return 0;
}
