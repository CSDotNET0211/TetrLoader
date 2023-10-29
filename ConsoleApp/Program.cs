using System.Security.Cryptography.X509Certificates;
using System.Text;
using TetrLoader;
using TetrLoader.Enum;

string jsonData = string.Empty;
using (StreamReader reader = new StreamReader(@"C:\Users\CSDotNET\Downloads\ohno.ttrm", Encoding.UTF8))
{
	jsonData = reader.ReadToEnd();
}

var IReplayData = ReplayLoader.ParseReplay(jsonData, ReplayKind.TTRM);

Console.WriteLine("a");
