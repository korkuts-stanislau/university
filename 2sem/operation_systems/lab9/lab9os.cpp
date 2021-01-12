#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);

struct processes
{
	char name[20];//им€ процесса
	int begin;//перва€ €чейка которую процесс занимает в пам€ти
	int size;//размер процесса
};

void showMemory(int *memory,int mc,int *op,int *bp);
//memory-массив пам€ти,mc-количество выдел€емой пам€ти,op-удовлетворенные запросы,bp-неудовлетворенные запросы
void addProcess(struct processes *process,int *procQ,int *memory,int mc,int *op,int *bp);
//process-массив процессов,procQ-количество процессов
void delProcess(struct processes *process,int *procQ,int *memory,int mc);
void showProcesses(struct processes *process,int procQ);

int main()
{
	struct processes process[100];//массив процессов
	int op=0,bp=0;//op-удовлетворенные запросы,bp-неудовлетворенные запросы
	int mc,i,item=1;//memory cells-количество выдел€емой пам€ти, item-пункт меню
	puts("How much memory should it uses?");
	scanf("%i",&mc);
	int memory[mc];//массив - "пам€ть"
	int processQuantity=0;//количество процессов
	for(i=0;i<mc;i++)memory[i]=0;//обнуление пам€ти
	do
	{
		showMemory(memory,mc,&op,&bp);
		puts("1.Add a new process");
		puts("2.Delete the process");
		puts("3.Show processes");
		puts("4.Exit");
		printf("Your choice:");
		scanf("%i",&item);
		system("cls");
		showMemory(memory,mc,&op,&bp);
		if(item==1)
		{
			addProcess(process,&processQuantity,memory,mc,&op,&bp);
			system("cls");
		}
		else if(item==2)
		{
			delProcess(process,&processQuantity,memory,mc);
			system("cls");
		}
		else if(item==3)
		{
			showProcesses(process,processQuantity);
			system("cls");
		}
		else if(item==4)
		{
			system("cls");
			puts("PROGRAMM WAS FINISHED");
			puts("MADE BY KORKUTS STAS ITP-11");
			puts("GOMEL 2019");
		}
	}while(item>0 && item<4);
	return 0;
}

void showMemory(int *memory,int mc,int *op,int *bp)
{
	int i,om=0;//om-occupied memory-зан€та€ пам€ть
	int maxFreeBlock=0,block=0;//максимальный свободный блок, блок пам€ти
	for(i=0;i<mc;i++)
		{
			if(*(memory+i)==0)
			{
				block++;
				printf("\xB0");
			}	
			else
			{
				SetConsoleTextAttribute(console,*(memory+i));
				block=0;
				om+=1;
				printf("\xB2");
				SetConsoleTextAttribute(console,7);
			}	
			if(block>maxFreeBlock)
				maxFreeBlock=block;	
		}
	printf("\nMemory size: %i bytes\n",mc);
	printf("Free memory size: %i bytes\n",mc-om);
	printf("Max free memory block: %i bytes\n",maxFreeBlock);
	printf("Quantity of memory requests: %i\n",*op+*bp);
	if(*op+*bp==0) 
		printf("There are no any requests\n\n");
	else
		printf("Quantity of satisfied requests: %i%%\n\n",*op*100/(*op+*bp));
}
	
void addProcess(struct processes *process,int *procQ,int *memory,int mc,int *op,int *bp)
{
	puts("___________________________ADDING A PROCESS_____________________________________");
	puts("Enter a new process name");
	scanf("%s",(process+(*procQ))->name);
	puts("Enter the new process size");
	scanf("%i",&((process+(*procQ))->size));
	int maxFreeBlock=0,block=0,i;
	int end;//дл€ поиска конца самого большого пустого блока
	int resbeg,resend;//начало самого большого пустого блока, конец самого большого пустого блока
	for(i=0;i<mc;i++)
	{
		if(*(memory+i)>0)//если в этом месте массива уже есть процесс, то
		{
			if(block>maxFreeBlock)//мы смотрим больше ли та область массива чем наше макс значение, если да, то
			{
				maxFreeBlock=block;//максимальный блок равен текущему
				resend=end;//конец этого блока
			}	
			block=0;//обнул€ем
		}
		else//если процесса нет, то
		{
			block++;//добавл€ем к блоку ещЄ одну €чейку
			end=i;//увеличиваем значение конца блока на 1
		}
	}
	if(block>maxFreeBlock)//если в пам€ти ещЄ нет ни одного процесса, то делаем это
	{
		maxFreeBlock=block;
		resend=end;
	}
	resbeg=resend-maxFreeBlock+1;//начало блока = конец блока - его размер + 1
	if(((process+(*procQ))->size)<=maxFreeBlock)//≈сли размер процесса < макс блок, то
	{
		(process+(*procQ))->begin=resbeg;//начало процесса равно текущему началу
		for(i=resbeg;i<=resbeg-1+(process+(*procQ))->size;i++)//элементы этого блока от начала до (начало блока-1+размер процесса)
			*(memory+i)=*procQ+1;//значение €чейки = номер элемента массива процессов+1
		(*op)++;//количество удовлетворенных запросов увеличиваетс€ на 1	
	}
	else//если размер <, то просто пишем что недостаточно места и начало процесса делаем = -1
	{
		puts("Not enough free space");
		(*bp)++;//количество неудовлетворенных запросов увеличиваетс€ на 1	
		(process+(*procQ))->begin=-1;
		getch();
	}
	*procQ+=1;
}

void delProcess(struct processes *process,int *procQ,int *memory,int mc)
{
	puts("Enter process for deleting");
	int number,i;
	scanf("%i",&number);
	for(i=number-1;i<*procQ-1;i++)
		*(process+i)=*(process+i+1);
	(*procQ)-=1;
	for(i=0;i<mc;i++)
		if(*(memory+i)>=number)
		{
			if(*(memory+i)==number)
				*(memory+i)=0;	
		}
}

void showProcesses(struct processes *process,int procQ)
{
	puts("____________________PROCESSES____________________");
	int i=0;
	puts("|#  | Process Name | Process Size | Memory area |");
	for(i=0;i<procQ;i++)
	{
		if((process+i)->begin!=-1)
			printf("|%-3i|%14s|%8i bytes|%5i...%-5i|\n",i+1,(process+i)->name,(process+i)->size,((process+i)->begin),((process+i)->begin)-1+((process+i)->size));
		else
			printf("|%-3i|%14s|%8i bytes|Not in memory|\n",i+1,(process+i)->name,(process+i)->size);
	}
	puts("Press enter to continue");
	getch();
}
