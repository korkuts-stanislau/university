var n;
var end=1;
var FSO=WScript.CreateObject("Scripting.FileSystemObject");

do
{
WScript.StdOut.WriteLine("                     ����");
WScript.StdOut.WriteLine("----------------------------------------------");
WScript.StdOut.WriteLine("1.���������� � ��������� � �������� ���������.");
WScript.StdOut.WriteLine("2.������� ������ �� ���������� ����� � ��������.");
WScript.StdOut.WriteLine("3.���������� � �������� ���� �������� � ������� �������� �����.");
WScript.StdOut.WriteLine("4.����� � ���������.");
WScript.StdOut.WriteLine("----------------------------------------------");
WScript.StdOut.WriteLine("������� ����� ���������� ������.");
n = WScript.StdIn.ReadLine();
WScript.StdOut.WriteLine("----------------------------------------------");
if(n==1)
{
	WScript.StdOut.WriteLine("|||��������� ������ ��������� ���-11.");
	WScript.StdOut.WriteLine("|||��������� ��������� ����� �� ���������� ����� � ���������.");
	WScript.StdOut.WriteLine("|||��������� ��������� � �������� ���� �������� � ������ �������� �����.");
	WScript.StdOut.WriteLine("");
}
else if(n==2)
{
	WScript.StdOut.WriteLine("|||������� ���� ������ ����������� �����.");
	var Input = WScript.StdIn.ReadLine();
	WScript.StdOut.WriteLine("|||������� ���� ���� ����������� �����.");
	var Output = WScript.StdIn.ReadLine();
	WScript.Echo("������ ���������� ����������� ������");
	FSO.MoveFile(Input + "\\*.*", Output);
	
}
else if(n==3)
{
	WScript.StdOut.WriteLine("������� ���� ���������� ��� ������� |");
	WScript.StdOut.WriteLine("������: C:\\folder1\\folder2 |");
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
	WScript.StdOut.WriteLine("�� ����� �������� �����");	
}
while(end);

