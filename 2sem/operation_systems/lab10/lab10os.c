#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);//������ ��� ��������� ����� ������ �������

struct ramMemory
{
	int memory[256];
	int count;
	int processID;
};

struct hddMemory
{
	int memory[256];
	int count;
	int processID;
	int flag;//���� ���������� ��������� �� ��� �������� � ��� ��� ���������� ��������
};

struct Processes
{
	char name[40];
	int ID;
	int size;
};

void beginInput(int *rS,int *hS,int *rPQ,int *mRPBOP,int *rPS,int *hPQ);
//������������ �������� � ������������ �������� ������
void memoryOutput(int ramPagesQuantity, int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd);
//������������ ��������� ��������� ������ �� �����
void processInput(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,int maxRamPages,ramMemory *ram,
hddMemory *hdd,Processes *process,int *processQuantity,int *processID);
//������������ ����������� ������� � HDD � ������������� ��� � ���
void systemWork(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd);
//������������, ������������ ������ �������
void showProcesses(Processes *process,int processQuantity);
//������������, ��������� �� ����� ��������
void delProcess(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,
hddMemory *hdd,Processes *process,int *processQuantity);
//������������ ��������� ������� �� ID

int main()
{
	int i,j;
	/////////////////////////////������ � �������/////////////////////////////
	int ramSize,hddSize,ramPagesQuantity,maxRamPagesByOneProcess;
	//������ ���, ������ HDD, ���������� ������� ���, ������������ ���������� ������� ���, ������� 1 ���������
	int ramPageSize,hddPagesQuantity;
	//������ �������� ���, ���������� ������� HDD
	beginInput(&ramSize,&hddSize,&ramPagesQuantity,&maxRamPagesByOneProcess,&ramPageSize,&hddPagesQuantity);
	ramMemory ram[ramPagesQuantity];//���������� ������� �������� RAM
	hddMemory hdd[hddPagesQuantity];//���������� ������� �������� HDD
	for(i=0;i<ramPagesQuantity;i++)//�������������� ������������ ������ ������ RAM
	{
		ram[i].count=0;
		ram[i].processID=0;
		for(j=0;j<256;j++)
			ram[i].memory[j]=0;
	}
	for(i=0;i<hddPagesQuantity;i++)//�������������� ������������ ������ ������ HDD
	{
		hdd[i].count=0;
		hdd[i].processID=0;
		for(j=0;j<256;j++)
			hdd[i].memory[j]=0;
		hdd[i].flag=0;	
	}
	/////////////////////////////������ � ����������/////////////////////////////
	int processQuantity=0,processID=1;//�������������� ������������� ������ �� ���������
	Processes process[100];//������������ ���������� ��������� = 100
	/////////////////////////////���������� ���������////////////////////////////
	int item;
	do
	{
		memoryOutput(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd);
		puts("MENU");
		puts("1.ADD A NEW PROCESS");
		puts("2.SHOW PROCESSES");
		puts("3.DELETE PROCESS");
		puts("4.SYSTEM WORK MODULATION");
		puts("5.EXIT");
		scanf("%i",&item);
		memoryOutput(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd);
		switch(item)
		{
			case 1://�������� �������
				processInput(ramPagesQuantity,ramPageSize,hddPagesQuantity,maxRamPagesByOneProcess,ram,hdd,process,
				&processQuantity,&processID);
				break;
			case 2://�������� ��� ��������
				showProcesses(process,processQuantity);
				break;
			case 3://������� �������
				delProcess(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd,process,&processQuantity);
				break;
			case 4://��������� ������ �������
				systemWork(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd);
				break;
			case 5://����� �� ���������
				puts("\n\nPROGRAM WAS FINISHED");
				break;
			default:
				puts("ERROR 80085");	
				break;
		}
	}
	while(item>0 && item<5);
	
	return 0;
}

void beginInput(int *rS,int *hS,int *rPQ,int *mRPBOP,int *rPS,int *hPQ)
{
	puts("*****************************");
	puts("ENTERING MEMORY ATRIBUTS");
	puts("*****************************");
	puts("Enter RAM size");
	scanf("%i",rS);//���� ������� RAM
	puts("Enter HDD size");
	scanf("%i",hS);//���� ������� HDD
	puts("Enter quantity of RAM pages");
	scanf("%i",rPQ);//���� ���������� ������� RAM
	puts("Enter max quantity of pages for one process");
	scanf("%i",mRPBOP);//���� ���������� ������� ��������� ��� ������ ��������
	*rPS=(*rS)/(*rPQ);//���������� ������� ����� �������� RAM
	*hPQ=(*hS)/(*rPS);//���������� ���������� ������� HDD
	puts("*****************************");
	puts("ENTERING COMPLETED, PRESS ANY KEY");
	puts("*****************************");	
	getch();
}

void memoryOutput(int ramPagesQuantity, int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd)
{
	system("cls");//������� �������
	int hddPageSize=ramPageSize;//������ �������� �� ������� ����� ����� ����� ������� �������� � ���
	int i,j;
	int quanPagesInConsole;//���������� ������� �� ������ �������
	if(hddPageSize<120-8)//���� ������ ����� �������� ������ ��� ������ �������(��� ������� - �������� ��������)
		quanPagesInConsole=120/(hddPageSize+8);//�� ���� ���������� ������� �� ����� ����� � �������
	else//�����
		quanPagesInConsole=1;//���������� ������� = 1
	char star = '*';
	///////////////////////////����� ��������� RAM ������/////////////////////////
	printf("%50cRAM STATUS%-60c",star,star);
	for(i=0;i<ramPagesQuantity;i++)
	{
		if(i%quanPagesInConsole==0 && i!=0)
			printf("\n");
		printf("%3i|",i+1);
		for(j=0;j<ramPageSize;j++)
		{
			if((ram+i)->memory[j]==0)
				printf("\xB0");
			else
			{
				SetConsoleTextAttribute(console,(ram+i)->processID);
				printf("\xB2");
				SetConsoleTextAttribute(console,7);
			}
		}
		printf("|%2i ",(ram+i)->count);
	}
	///////////////////////////����� ��������� HDD ������/////////////////////////
	printf("\n%50cHDD STATUS%-60c",star,star);
	for(i=0;i<hddPagesQuantity;i++)
	{
		if(i%quanPagesInConsole==0 && i!=0)
			printf("\n");
		printf("%3i|",i+1);
		for(j=0;j<hddPageSize;j++)
		{
			if((hdd+i)->memory[j]==0)
				printf("\xB0");
			else
			{
				SetConsoleTextAttribute(console,(hdd+i)->processID);
				printf("\xB2");
				SetConsoleTextAttribute(console,7);
			}
		}
		printf("|%2i ",(hdd+i)->count);
	}
	puts("");
}

void processInput(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,int maxRamPages,ramMemory *ram,
hddMemory *hdd,Processes *process,int *processQuantity,int *processID)
{
	int hddPageSize=ramPageSize;
	puts("*****************************");
	puts("ENTERING PROCESS ATRIBUTS");
	puts("*****************************");
	puts("Enter process name");
	scanf("%s",(process+*processQuantity)->name);
	puts("Enter process size");
	scanf("%i",&(process+*processQuantity)->size);
	(process+*processQuantity)->ID=*processID;
	int processSize = (process+*processQuantity)->size;
	int freeSpace=0;
	int i,j;
	for(i=0;i<hddPagesQuantity;i++)
	{
		if((hdd+i)->processID==0)
			freeSpace+=hddPageSize;
	}
	if(freeSpace<processSize)//���� ������� ������ ���� ����� ��� �������� � HDD, �� �� ������ ���������
	{
		puts("Not enough free space for this process");
		*processQuantity-=1;
		*processID-=1;
	}
	else//����� ������ �������� ����������
	{
		for(i=0;i<hddPagesQuantity && processSize;i++)//������ �������� � HDD ������
			if((hdd+i)->processID==0)
			{
				(hdd+i)->processID=*processID;
				(hdd+i)->count=0;
				for(j=0;j<hddPageSize && processSize;j++)
				{
					(hdd+i)->memory[j]=1;
					processSize--;
				}	
			}
		///////////////////��� ���������� ���������� �� HDD � ���///////////////////////////
		int quanFreePages;
		int maxPages=maxRamPages;
		int flag;
		int k;
		int minCount;
		while(maxPages)
		{
			quanFreePages=0;
			for(i=0;i<ramPagesQuantity;i++)//������� ���������� ��������� �������
				if((ram+i)->processID==0)
					quanFreePages++;
			if(quanFreePages)//� ���� ��� ���� ��������� ��������, �� ���������� ������� ����
			{
				flag=0;
				for(i=0;i<hddPagesQuantity && !flag;i++)
				{
					if((hdd+i)->processID==*processID && (hdd+i)->flag==0)
						for(j=0;j<ramPagesQuantity && !flag;j++)
							if((ram+j)->processID==0)
							{
								for(k=0;k<ramPageSize;k++)
									(ram+j)->memory[k]=(hdd+i)->memory[k];
								(hdd+i)->flag=1;
								(hdd+i)->count=2;
								(ram+j)->count=(hdd+i)->count;
								(ram+j)->processID=(hdd+i)->processID;
								flag=1;
							}
				}
			}
			else//����� �������� �������� � ����������� ��������� ���������
			{
				int changeProcessID;//ID �������� �������� ������� � �������
				minCount=1000000;//��� �� ��������� ������� ��� ������
				for(i=0;i<ramPagesQuantity;i++)
					if((ram+i)->count<minCount && (ram+i)->processID!=*processID)
						minCount=(ram+i)->count;
				flag=0;
				for(i=0;i<hddPagesQuantity && !flag;i++)
				{
					if((hdd+i)->processID==*processID && (hdd+i)->flag==0)
						for(j=0;j<ramPagesQuantity && !flag;j++)
							if((ram+j)->count==minCount && (ram+j)->processID!=*processID)
							{
								changeProcessID=(ram+j)->processID;//��������� ������� ������� � ��������
								for(k=0;k<ramPageSize;k++)
									(ram+j)->memory[k]=(hdd+i)->memory[k];
								(hdd+i)->flag=1;
								(hdd+i)->count=2;
								(ram+j)->count=(hdd+i)->count;
								(ram+j)->processID=(hdd+i)->processID;
								flag=1;
							}
				}	
				flag=0;//����� � ��������� ������� ��������� �������� ������ ���� �� ���
				for(i=0;i<hddPagesQuantity && !flag;i++)//��������� ���� ��������� �������� � ���������� ���������
				{
					if((hdd+i)->processID==changeProcessID && (hdd+i)->flag==1)
					{
						(hdd+i)->flag=0;
						flag=1;
					}
				}	
			}
			maxPages--;
		}
		///////////////////��� ������������� ���������� �� HDD � ���////////////////////////
	}
	
	*processQuantity+=1;
	*processID+=1;
	puts("*****************************");
	puts("ENTERING COMPLETED, PRESS ANY KEY");
	puts("*****************************");	
	getch();
}

void systemWork(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd)
{
	int ranNum=rand()%10+1;//���������� ��������� �� 1 �� 10
	int i,j,k,ranPage,flag;
	int minCount;//����������� �������
	int changeProcessID;//ID ����������� ��������
	int notEmptyPages=0;//���������� ������� ���������� ��
	for(i=0;i<hddPagesQuantity;i++)
		if((hdd+i)->processID!=0)
			notEmptyPages++;
	for(i=0;i<ranNum;i++)
	{
		ranPage=rand()%notEmptyPages;
		if((hdd+ranPage)->processID!=0)//���� � �������� ���� �������
		{//���������� � ����
			if((hdd+ranPage)->flag==0)//���� ������� �� ��������� � ���
			{
				(hdd+ranPage)->count+=2;
				(hdd+ranPage)->flag=1;
				flag=0;//����� �� ������� �������� � ��� ���� ������ �� 1 � ������ ���� �� ���
				minCount=ram->count;
				for(j=1;j<ramPagesQuantity;j++)//������� ����������� �������� ��������
					if((ram+j)->count<minCount)
						minCount=(ram+j)->count;
				for(j=0;j<ramPagesQuantity && !flag;j++)//������ �������� � ����������� ��������� � ������� �
				{
					if((ram+j)->count==minCount)
					{
						changeProcessID=(ram+j)->processID;//��������� ID ����������� ��������
						(ram+j)->count=(hdd+ranPage)->count;
						(ram+j)->processID=(hdd+ranPage)->processID;
						for(k=0;k<ramPageSize;k++)
							(ram+j)->memory[k]=(hdd+ranPage)->memory[k];
						flag=1;
					}
				}
				flag=0;//����� � ��������� ������� ��������� �������� ������ ���� �� ���
				for(j=0;j<hddPagesQuantity && !flag;j++)//��������� ���� ��������� �������� � ���������� ���������
				{
					if((hdd+j)->processID==changeProcessID && (hdd+j)->flag==1)
					{
						(hdd+j)->flag=0;
						flag=1;
					}
				}
			}
			else//����� ���� ������� ��� ��������� � ��� � ������ ����������� ��� �������� ������� ��� ���� � ��� ����� �� HDD
			{//� ������ ���������� ��������
				int l;//��� ���� �������(��� ������ � ��������(��� �������� � i,j � k))
				(hdd+ranPage)->count+=2;
				j=0;
				k=0;
				while(j<hddPagesQuantity)
				{
					if((hdd+j)->flag==1)
					{
						(ram+k)->count=(hdd+j)->count;
						(ram+k)->processID=(hdd+j)->processID;
						for(l=0;l<ramPageSize;l++)
							(ram+k)->memory[l]=(hdd+j)->memory[l];	
						k++;
					}
					j++;
				}
			}
		}
	}
}

void showProcesses(Processes *process,int processQuantity)
{
	puts("*****************************");
	puts("PROCESS INFORMATION");
	puts("*****************************");
	int i;
	printf("\xC9\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xBB\n");
	printf("\xBA # \xBA   Name   \xBA ID \xBA Size \xBA\n");
	for(i=0;i<processQuantity;i++)
	{
		printf("\xCC\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xB9\n");
		printf("\xBA%-3i\xBA%-10s\xBA%-4i\xBA%-6i\xBA\n",i+1,(process+i)->name,(process+i)->ID,(process+i)->size);
	}
	printf("\xC8\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xBC\n");
	puts("Press any key to continue");
	getch();	
}

void delProcess(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd,
Processes *process,int *processQuantity)
{
	puts("*****************************");
	puts("DELETING PROCESS");
	puts("*****************************");
	puts("Enter process ID");
	int ID;
	scanf("%i",&ID);
	int i,j;
	for(i=0;i<hddPagesQuantity;i++)
		if((hdd+i)->processID==ID)
		{
			(hdd+i)->processID=0;
			(hdd+i)->flag=0;
			(hdd+i)->count=0;
			for(j=0;j<ramPageSize;j++)
				(hdd+i)->memory[j]=0;
		}
	for(i=0;i<ramPagesQuantity;i++)
		if((ram+i)->processID==ID)
		{
			(ram+i)->processID=0;
			(ram+i)->count=0;
			for(j=0;j<ramPageSize;j++)
				(ram+i)->memory[j]=0;
		}
	int pos;
	for(i=0;i<*processQuantity;i++)
		if((process+i)->ID==ID)
			pos=i;
	for(i=pos;i<*processQuantity-1;i++)
		*(process+i)=*(process+i+1);
	*processQuantity-=1;
	puts("*****************************");
	puts("DELETING COMPLETED, PRESS ANY KEY");
	puts("*****************************");
	getch();
}
