#include <stdio.h>
#include <string.h>

FILE *myfile;
//Инициализация подпрограмм, описание внизу
int enterRec(struct employee *emp);
void enterRecInProg(struct employee *emp,int *qE);
void outRec(struct employee *emp, int *qE);
void delRecords(struct employee *emp,int *qE);
void outName(struct employee *emp);
void dataOut(struct employee *emp,int *qE);

//Описание структур
struct date
	{
		int day;
		int month;
		int year;
	};
struct employee
	{
		char nameAtr[100];
		char workPlace[100];
		char position[50];
		struct date bodyCheck;
		char docName[100];
		char results[250];
	};
int main()
{
	myfile = fopen("input.txt","r");//Открытие файла
	int qE,n;
	struct employee employeers[100];
	qE=enterRec(employeers);
	do
	{
		puts("----------------------------------------------------------------------------------------------------------");
		puts("Menu:");
		puts("Press 1 to write down records about some worker...");
		puts("Press 2 to display all workers' atributs...");
		puts("Press 3 to delete records about some worker...");
		puts("Press 4 to display worker's atributs...");
		puts("Press 5 to display all the characteristics of the worker who passed the body check on a particular day...");
		puts("Press any symbol for exit...");
		puts("----------------------------------------------------------------------------------------------------------");
		scanf("%i",&n);
		puts("----------------------------------------------------------------------------------------------------------");
		switch(n)
		{
			case 1:
				enterRecInProg(employeers,&qE);
				break;
			case 2:
				outRec(employeers,&qE);
				break;
			case 3:
				delRecords(employeers,&qE);
				break;
			case 4:
				outName(employeers);
				break;
			case 5:
				dataOut(employeers,&qE);
				break;
			default:
				break;						
		}
	}	
	while(n>0 && n<6);
	fclose(myfile);
	puts("Program complete.");
	return 0;
}
int enterRec(struct employee *emp)
//Подпрограмма принимает структуру и вводит туда данные из файла
{
	int pos=0;
	while(!feof(myfile))
	{
		fscanf(myfile,"%s%s%s%i%i%i%s",(*(emp+pos)).nameAtr,(*(emp+pos)).workPlace,(*(emp+pos)).position,&(*(emp+pos)).bodyCheck.day,&(*(emp+pos)).bodyCheck.month,&(*(emp+pos)).bodyCheck.year,(*(emp+pos)).docName);
		fgets((*(emp+pos)).results,100,myfile);
		strtok((*(emp+pos)).results,"\n");
		pos++;
	}
	return(pos-1);
}
void enterRecInProg(struct employee *emp,int *qE)//Подпрограмма принимает структуру и количество работников и вводит туда данные из программы
{
	int pos=*qE;
	*qE+=1;
	puts("Enter name,workplace,position,date,name of the doctor,results of body check.");
	scanf("%s%s%s%i%i%i%s",(*(emp+pos)).nameAtr,(*(emp+pos)).workPlace,(*(emp+pos)).position,&(*(emp+pos)).bodyCheck.day,&(*(emp+pos)).bodyCheck.month,&(*(emp+pos)).bodyCheck.year,(*(emp+pos)).docName);
	gets((*(emp+pos)).results);
}
void outRec(struct employee *emp, int *qE)//Подпрограмма принимает структуру и количество работников и выводит оттуда записи о всех работниках
{
	int i;
	puts("                          .............List of the workers.............");
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
	for(i=0;i<*qE;i++)
	{	
		printf("\xBA%7i\xBA%-14s\xBA%-22s\xBA%-16s\xBA%2i.%2i.%4i\xBA%-14s\xBA%-15s\xBA\n"
		,i+1,(*(emp+i)).nameAtr,(*(emp+i)).workPlace,(*(emp+i)).position,(*(emp+i)).bodyCheck.day,(*(emp+i)).bodyCheck.month,(*(emp+i)).bodyCheck.year,(*(emp+i)).docName,(*(emp+i)).results);	
	}
	puts("\xC8\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
	"\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBC");

}
void delRecords(struct employee *emp,int *qE)//Подпрограмма принимает структуру и количество работников и удаляет записи о работнике
{
	int pos,j;
	puts("Enter number of worker for deleting him....");
	scanf("%i",&pos);
	pos--;
	for(j=pos;j<*qE-1;j++)
	{
		emp[j]=emp[j+1];
	}
	*qE=*qE-1;
}
void outName(struct employee *name)//Подпрограмма принимает структуру и выводит имя и результаты комиссии о конкретном работнике
{
	puts("Enter worker's number...");
	int num;
	scanf("%i",&num);
	num--;
	printf("Worker's number %i\n",num+1);
	printf("Name is %s\n",(name+num)->nameAtr);
	printf("Date of body check is %i.%i.%i\n",(name+num)->bodyCheck.day,(name+num)->bodyCheck.month,(name+num)->bodyCheck.year);
	printf("Results are %s\n",(name+num)->results);
	puts("");
}
void dataOut(struct employee *emp,int *qE)//Подпрограмма принимает структуру и количество работников и выводит данные о всех работниках, проходивших комиссию в определенный день
{
	int day,month,year,i;
	puts("Enter date of bodyCheck...");
	puts("Day...");
	scanf("%i",&day);
	puts("Month...");
	scanf("%i",&month);
	puts("Year...");
	scanf("%i",&year);
	for(i=0;i<*qE;i++)
	{
		if((emp+i)->bodyCheck.day==day && (emp+i)->bodyCheck.month==month && (emp+i)->bodyCheck.year==year)
		{
			printf("\nWorker's number %i...\n",i+1);
			printf("Name is %s...\n",(*(emp+i)).nameAtr);
			printf("Work place is %s...\n",(*(emp+i)).workPlace);
			printf("Position is %s...\n",(*(emp+i)).position);
			printf("Date of body check is %i.%i.%i...\n",(*(emp+i)).bodyCheck.day,(*(emp+i)).bodyCheck.month,(*(emp+i)).bodyCheck.year);
			printf("Name of doctor is %s...\n",(*(emp+i)).docName);
			printf("Results are \n'%s'...\n",(*(emp+i)).results);
			puts("");
		}
	}
	puts("");
}
