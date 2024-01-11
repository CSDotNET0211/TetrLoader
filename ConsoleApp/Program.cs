﻿using System.Text;
using TetrLoader;
using TetrLoader.Enum;
using TetrLoader.JsonClass;

START: ;
string jsonString = string.Empty;
//string fileName = Console.ReadLine();
string fileName = @"C:\Users\CSDotNET\Downloads\rMS7ralU5.ttrm";
fileName = fileName.Replace("\"", "");
using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
{
	jsonString = reader.ReadToEnd();
}

Console.WriteLine(Util.IsMulti(ref jsonString));

var IReplayData = ReplayLoader.ParseReplay(jsonString, ReplayKind.TTRM);
//保存先のファイル名
var usernames = IReplayData.GetUsernames();

var events = IReplayData.GetReplayEvents(usernames[0], 0);
var stats = IReplayData.GetReplayStats(usernames[0],0);


Console.WriteLine("a");
goto START;