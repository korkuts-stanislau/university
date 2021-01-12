#include <stdio.h>

int main(){
	
	int i,n1,n2;
	puts("Enter quantity of the first array elements");
	scanf("%i",&n1);
	puts("Enter quantity of the second array elements");
	scanf("%i",&n2);
	
	float array1[n1];
	float array2[n2];
	float resArray[100];
	int resArrayElements=0;
	
	
	puts("Enter elements of the first array...");
	for(i=0;i<n1;i++)
	{
		scanf("%f",&array1[i]);
		if(array1[i]>0)
		{
			resArray[resArrayElements]=array1[i];
			resArrayElements++;
		}
	}
	
	puts("Enter elements of the second array...");
	for(i=0;i<n2;i++)
	{
		scanf("%f",&array2[i]);
		if(array2[i]<0)
		{
			resArray[resArrayElements]=array2[i];
			resArrayElements++;
		}
	}
	
	puts("Your result array...");
	for(i=0;i<resArrayElements;i++)
	{
		printf("%.2f ",resArray[i]);
	}
	
	getch(0);
	return 0;
}
