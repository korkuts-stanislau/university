#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);//������ ��� ��������� ����� ������ �������

struct processes
{
	int id;
	int size;
	char name[10];
};

struct memory
{
	int memory[200];
	int count;
	int id;
};

void outputMemory(int *virtMemory, struct memory *mem, int virtSize, int pageQuan, int pageSize, int memBlocksQuan);
//�����, ��������� ������ ������� ������� ��������� ������
void addProcess(struct processes *process,int *processQuantity,int maxPagesByProc,int *virtualMemory,int virtualSize,
int *processId,struct memory *mem,int pagesQuantity,int pageSize);
//�����, ����������� ������� � ������
void showProcesses(struct processes *process,int *processQuantity);
//�����, ��������� ������� ��������� �� �����
void deleteProcess(struct processes *process,int *processQuantity,int *virtualMemory,int virtualSize,
struct memory *mem,int pagesQuantity,int pageSize);
//�����, ��������� ������� �� ������
void workModulation(struct memory *mem,int pagesQuantity,int maxPagesByProc);
//����� ������������ ��������� � ���������� ������

int main()
{
	int i,j;
	//���� ����� �������� ���������� � ������ � ���������
	int virtualSize,physicalSize,pagesQuantity,maxPagesByProc;
	puts("Enter size of virtual memory");
	scanf("%i",&virtualSize);
	puts("Enter size of physical memory");
	scanf("%i",&physicalSize);
	puts("Enter quantity of pages of physical memory");
	scanf("%i",&pagesQuantity);
	puts("Enter max quantity of pages which can be used by one process");
	scanf("%i",&maxPagesByProc);
	int pageSize = physicalSize/pagesQuantity;//������ ����� �������� ������
	int processQuantity = 0;//���������� ��������� ������� ����� 0
	int processId = 1;//Id ������� �������� ����� 1
	struct memory mem[pagesQuantity];//������ �������� ���������� � ���� �������� ������
	int virtualMemory[virtualSize];//������, ���������� ����������� ������
	for(i=0;i<pagesQuantity;i++)//��������� ��������� ������
	{
		mem[i].count=0;
		mem[i].id=0;
		for(j=0;j<pageSize;j++)
			mem[i].memory[j]=0;
	}
	for(i=0;i<virtualSize;i++)//��������� ��������� ����������� ������
		virtualMemory[i]=0;
	struct processes process[100];//���������� ������� ���������
	//���� ������ ������
	int item;//����� ����
	do
	{
		outputMemory(virtualMemory,mem,virtualSize,pagesQuantity,pageSize,maxPagesByProc);
		puts("MENU");
		puts("1.Add a new process");
		puts("2.Show processes");
		puts("3.Delete process from physical memory");
		puts("4.Performance modulation");
		puts("5.Exit");
		scanf("%i",&item);
		outputMemory(virtualMemory,mem,virtualSize,pagesQuantity,pageSize,maxPagesByProc);
		if(item==1)
			addProcess(process,&processQuantity,maxPagesByProc,virtualMemory,virtualSize,&processId,mem,pagesQuantity,pageSize);
		else if(item==2)
			showProcesses(process,&processQuantity);
		else if(item==3)
			deleteProcess(process,&processQuantity,virtualMemory,virtualSize,mem,pagesQuantity,pageSize);
		else if(item==4)
			workModulation(mem,pagesQuantity,maxPagesByProc);
		else if(item==5)
		{
			system("cls");
			puts("Program was finished");
			puts("Made by Korkuts Stas ITP-11");
			puts("Gomel 2019");
		}
	}
	while(item>0 && item<5);
	
	return 0;
}

void outputMemory(int *virtMemory, struct memory *mem, int virtSize, int pageQuan, int pageSize, int memBlocksQuan)
{
	int i,j;
	system("cls");
	puts("MEMORY");
	puts("Physical memory");
	for(i=0;i<pageQuan;i++)
	{
		if(i%memBlocksQuan==0 && i!=0)
			printf("|%2i\n%2i|",(mem+i-memBlocksQuan)->count,i+1);
		else if(i==0)
			printf("%2i|",i+1);
		else
			printf("|");	
		for(j=0;j<pageSize;j++)
		{
			if((mem+i)->memory[j]==0)
				printf("\xB0");
			else
			{
				SetConsoleTextAttribute(console,(mem+i)->id);
				printf("\xB2");
				SetConsoleTextAttribute(console,7);
			}	
		}
	}
	printf("|%2i",(mem+i-1)->count);
	printf("\n");
	puts("Virtual memory");
	for(i=0;i<virtSize;i++)
	{
		if(*(virtMemory+i)==0 || *(virtMemory+i)==-1)
			printf("\xB0");
		else
		{
			SetConsoleTextAttribute(console,*(virtMemory+i));
			printf("\xB2");
			SetConsoleTextAttribute(console,7);
		}	
	}
	printf("\n");
}

void addProcess(struct processes *process,int *processQuantity,int maxPagesByProc,int *virtualMemory,int virtualSize,
int *processId,struct memory *mem,int pagesQuantity,int pageSize)
{
	(process+*processQuantity)->id=*processId;
	*processId+=1;
	puts("ADDING NEW PROCESS");
	puts("Enter name of the process");
	scanf("%s",(process+*processQuantity)->name);
	puts("Enter size of the process");
	scanf("%i",&((process+*processQuantity)->size));
	int processSize=(process+*processQuantity)->size;
	if(processSize>maxPagesByProc*pageSize)
	{
		puts("You have been entered very big process");
		*(process+*processQuantity)=*(process+*processQuantity+1);
		(*processId)--;
		getch();
	}	
	else
	{
		int i;
		int freeSpaceCount=0;
		for(i=0;i<virtualSize;i++)
			if(*(virtualMemory+i)==0)
				freeSpaceCount++;
		if(freeSpaceCount<processSize)
		{
			puts("Not enough virtual memory");
			*(process+*processQuantity)=*(process+*processQuantity+1);
			(*processId)--;
			getch();
		}	
		else
		{
			int firstFreeCell, flag=1;
			for(i=0;i<virtualSize && flag;i++)
				if(*(virtualMemory+i)==0)
				{
					firstFreeCell=i;
					flag=0;
				}
			for(i=firstFreeCell;i<firstFreeCell+processSize;i++)
				*(virtualMemory+i)=(process+*processQuantity)->id;
			//��� ���������� �������� �������� ���������� � ��������� ��������
			int isFreePhysicalCell=0,posFreePhysicalCell;
			flag=1;
			int isAllPages=0;
			for(i=0;i<pagesQuantity && flag;i+=maxPagesByProc)
			{
				if((mem+i)->memory[0]==0 && i<pagesQuantity-3)
				{
					isFreePhysicalCell=1;
					posFreePhysicalCell=i;
					flag=0;
					isAllPages=1;
				}
				else if((mem+i)->memory[0]==0)
				{
					isFreePhysicalCell=1;
					posFreePhysicalCell=i;
					flag=0;
					isAllPages=0;
				}
			}
			if(isFreePhysicalCell && isAllPages)//���� ���� ��������� ���������� ������ � ���������� ������� ��� �������� �������� ���������
			{
				int size=processSize;
				int processPagesQuantity=size/pageSize+1;
				i=posFreePhysicalCell;
				int j=0;
				while(size && i<posFreePhysicalCell+processPagesQuantity)
				{
					(mem+i)->id=(process+*processQuantity)->id;
					for(j=0;j<pageSize && size;j++)
					{
						(mem+i)->memory[j]=(process+*processQuantity)->id;
						size--;
					}	
					i++;
				}
			}
			else if(isFreePhysicalCell)//���� ���������� ������� ��� �������� �������� �� ���������
			{
				int notFullProcessPagesQuantity=processSize/pageSize+1;
				if(isFreePhysicalCell)
				{
					for(i=0;i<pagesQuantity;i+=maxPagesByProc);
					i-=maxPagesByProc;
					int lastPagesBlockQuantity=pagesQuantity-i;
					flag=0;
					if(lastPagesBlockQuantity>=notFullProcessPagesQuantity)
						flag=1;
				}
				if(flag)
				{
					int a,j;
					int notFullSize=processSize;
					for(a=i;a<i+notFullProcessPagesQuantity && notFullSize;a++)
					{
						(mem+a)->id=(process+*processQuantity)->id;
						for(j=0;j<pageSize && notFullSize;j++)
						{
							(mem+a)->memory[j]=(process+*processQuantity)->id;
							notFullSize--;
						}
					}
				}
				else//���������
				{
					int minCount=(mem)->count,minCountPos=0,j;
					for(i=maxPagesByProc;i<pagesQuantity-maxPagesByProc;i+=maxPagesByProc)
					{
						if((mem+i)->count<minCount)
						{
							minCount=(mem+i)->count;
							minCountPos=i;
						}
					}
					for(i=minCountPos;i<minCountPos+maxPagesByProc;i++)
					{
						for(j=0;j<pageSize;j++)
							(mem+i)->memory[j]=0;
						(mem+i)->count=0;
					}
					int displacementSize=processSize;
					for(i=minCountPos;i<minCountPos+maxPagesByProc && displacementSize;i++)
					{
						for(j=0;j<pageSize && displacementSize;j++)
						{
							(mem+i)->memory[j]=(process+*processQuantity)->id;
							displacementSize--;
						}
						(mem+i)->id=(process+*processQuantity)->id;
						(mem+i)->count=0;
					}
				}	
			}
			else//���������
				{
					int minCount=(mem)->count,minCountPos=0,j;
					for(i=maxPagesByProc;i<pagesQuantity-maxPagesByProc+1;i+=maxPagesByProc)
					{
						if((mem+i)->count<minCount)
						{
							minCount=(mem+i)->count;
							minCountPos=i;
						}
					}
					for(i=minCountPos;i<minCountPos+maxPagesByProc;i++)
					{
						for(j=0;j<pageSize;j++)
							(mem+i)->memory[j]=0;
						(mem+i)->count=0;
					}
					int displacementSize=processSize;
					for(i=minCountPos;i<minCountPos+maxPagesByProc && displacementSize;i++)
					{
						for(j=0;j<pageSize && displacementSize;j++)
						{
							(mem+i)->memory[j]=(process+*processQuantity)->id;
							displacementSize--;
						}
						(mem+i)->id=(process+*processQuantity)->id;
						(mem+i)->count=0;
					}
				}
			//��� ������������� �������� �������� ���������� � ��������� ��������
			(*processQuantity)++;
		}
	}
}

void workModulation(struct memory *mem,int pagesQuantity,int maxPagesByProc)
{
	int ranNum=rand()%10+1;//���������� ��������� �� 1 �� 10
	int ranP;
	//ranP=rand()%qP;
	int i;
	for(i=0;i<ranNum;i++)
	{
		ranP=rand()%(pagesQuantity/maxPagesByProc+1);
		if(ranP==0)
			(mem+ranP*maxPagesByProc)->count+=10;
		else
			(mem+ranP*maxPagesByProc)->count+=2;
	}
}

void showProcesses(struct processes *process,int *processQuantity)
{
	puts("PROCESSES");
	int i;
	printf("\xC9\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xBB\n");
	printf("\xBA # \xBA   Name   \xBA ID \xBA Size \xBA\n");
	for(i=0;i<*processQuantity;i++)
	{
		printf("\xCC\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xB9\n");
		printf("\xBA%-3i\xBA%-10s\xBA%-4i\xBA%-6i\xBA\n",i+1,(process+i)->name,(process+i)->id,(process+i)->size);
	}
	printf("\xC8\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xBC\n");
	getch();
}

void deleteProcess(struct processes *process,int *processQuantity,int *virtualMemory,int virtualSize,
struct memory *mem,int pagesQuantity,int pageSize)
{
	puts("DELETING PROCESS");
	puts("Enter number of the process to delete it");
	int number,i,j;
	scanf("%i",&number);
	number--;//������ �������� � ������� ���������
	for(i=0;i<pagesQuantity;i++)
	{
		if((mem+i)->id==(process+number)->id)
		{
			for(j=0;j<pageSize;j++)
				(mem+i)->memory[j]=0;
			(mem+i)->id=0;
			(mem+i)->count=0;	
		}
	}
	for(j=0;j<virtualSize;j++)
	{
		if(*(virtualMemory+j)==(process+number)->id)
			*(virtualMemory+j)=-1;
	}
	for(i=number;i<*processQuantity-1;i++)
		*(process+i)=*(process+i+1);
	*processQuantity-=1;
	puts("Deleting complited");
	getch();
}
