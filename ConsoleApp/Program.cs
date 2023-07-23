using System.Security.Cryptography.X509Certificates;
using System.Text;
using TetrLoader;

string jsonData = string.Empty;
using (StreamReader reader = new StreamReader(@"C:\Users\CSDotNET\Downloads\zero-replay3.ttrm", Encoding.UTF8))
{
	jsonData = reader.ReadToEnd();
}

var IReplayData = ReplayLoader.ParseReplay(jsonData, ReplayKind.TTRM);

Console.WriteLine("a");
