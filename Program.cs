using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "671d17d680b222051ca8593eb0cf836d57df720db5d08e026316d0c72fb753b9";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "rEu25ZX"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
//Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
string RomanNumber = task1?.parameters;
var answer = ConvertRomanToInt(RomanNumber);
Console.WriteLine($"Task 1: {ANSICodes.Effects.Bold}{ANSICodes.Effects.Bold}{Colors.Cyan}{task1.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task1.description}{ANSICodes.Reset}");
Console.WriteLine($"Parameter: {Colors.Green}{task1.parameters}{ANSICodes.Reset}");

static int ConvertRomanToInt(string s)
{
    Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 }
    };

    int number = 0;

    for (int i = 0; i < s.Length; i++)
    {
        if (i + 1 < s.Length && RomanMap[s[i]] < RomanMap[s[i + 1]])
        {
            number -= RomanMap[s[i]];
        }
        else
        {
            number += RomanMap[s[i]];
        }
    }

    return number;
}


// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{answer}{ANSICodes.Reset}");
Console.WriteLine($"Response: {Colors.Magenta}{task1AnswerResponse.content}{ANSICodes.Reset}");

Console.WriteLine("\n-----------------------------------\n");

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}