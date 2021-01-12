#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);

struct pages
{
	int memory[200];
	int count;
};

struct processes
{
	char name[20];
	int size;
};

void memoryOut(struct pages *page,int qP,int sP);
void workMod(struct pages *page,int qP);
void addProc(struct pages *page,int qP,int sP, struct processes *process,int *qProc,int *freepages);
void delPage(struct pages *page,int sP,int *freepages);
void delProc(struct pages *page,int qP,int sP, struct processes *process,int *qProc,int *freepages);

int main()
{
	////////////////MEMORY PAGES
	int sizeM,quanP,sizeP;//memory size, quantity of pages, size of page
	puts("Enter size of memory.");
	scanf("%i",&sizeM);
	puts("Enter quantity of pages");
	scanf("%i",&quanP);
	sizeP=sizeM/quanP;//размер страницы
	struct pages page[quanP];//формируем массив страниц
	int i,j;
	int freepages[quanP];//массив, содержащий информацию какой процесс размещен в какой странице
	for(i=0;i<quanP;i++)
	{
		for(j=0;j<sizeP;j++)
		{
			page[i].memory[j]=0;
		}
		page[i].count=0;
		freepages[i]=0;
	}
	////////////////PROCESSES
	int qProc=0;//quantity of processes
	struct processes process[100];
	////////////////MENU
	int item;//menu item
	do
	{
		memoryOut(page,quanP,sizeP);
		puts("MENU");
		puts("1.Add a new process");
		puts("2.Delete page");
		puts("3.Delete process");
		puts("4.Performance modulation");
		puts("5.Exit");
		scanf("%i",&item);
		memoryOut(page,quanP,sizeP);
		if(item==1)
		{
			addProc(page,quanP,sizeP,process,&qProc,freepages);
		}
		else if(item==2)
		{
			delPage(page,sizeP,freepages);
		}
		else if(item==3)
		{
			delProc(page,quanP,sizeP,process,&qProc,freepages);
		}
		else if(item==4)
		{
			workMod(page,quanP);
		}
	}
	while(item>0 && item<5);
	return 0;
}

void memoryOut(struct pages *page,int qP,int sP)
{
	system("cls");
	int i,j,k;
	for(i=0;i<qP;i++)
	{
		if(i%4==0)
		{
			printf("\n");
			for(k=0;k<sP*4+37;k++)
				printf("-");
			printf("\n");	
		}	
		else
			printf(" | ");
		printf("%2i.",i+1);
		for(j=0;j<sP;j++)
		{
			if((page+i)->memory[j]==0)
				printf("\xB0");
			else
			{
				SetConsoleTextAttribute(console,(page+i)->memory[0]);
				printf("\xB2");
				SetConsoleTextAttribute(console,7);
			}	
		}
		printf("|%2i|",(page+i)->count);
	}
	printf("\n\n");
}

void workMod(struct pages *page,int qP)
{
	int ranNum=rand()%10+1;//random quantity of treatments
	int ranP;//randomPage
	int i;
	for(i=0;i<ranNum;i++)
	{
		ranP=rand()%qP;
		(page+ranP)->count+=2;
	}
}

void addProc(struct pages *page,int qP,int sP, struct processes *process,int *qProc,int *freepages)
{
	int i,j,n=0;
	puts("ADDING THE PROCESS");
	puts("Enter process name");
	scanf("%s",(process+*qProc)->name);
	puts("Enter process size");
	scanf("%i",&((process+*qProc)->size));
	int size=(process+*qProc)->size;
	int a=size/sP;//quantity of pages
	int b=size%sP;//quantity of remaining memory
	int freePage=0;//количество незанятых страниц
	for(i=0;i<qP;i++)//считаем количество незанятых страниц
		if(*(freepages+i)==0)
			freePage++;
	if(b==0)//если количество памяти процессора, которое не заполняет всю ячейку=0 и количество свободных страниц достаточно для размещения
		if(freePage>=a)
			n=1;
	if(b!=0)
		if(freePage>a)
			n=1;
	if(n==1)
	{
		for(i=0;i<qP;i++)//от 0 до количества страниц
			if(*(freepages+i)==0 && size)//если эта страница не занята и процесс ещё не весь размещен
			{
				*(freepages+i)=*qProc+1;//то присваиваем номер этого процесса свободной странице
				for(j=0;j<sP && size;j++)//пока j<размер страницы и процесс не размещен
				{
					(page+i)->memory[j]=*qProc+1;//присваиваем номер процесса области памяти страницы
					size-=1;//уменьшаем оставшееся количество байтов, необходимых процессу для размещения
				}
				freePage-=1;
			}
	}
	else
	{
		if(size>qP*sP)
		{
			puts("Not enough memory");
			puts("Press any key");
			getch();
		}
		else
		{
			int minCount,flag,minPos;//минимальный счетчик обращений,флаг и позиция мин счетчика обращений
			while(size)
			{
				minCount=100;
				minPos=qP-1;
				for(i=qP-1;i>=0;i--)//находим позицию минимального счетчика
				{
					if((page+i)->count<=minCount)
					{
						if(*(freepages+i)!=*qProc+1)
						{
							minCount=(page+i)->count;
							minPos=i;
						}
					}
				}
				(page+minPos)->count+=2;
				if(freePage)//пока есть свободные страницы закидываю процесс в них
				{
					flag=1;
					for(i=0;i<qP && flag;i++)
						if(*(freepages+i)==0)
						{
							*(freepages+i)=*qProc+1;
							flag=0;
							freePage-=1;
							for(j=0;j<sP && size;j++)
							{
								(page+i)->memory[j]=*qProc+1;
								(page+i)->count=0;
								size-=1;
							}
						}
				}
				else if(size)//когда нет делаю алгоритм замещения
				{
					(page+minPos)->count=0;
					for(i=0;i<sP;i++)
					{
						(page+minPos)->memory[i]=0;
					}
					for(i=0;i<sP && size;i++)
					{
						(page+minPos)->memory[i]=*qProc+1;
						size-=1;
					}
					*(freepages+minPos)=*qProc+1;
				}
				(page+minPos)->count=0;
			}
		}
	}
	*qProc+=1;
	puts("PROCESS WAS ADDED");
	puts("Press any key");
	getch();
}

void delPage(struct pages *page,int sP,int *freepages)
{
	puts("DELETING PAGE");
	int number,i;
	puts("Enter number of page");
	scanf("%i",&number);
	number-=1;
	(page+number)->count=0;
	for(i=0;i<sP;i++)
	{
		(page+number)->memory[i]=0;
	}
	*(freepages+number)=0;
	puts("PAGE WAS DELETED");
	puts("Press any key");
	getch();
}

void delProc(struct pages *page,int qP,int sP, struct processes *process,int *qProc,int *freepages)
{
	puts("DELETING PROCESS");
	int number,i,j;
	puts("Enter number of process");
	scanf("%i",&number);
	for(i=0;i<qP;i++)
	{
		if(*(freepages+i)==number)
		{
			*(freepages+i)=0;
			for(j=0;j<sP;j++)
			{
				(page+i)->memory[j]=0;
			}
		}
	}
	for(i=number-1;i<*qProc-1;i++)
	{
		*(process+i)=*(process+i+1);
	}
	*qProc-=1;
	puts("PROCESS WAS DELETED");
	puts("Press any key");
	getch();
}
