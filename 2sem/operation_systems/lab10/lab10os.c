#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);//строка для изменения цвета текста консоли

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
	int flag;//флаг показывает загружена ли эта страница в ОЗУ при добавлении процесса
};

struct Processes
{
	char name[40];
	int ID;
	int size;
};

void beginInput(int *rS,int *hS,int *rPQ,int *mRPBOP,int *rPS,int *hPQ);
//Подпрограмма вводящая и возвращающая атрибуты памяти
void memoryOutput(int ramPagesQuantity, int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd);
//Подпрограмма выводящая состояние памяти на экран
void processInput(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,int maxRamPages,ramMemory *ram,
hddMemory *hdd,Processes *process,int *processQuantity,int *processID);
//Подпрограмма добавляющая процесс в HDD и транслирующая его в ОЗУ
void systemWork(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd);
//Подпрограмма, модулирующая работу системы
void showProcesses(Processes *process,int processQuantity);
//Подпрограмма, выводящая на экран процессы
void delProcess(int ramPagesQuantity,int ramPageSize,int hddPagesQuantity,ramMemory *ram,
hddMemory *hdd,Processes *process,int *processQuantity);
//Подпрограмма удаляющая процесс по ID

int main()
{
	int i,j;
	/////////////////////////////РАБОТА С ПАМЯТЬЮ/////////////////////////////
	int ramSize,hddSize,ramPagesQuantity,maxRamPagesByOneProcess;
	//размер ОЗУ, размер HDD, количество страниц ОЗУ, максимальное количество страниц ОЗУ, занятых 1 процессом
	int ramPageSize,hddPagesQuantity;
	//размер страницы ОЗУ, количество страниц HDD
	beginInput(&ramSize,&hddSize,&ramPagesQuantity,&maxRamPagesByOneProcess,&ramPageSize,&hddPagesQuantity);
	ramMemory ram[ramPagesQuantity];//объявление массива структур RAM
	hddMemory hdd[hddPagesQuantity];//объявление массива структур HDD
	for(i=0;i<ramPagesQuantity;i++)//первоначальное присваивание данных памяти RAM
	{
		ram[i].count=0;
		ram[i].processID=0;
		for(j=0;j<256;j++)
			ram[i].memory[j]=0;
	}
	for(i=0;i<hddPagesQuantity;i++)//первоначальное присваивание данных памяти HDD
	{
		hdd[i].count=0;
		hdd[i].processID=0;
		for(j=0;j<256;j++)
			hdd[i].memory[j]=0;
		hdd[i].flag=0;	
	}
	/////////////////////////////РАБОТА С ПРОЦЕССАМИ/////////////////////////////
	int processQuantity=0,processID=1;//первоначальная инициализация данных по процессам
	Processes process[100];//максимальное количество процессов = 100
	/////////////////////////////ВЫПОЛНЕНИЕ АЛГОРИТМА////////////////////////////
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
			case 1://добавить процесс
				processInput(ramPagesQuantity,ramPageSize,hddPagesQuantity,maxRamPagesByOneProcess,ram,hdd,process,
				&processQuantity,&processID);
				break;
			case 2://показать все процессы
				showProcesses(process,processQuantity);
				break;
			case 3://удалить процесс
				delProcess(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd,process,&processQuantity);
				break;
			case 4://модуляция работы системы
				systemWork(ramPagesQuantity,ramPageSize,hddPagesQuantity,ram,hdd);
				break;
			case 5://выход из программы
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
	scanf("%i",rS);//ввод размера RAM
	puts("Enter HDD size");
	scanf("%i",hS);//ввод размера HDD
	puts("Enter quantity of RAM pages");
	scanf("%i",rPQ);//ввод количества страниц RAM
	puts("Enter max quantity of pages for one process");
	scanf("%i",mRPBOP);//ввод количества страниц доступных для одного процесса
	*rPS=(*rS)/(*rPQ);//вычисление размера одной страницы RAM
	*hPQ=(*hS)/(*rPS);//вычисление количество страниц HDD
	puts("*****************************");
	puts("ENTERING COMPLETED, PRESS ANY KEY");
	puts("*****************************");	
	getch();
}

void memoryOutput(int ramPagesQuantity, int ramPageSize,int hddPagesQuantity,ramMemory *ram,hddMemory *hdd)
{
	system("cls");//очистка консоли
	int hddPageSize=ramPageSize;//размер страницы на жестком диске будет равно размеру страницы в ОЗУ
	int i,j;
	int quanPagesInConsole;//количество страниц по ширине консоли
	if(hddPageSize<120-8)//Если размер одной страницы меньше чем ширина консоли(вся консоль - атрибуты страницы)
		quanPagesInConsole=120/(hddPageSize+8);//то ищем количество страниц на одной линии в консоли
	else//иначе
		quanPagesInConsole=1;//количество страниц = 1
	char star = '*';
	///////////////////////////ВЫВОД СОСТОЯНИЯ RAM ПАМЯТИ/////////////////////////
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
	///////////////////////////ВЫВОД СОСТОЯНИЯ HDD ПАМЯТИ/////////////////////////
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
	if(freeSpace<processSize)//если процесс больше того места что осталось в HDD, то он просто удаляется
	{
		puts("Not enough free space for this process");
		*processQuantity-=1;
		*processID-=1;
	}
	else//иначе делаем алгоритм добавления
	{
		for(i=0;i<hddPagesQuantity && processSize;i++)//запись процесса в HDD память
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
		///////////////////ТУТ НАЧИНАЕТСЯ ТРАНСЛЯЦИЯ ИЗ HDD В ОЗУ///////////////////////////
		int quanFreePages;
		int maxPages=maxRamPages;
		int flag;
		int k;
		int minCount;
		while(maxPages)
		{
			quanFreePages=0;
			for(i=0;i<ramPagesQuantity;i++)//находим количество свободных страниц
				if((ram+i)->processID==0)
					quanFreePages++;
			if(quanFreePages)//и если ещё есть свободные страницы, то закидываем процесс туда
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
			else//иначе замещаем страницы с минимальным счетчиком обращений
			{
				int changeProcessID;//ID процесса страницы которую я замещаю
				minCount=1000000;//что бы наверняка счётчик был меньше
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
								changeProcessID=(ram+j)->processID;//запоминаю процесс который я заместил
								for(k=0;k<ramPageSize;k++)
									(ram+j)->memory[k]=(hdd+i)->memory[k];
								(hdd+i)->flag=1;
								(hdd+i)->count=2;
								(ram+j)->count=(hdd+i)->count;
								(ram+j)->processID=(hdd+i)->processID;
								flag=1;
							}
				}	
				flag=0;//когда я сбрасываю счётчик обращения страницы дальше цикл не идёт
				for(i=0;i<hddPagesQuantity && !flag;i++)//сбрасываю флаг обращения страницы с замещенным процессом
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
		///////////////////ТУТ ЗАКАНЧИВАЕТСЯ ТРАНСЛЯЦИЯ ИЗ HDD В ОЗУ////////////////////////
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
	int ranNum=rand()%10+1;//количество обращений от 1 до 10
	int i,j,k,ranPage,flag;
	int minCount;//минимальный счетчик
	int changeProcessID;//ID замещенного процесса
	int notEmptyPages=0;//количество страниц содержащих ка
	for(i=0;i<hddPagesQuantity;i++)
		if((hdd+i)->processID!=0)
			notEmptyPages++;
	for(i=0;i<ranNum;i++)
	{
		ranPage=rand()%notEmptyPages;
		if((hdd+ranPage)->processID!=0)//если в странице есть процесс
		{//обращаемся к нему
			if((hdd+ranPage)->flag==0)//если процесс не находится в ОЗУ
			{
				(hdd+ranPage)->count+=2;
				(hdd+ranPage)->flag=1;
				flag=0;//когда мы закинем страницу в ОЗУ флаг меняем на 1 и дальше цикл не идёт
				minCount=ram->count;
				for(j=1;j<ramPagesQuantity;j++)//находим минимальное значение счетчика
					if((ram+j)->count<minCount)
						minCount=(ram+j)->count;
				for(j=0;j<ramPagesQuantity && !flag;j++)//нахожу страницу с минимальным счетчиком и замещаю её
				{
					if((ram+j)->count==minCount)
					{
						changeProcessID=(ram+j)->processID;//запоминаю ID замещенного процесса
						(ram+j)->count=(hdd+ranPage)->count;
						(ram+j)->processID=(hdd+ranPage)->processID;
						for(k=0;k<ramPageSize;k++)
							(ram+j)->memory[k]=(hdd+ranPage)->memory[k];
						flag=1;
					}
				}
				flag=0;//когда я сбрасываю счётчик обращения страницы дальше цикл не идёт
				for(j=0;j<hddPagesQuantity && !flag;j++)//сбрасываю флаг обращения страницы с замещенным процессом
				{
					if((hdd+j)->processID==changeProcessID && (hdd+j)->flag==1)
					{
						(hdd+j)->flag=0;
						flag=1;
					}
				}
			}
			else//иначе если процесс уже находится в ОЗУ я просто перекидываю все процессы которые уже есть в ОЗУ снова из HDD
			{//с новыми значениями счётчика
				int l;//ещё один счётчик(ппц просто я замудрил(это вдобавок к i,j и k))
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
