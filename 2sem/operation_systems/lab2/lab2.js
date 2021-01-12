var n;
var end=1;
var FSO=WScript.CreateObject("Scripting.FileSystemObject");

do
{
WScript.StdOut.WriteLine("                     Меню");
WScript.StdOut.WriteLine("----------------------------------------------");
WScript.StdOut.WriteLine("1.Информация о создателе и описание программы.");
WScript.StdOut.WriteLine("2.Перенос файлов из указанного места в заданное.");
WScript.StdOut.WriteLine("3.Сохранение в блокноте даты создания и размера заданной папки.");
WScript.StdOut.WriteLine("4.Выход с программы.");
WScript.StdOut.WriteLine("----------------------------------------------");
WScript.StdOut.WriteLine("Введите номер требуемого пункта.");
n = WScript.StdIn.ReadLine();
WScript.StdOut.WriteLine("----------------------------------------------");
if(n==1)
{
	WScript.StdOut.WriteLine("|||Создатель Коркуц Станислав ИТП-11.");
	WScript.StdOut.WriteLine("|||Программа переносит файлы из указанного места в указанное.");
	WScript.StdOut.WriteLine("|||Программа сохраняет в блокноте дату создания и размер заданной папки.");
	WScript.StdOut.WriteLine("");
}
else if(n==2)
{
	WScript.StdOut.WriteLine("|||Введите путь откуда переместить файлы.");
	var Input = WScript.StdIn.ReadLine();
	WScript.StdOut.WriteLine("|||Введите путь куда переместить файлы.");
	var Output = WScript.StdIn.ReadLine();
	WScript.Echo("Сейчас произойдет перемещение файлов");
	FSO.MoveFile(Input + "\\*.*", Output);
	
}
else if(n==3)
{
	WScript.StdOut.WriteLine("Введите путь директории для анализа |");
	WScript.StdOut.WriteLine("Пример: C:\\folder1\\folder2 |");
	directoryPATH = WScript.StdIn.ReadLine();
	WScript.StdOut.WriteLine("----------------------------------------------");
	var fold= FSO.GetFolder(directoryPATH);
	var objShell = WScript.CreateObject("WScript.Shell");
	function inNote(process,text,timeWait)
	{
		objShell.AppActivate(process.ProcessID);
		objShell.SendKeys(text);
		WScript.Sleep(timeWait);
	}
	var note = objShell.Exec("notepad");
	WScript.Sleep(500);
	inNote(note,"Date of creation....."+fold.DateCreated+" Folder size....."+fold.Size+" byte",1000);
}
else if(n==4)
	end=0;
else
	WScript.StdOut.WriteLine("Вы ввели неверный номер");	
}
while(end);

