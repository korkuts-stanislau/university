#include <stdio.h>
#include <conio.h>
#include <string.h>

int main()
{
	char alph[]={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','i','s','t',
	'u','v','w','x','y','z'};
	int nums[26]={0};
	char str[250];
	puts("Enter your string...");
	gets(str);
	int i,n=strlen(str);
	for(i=0;i<n;i++)
	{
		if((int)str[i]<=90)
			nums[(int)str[i]-65]++;
		else	
			nums[(int)str[i]-97]++;		
	}
	int max=nums[0];
	for(i=1;i<26;i++)
		if(nums[i]>max)
			max=nums[i];
	for(i=0;i<26;i++)
		if(nums[i]==max)
			printf("Letter \'%c\' is found in string %i times\n",alph[i],max);		
	return 0;
}
