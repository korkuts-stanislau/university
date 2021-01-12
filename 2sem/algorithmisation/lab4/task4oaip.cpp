#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <conio.h>

FILE *inputfile;
FILE *file=fopen("file.bin","wb");//открытие бинарного файла глобально для записи
FILE *tempfile;
FILE *copyfile;

void createBin(struct workers *worker,int quanW);//функция записывает начальные данные в конец бинарного файла
void binInput(struct workers *worker,int *qW);//функция вводит данные в конец бинарного файла
void showRecords(struct workers *worker,int qW);//функция показывает все записи в виде таблицы
void showSpecRec(struct workers *worker,int qW);//функция выводит все записи в которых дата равна введенной(вводить тоже в программе)
void delRecByName(struct workers *worker,int *qW);//функция удаляет записи о работнике по имени
void delRecByNumber(struct workers *worker,int *qW);//функция удаляет записи о работнике по номеру
void delAllRecords(struct workers *worker,int *qW);//функция удаляет все записи
void createCopy(struct workers *worker,int qW);//функция создает резервный файл

struct date//описание подструктуры даты
	{
		int day;
		int month;
		int year;
	};
struct workers//описание структуры работников
	{
		char name[20];
		char work[20];
		char position[20];
		struct date check;
		char doc[20];
		char results[20];
	};

int main()
{
	struct workers worker[100];//массив работников
	inputfile=fopen("input.txt","r");//открытие файла для чтения начального набора характеристик
	int qW=-1;//индекс работника в массиве работников(количество работников ___qW+1___)
	while(!feof(inputfile))//пока не конец файла читаем данные о всех работниках в структуру
	{
		qW++;
		fscanf(inputfile,"%s%s%s%i%i%i%s%s",worker[qW].name,worker[qW].work,worker[qW].position,&worker[qW].check.day,&worker[qW].check.month,&worker[qW].check.year,worker[qW].doc,worker[qW].results);
		strtok(worker[qW].results,"\n");//удаление символа переноса строки из results
	}
	fclose(inputfile);//закрытие файла с начальным набором(он дальше не нужен)
	qW++;//формирование из индекса последнего работника количества всех работников
	createBin(worker,qW);//запись в бинарный файл начального набора структур
	int item;//переменная для создания меню
	do
	{
		system("cls");
		puts("WORK WITH BINARY FILES PROGRAM");
		puts("******************************");
		puts("1.Add new record in the end of the file");
		puts("2.Show all records");
		puts("3.Show all records about workers with equal dates");
		puts("4.Delete the record by name");
		puts("5.Delete the record by number");
		puts("6.Delete all records");
		puts("7.Create copy of the file");
		puts("8.Exit");
		puts("******************************");
		puts("Enter your choice");
		scanf("%i",&item);
		system("cls");
		if(item==1)
			binInput(worker,&qW);//ввод записи в конец бинарного файла
		else if(item==2)
			showRecords(worker,qW);
		else if(item==3)
			showSpecRec(worker,qW);
		else if(item==4)
			delRecByName(worker,&qW);
		else if(item==5)
			delRecByNumber(worker,&qW);
		else if(item==6)
			delAllRecords(worker,&qW);
		else if(item==7)
			createCopy(worker,qW);
		else
			printf("PROGRAM @WORK WITH BINARY FILES\nBY KORKUTS STANISLAV ITP-11\nGOMEL 2019");
	}while(item>0 && item<8);
	fclose(file);//закрытие бинарного файла
	return 0;
}

void createBin(struct workers *worker,int quanW)
{
	int i,l1,l2,l3,l4,l5;//переменные для того что бы посчитать количество байт
	for(i=0;i<quanW;i++)
	{
		l1=strlen((worker+i)->name);//длина имени
		l2=strlen((worker+i)->work);//длина названия места работы
		l3=strlen((worker+i)->position);//длина названия должности
		l4=strlen((worker+i)->doc);//длина названия доктора
		l5=strlen((worker+i)->results);//длина результатов
		
		//запись в бинарный файл структуры worker[i]-------------
		fwrite((worker+i)->name,sizeof(char)*l1,1,file);
		fwrite((worker+i)->work,sizeof(char)*l2,1,file);
		fwrite((worker+i)->position,sizeof(char)*l3,1,file);
		fwrite(&((*(worker+i)).check.day),sizeof(int),1,file);
		fwrite(&((*(worker+i)).check.month),sizeof(int),1,file);
		fwrite(&((*(worker+i)).check.year),sizeof(int),1,file);
		fwrite((worker+i)->doc,sizeof(char)*l4,1,file);
		fwrite((worker+i)->results,sizeof(char)*l5,1,file);
	}
}

void binInput(struct workers *worker,int *qW)
{
	int i=*qW;
	puts("ADDING A NEW RECORD");
	puts("******************************");
	puts("Enter:\n*NAME* *WORK* *POSITION* *DATE(dd mm yyyy)* *DOCTOR* *RESULTS*");
	puts("");
	scanf("%s%s%s%i%i%i%s%s",(worker+i)->name,(worker+i)->work,(worker+i)->position,&(worker+i)->check.day
	,&(worker+i)->check.month,&(worker+i)->check.year,(worker+i)->doc,(worker+i)->results);
	puts("");
	strtok((worker+i)->results,"\n");//удаление символа переноса строки из results
	printf("You entered\n%s %s %s %i %i %i %s %s",(worker+i)->name,(worker+i)->work,(worker+i)->position,(worker+i)->check.day
	,(worker+i)->check.month,(worker+i)->check.year,(worker+i)->doc,(worker+i)->results);
	
	//нахождение длин строк, содержащих атрибуты структуры работников
	int l1,l2,l3,l4,l5;
	l1=strlen((worker+i)->name);//длина имени
	l2=strlen((worker+i)->work);//длина названия места работы
	l3=strlen((worker+i)->position);//длина названия должности
	l4=strlen((worker+i)->doc);//длина названия доктора
	l5=strlen((worker+i)->results);//длина результатов
		
	//запись в бинарный файл структуры worker[i]-------------
	fwrite((worker+i)->name,sizeof(char)*l1,1,file);
	fwrite((worker+i)->work,sizeof(char)*l2,1,file);
	fwrite((worker+i)->position,sizeof(char)*l3,1,file);
	fwrite(&((*(worker+i)).check.day),sizeof(int),1,file);
	fwrite(&((*(worker+i)).check.month),sizeof(int),1,file);
	fwrite(&((*(worker+i)).check.year),sizeof(int),1,file);
	fwrite((worker+i)->doc,sizeof(char)*l4,1,file);
	fwrite((worker+i)->results,sizeof(char)*l5,1,file);
	(*qW)+=1;//увеличение количества работников на 1
	puts("");
	puts("ADDING FINISHED");
	puts("******************************");
	puts("Press enter to continue");
	getch();
}

void showRecords(struct workers *worker,int qW)
{
	int i;
	puts("LIST OF THE WORKERS");
	puts("******************************");
	puts("\xC9\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBB");
    puts("\xBA  Num  \xBA     Name     \xBA    Worker's place    \xBA    Position    \xBA   Date   \xBA    Doctor"
	"    \xBA    Results    \xBA");
    puts("\xCC\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xB9");
	for(i=0;i<qW;i++)
	{	
		printf("\xBA%7i\xBA%-14s\xBA%-22s\xBA%-16s\xBA%2i.%2i.%4i\xBA%-14s\xBA%-15s\xBA\n"
		,i+1,(worker+i)->name,(worker+i)->work,(worker+i)->position,(worker+i)->check.day,(worker+i)->check.month
		,(worker+i)->check.year,(worker+i)->doc,(worker+i)->results);
	}
	puts("\xC8\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBC");
	puts("******************************");
	puts("Press ENTER for continue");
	getch();
}

void showSpecRec(struct workers *worker,int qW)
{
	int i;
	puts("LIST OF THE WORKERS WITH SPECIFIC DATE");
	puts("******************************");
	puts("Enter date(dd mm yyyy)\n");
	int day,month,year;
	scanf("%i%i%i",&day,&month,&year);
	puts("\xC9\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBB");
    puts("\xBA  Num  \xBA     Name     \xBA    Worker's place    \xBA    Position    \xBA   Date   \xBA    Doctor"
	"    \xBA    Results    \xBA");
    puts("\xCC\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
    "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xB9");
	for(i=0;i<qW;i++)
	{	
		if((worker+i)->check.day==day && (worker+i)->check.month==month && (worker+i)->check.year==year)
		{
			printf("\xBA%7i\xBA%-14s\xBA%-22s\xBA%-16s\xBA%2i.%2i.%4i\xBA%-14s\xBA%-15s\xBA\n"
			,i+1,(worker+i)->name,(worker+i)->work,(worker+i)->position,(worker+i)->check.day,(worker+i)->check.month
			,(worker+i)->check.year,(worker+i)->doc,(worker+i)->results);
		}
	}
	puts("\xC8\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBC");
	puts("******************************");
	puts("Press ENTER for continue");
	getch();
}

void delRecByName(struct workers *worker,int *qW)
{
	puts("DELETING RECORD ABOUT WORKER BY NAME");
	puts("******************************");
	puts("\nEnter name of the worker\n");
	char name[20];
	scanf("%s",name);
	int i=0,pos,flag=1;
	while(i<*qW && flag)//если имя работника в структуре равно введенному имени
	{
		if(strcmp((worker+i)->name,name)==0)//фиксируем в каком элементе массива структур находится этот работник
		{
			pos=i;
			flag=0;
		}
		i+=1;
	}		
	printf("\nNumber of the worker = %i\n",pos+1);
	for(i=pos;i<(*qW)-1;i++)
	{
		*(worker+i)=*(worker+i+1);
	}
	(*qW)-=1;
	tempfile=fopen("tempfile.bin","wb");//открытие временного файла для записи
	int l1,l2,l3,l4,l5;//переменные для того что бы посчитать количество байт
	for(i=0;i<*qW;i++)//запись всех структур во временный файл
	{
		l1=strlen((worker+i)->name);//длина имени
		l2=strlen((worker+i)->work);//длина названия места работы
		l3=strlen((worker+i)->position);//длина названия должности
		l4=strlen((worker+i)->doc);//длина названия доктора
		l5=strlen((worker+i)->results);//длина результатов
		
		//запись в бинарный файл структуры worker[i]-------------
		fwrite((worker+i)->name,sizeof(char)*l1,1,tempfile);
		fwrite((worker+i)->work,sizeof(char)*l2,1,tempfile);
		fwrite((worker+i)->position,sizeof(char)*l3,1,tempfile);
		fwrite(&((*(worker+i)).check.day),sizeof(int),1,tempfile);
		fwrite(&((*(worker+i)).check.month),sizeof(int),1,tempfile);
		fwrite(&((*(worker+i)).check.year),sizeof(int),1,tempfile);
		fwrite((worker+i)->doc,sizeof(char)*l4,1,tempfile);
		fwrite((worker+i)->results,sizeof(char)*l5,1,tempfile);
	}
	fclose(tempfile);
	tempfile=fopen("tempfile.bin","rb");//открытие временного файла для чтения
	fclose(file);
	file=fopen("file.bin","wb");//открытие основного файла для записи
	int num;
	while(!feof(tempfile))
	{
		fread(&num,sizeof(int),1,tempfile);
		fwrite(&num,sizeof(int),1,file);
	}
	fclose(tempfile);
	remove("tempfile.bin");
	puts("");
	puts("DELETING FINISHED");
	puts("******************************");
	puts("Press enter to continue");
	getch();
}

void delRecByNumber(struct workers *worker,int *qW)//функция удаляет работника по номеру
{
	puts("DELETING RECORD ABOUT WORKER BY NUMBER");
	puts("******************************");
	puts("\nEnter number of the worker\n");
	int i,pos;
	scanf("%i",&pos);
	for(i=pos-1;i<(*qW)-1;i++)
	{
		*(worker+i)=*(worker+i+1);
	}
	(*qW)-=1;
	tempfile=fopen("tempfile.bin","wb");//открытие временного файла для записи
	int l1,l2,l3,l4,l5;//переменные для того что бы посчитать количество байт
	for(i=0;i<*qW;i++)//запись всех структур во временный файл
	{
		l1=strlen((worker+i)->name);//длина имени
		l2=strlen((worker+i)->work);//длина названия места работы
		l3=strlen((worker+i)->position);//длина названия должности
		l4=strlen((worker+i)->doc);//длина названия доктора
		l5=strlen((worker+i)->results);//длина результатов
		
		//запись в бинарный файл структуры worker[i]-------------
		fwrite((worker+i)->name,sizeof(char)*l1,1,tempfile);
		fwrite((worker+i)->work,sizeof(char)*l2,1,tempfile);
		fwrite((worker+i)->position,sizeof(char)*l3,1,tempfile);
		fwrite(&((*(worker+i)).check.day),sizeof(int),1,tempfile);
		fwrite(&((*(worker+i)).check.month),sizeof(int),1,tempfile);
		fwrite(&((*(worker+i)).check.year),sizeof(int),1,tempfile);
		fwrite((worker+i)->doc,sizeof(char)*l4,1,tempfile);
		fwrite((worker+i)->results,sizeof(char)*l5,1,tempfile);
	}
	fclose(tempfile);
	tempfile=fopen("tempfile.bin","rb");//открытие временного файла для чтения
	fclose(file);
	file=fopen("file.bin","wb");//открытие основного файла для записи
	int num;
	while(!feof(tempfile))
	{
		fread(&num,sizeof(int),1,tempfile);
		fwrite(&num,sizeof(int),1,file);
	}
	fclose(tempfile);
	remove("tempfile.bin");
	puts("");
	puts("DELETING FINISHED");
	puts("******************************");
	puts("Press enter to continue");
	getch();
}

void delAllRecords(struct workers *worker,int *qW)//функция удаляет все записи о работнике
{
	puts("DELETING RECORDS ABOUT ALL WORKERS");
	puts("******************************");
	int i;
	for(i=0;i<(*qW);i++)
	{
		*(worker+i)=*(worker+99);
	}
	(*qW)=0;
	fclose(file);
	file=fopen("file.bin","wb");//открытие основного файла для записи
	puts("DELETING FINISHED");
	puts("******************************");
	puts("Press enter to continue");
	getch();
}
	
void createCopy(struct workers *worker,int qW)//функция создает резервный файл
{
	puts("CREATING COPY FILE");
	puts("******************************");
	copyfile=fopen("copyfile.bin","wb");//открытие резервного файла для записи
	int i,l1,l2,l3,l4,l5;//переменные для того что бы посчитать количество байт
	for(i=0;i<qW;i++)//запись всей структуры в резервный файл
	{
		l1=strlen((worker+i)->name);//длина имени
		l2=strlen((worker+i)->work);//длина названия места работы
		l3=strlen((worker+i)->position);//длина названия должности
		l4=strlen((worker+i)->doc);//длина названия доктора
		l5=strlen((worker+i)->results);//длина результатов
		
		//запись в бинарный файл структуры worker[i]-------------
		fwrite((worker+i)->name,sizeof(char)*l1,1,copyfile);
		fwrite((worker+i)->work,sizeof(char)*l2,1,copyfile);
		fwrite((worker+i)->position,sizeof(char)*l3,1,copyfile);
		fwrite(&((*(worker+i)).check.day),sizeof(int),1,copyfile);
		fwrite(&((*(worker+i)).check.month),sizeof(int),1,copyfile);
		fwrite(&((*(worker+i)).check.year),sizeof(int),1,copyfile);
		fwrite((worker+i)->doc,sizeof(char)*l4,1,copyfile);
		fwrite((worker+i)->results,sizeof(char)*l5,1,copyfile);
	}
	fclose(copyfile);
	puts("CREATING FINISHED");
	puts("******************************");
	puts("Press enter to continue");
	getch();
}
