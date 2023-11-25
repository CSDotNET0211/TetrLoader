using System.Text;
using TetrLoader;
using TetrLoader.Enum;
using TetrLoader.JsonClass;

START: ;
string jsonString = string.Empty;
//string fileName = Console.ReadLine();
string fileName = @"C:\Users\CSDotNET\Downloads\v16__2HfCA1pM.ttrm";
fileName = fileName.Replace("\"", "");
using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
{
	jsonString = reader.ReadToEnd();
}

Console.WriteLine(Util.IsMulti(ref jsonString));

var IReplayData = ReplayLoader.ParseReplay(jsonString, ReplayKind.TTRM);
//保存先のファイル名

var events = IReplayData.GetReplayEvents(0, 0);


Console.WriteLine("a");
goto START;