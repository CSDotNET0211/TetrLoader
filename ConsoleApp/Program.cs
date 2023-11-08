using System.Text;
using TetrLoader;
using TetrLoader.Enum;
using TetrLoader.JsonClass;

string jsonData = string.Empty;
using (StreamReader reader = new StreamReader(@"C:\Users\CSDotNET\Downloads\ew\minest3.17replay.ttrm", Encoding.UTF8))
{
	jsonData = reader.ReadToEnd();
}

var IReplayData = ReplayLoader.ParseReplay(jsonData, ReplayKind.TTRM);
//保存先のファイル名
string fileName = "C:\\Users\\CSDotNET\\Downloads\\ew\\data.ttrmx";




Console.WriteLine("a");
