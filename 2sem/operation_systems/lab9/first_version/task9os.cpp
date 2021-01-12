#include <stdio.h>
#include <stdlib.h>

struct memory
{
	int space;
	int occuspace;
};

struct processes
{
	int cellNumber;
	int size;
};

void inputCells(struct memory *cell,int n);//Ввод ячеек памяти
void outputCells(struct memory *cell,int n);//Вывод информации о ячейках
void memoryStatus(struct memory *cell,int n,int app,int reg);//Вывод информации о памяти в целом
void inputProcess(struct memory *cell,struct processes *process,int n,int quan,int *appreq,int *regreq);//Ввод процесса
void deleteProcess(struct memory *cell,struct processes *process,int quan);//Удаление процесса
void inputSpecificProcess(struct memory *cell,struct processes *process,int quan,int *appreq,int *regreq);//Ввод процесса в конкретную ячейку
void outputProcesses(struct processes *process,int quan);//Вывод процессов

int main()
{
	int n,menuItem;
	puts("Enter quantity of memory cells.");
	scanf("%i",&n);
	struct memory cell[100];
	struct processes process[100];
	inputCells(cell,n);
	outputCells(cell,n);
	int appreq=0,regreq=0;//количество удовлетворенных запросов и количество отклоненных запросов
	int processQuan=0;
	do
	{
		puts("1.Memory status");
		puts("2.Enter the process");
		puts("3.Delete the process");
		puts("4.Enter the process in a specific cell");
		puts("5.Show processes");
		puts("6.Show cells");
		puts("7.Exit");
		scanf("%i",&menuItem);
		system("cls");
		switch(menuItem)
		{
			case 1:
			{
				memoryStatus(cell,n,appreq,regreq);
			}
				break;
			case 2:
			{
				inputProcess(cell,process,n,processQuan,&appreq,&regreq);
				processQuan++;
			}
				break;
			case 3:
			{
				deleteProcess(cell,process,processQuan);
				processQuan--;
			}	
				break;
			case 4:
			{
				inputSpecificProcess(cell,process,processQuan,&appreq,&regreq);
				processQuan++;
			}
				break;
			case 5:
			{
				outputProcesses(process,processQuan);
			}
				break;
			case 6:
			{
				outputCells(cell,n);
			}
				break;	
			case 7:
			{
				puts("PROGRAM FINISHED");
			}
				break;
			default:
				puts("You wrote wrong number...");
				break;
		}	
	}while(n!=7);
	return 0;
}

void inputCells(struct memory *cell,int n)
{
	printf("\nENTERING CELLS\n");
	int i=0;
	while(i<n)
	{
		printf("Enter size of the %i cell\n",i+1);
		scanf("%i",&(cell+i)->space);
		(cell+i)->occuspace=0;
		i+=1;
	}
	printf("\nENTERING FINISHED\n");
}

void outputCells(struct memory *cell,int n)
{
	printf("\nMEMORY CELLS STATUS\n");
	int i=0;
	puts("_______________________________________");
	puts("|Cell number|Size of memory|Free space|");
	puts("---------------------------------------");
	while(i<n)
	{
		printf("|Cell # %-4i|%14i|%10i|",i+1,(cell+i)->space,((cell+i)->space)-((cell+i)->occuspace));
		puts("");
		i+=1;
	}
	puts("---------------------------------------");
}

void memoryStatus(struct memory *cell,int n,int app,int reg)
{
	printf("\nMEMORY STATUS\n");
	int memory=0,freememory=0,i;
	int	maxblock=(cell->space)-(cell->occuspace);
	for(i=0;i<n;i++)
	{
		memory+=(cell+i)->space;
		freememory+=((cell+i)->space)-((cell+i)->occuspace);
		if(((cell+i)->space)-((cell+i)->occuspace)>maxblock)
			maxblock=((cell+i)->space)-((cell+i)->occuspace);
	}
	printf("\nMemory size = %i",memory);
	printf("\nFree memory = %i",freememory);
	printf("\nSize of block with max free space is %i",maxblock);
	printf("\nQuantity of processes requests is %i",app+reg);
	printf("\nQuantity of approved requests is %i%%\n",app*100/(app+reg));
	puts("");
}

void inputProcess(struct memory *cell,struct processes *process,int n,int quan,int *appreq,int *regreq)
{
	printf("\nENTERING PROCESS\n");
	printf("Entering process number %i\n",quan+1);
	puts("Enter size of your process");
	scanf("%i",&(process+quan)->size);
	int maxSize=(cell->space)-(cell->occuspace)-(process+quan)->size,maxSizePos=0;
	int i;
	for(i=0;i<n;i++)
	{
		if(((cell+i)->space)-((cell+i)->occuspace)-((process+quan)->size)>maxSize)
		{
			maxSize=((cell+i)->space)-((cell+i)->occuspace)-((process+quan)->size);
			maxSizePos=i;
		}
	}
	if(maxSize>=0)
	{
		(process+quan)->cellNumber=maxSizePos;
		(cell+maxSizePos)->occuspace+=(process+quan)->size;
		*appreq+=1;
	}
	else
	{
		puts("Not enough memory for this process");
		(process+quan)->cellNumber=-1;
		*regreq+=1;
	}
	printf("\nENTERING FINISHED\n");
}

void deleteProcess(struct memory *cell,struct processes *process,int quan)
{
	printf("\nDELETING PROCESS\n");
	int number,i;
	puts("Enter the number of the process to be deleted.");
	scanf("%i",&number);
	if((process+number-1)->cellNumber>=0)
	{
		(cell+((process+number-1)->cellNumber))->occuspace-=(process+number-1)->size;
		for(i=number-1;i<quan;i++)
		{
			*(process+i)=*(process+i+1);
		}
	}
	else
	{
		for(i=number-1;i<quan;i++)
		{
			*(process+i)=*(process+i+1);
		}
	}
	printf("\nDELETING FINISHED\n");
}

void inputSpecificProcess(struct memory *cell,struct processes *process,int quan,int *appreq,int *regreq)
{
	int flag=0;
	printf("\nENTERING PROCESS IN SPECIFIC CELL\n");
	printf("Entering process number %i\n",quan+1);
	puts("Enter size of your process");
	scanf("%i",&(process+quan)->size);
	int cellNum;
	puts("Enter cell number");
	scanf("%i",&cellNum);
	if(((cell+cellNum-1)->space)-((cell+cellNum-1)->occuspace)-(process+quan)->size>=0)
	{
		(process+quan)->cellNumber=cellNum-1;
		(cell+cellNum-1)->occuspace+=(process+quan)->size;
		*appreq+=1;
		flag=1;
	}
	else
	{
		puts("Not enough memory for this process");
		(process+quan)->cellNumber=-1;
		*regreq+=1;
		flag=0;
	}
	if(flag)
		printf("\nThe process was written to the cell with adress %i\n",&((cell+cellNum-1)->space));
	printf("\nENTERING FINISHED\n");
}

void outputProcesses(struct processes *process,int quan)
{
	puts("PROCESSES STATUS");
	int i=0;
	puts("________________________________________");
	puts("| Number | Process Cell | Process Size |");
	puts("----------------------------------------");
	while(i<quan)
	{
		if((process+i)->cellNumber!=-1)
			printf("|%-8i|Cell # %-7i|%-14i|",i+1,((process+i)->cellNumber)+1,(process+i)->size);
		else
			printf("|%-8i|Out of memory |%-14i|",i+1,(process+i)->size);	
		i++;
		puts("");
	}
}
