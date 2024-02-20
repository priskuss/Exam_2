using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using TaskManager;


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
///// // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
TaskManager.Task task1 = new TaskManager.Task();
task1.taskID = "rEu25ZX";
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task1.taskID); // Get the task from the server
task1 = JsonSerializer.Deserialize<TaskManager.Task>(task1Response.content);

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
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task1.taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{answer}{ANSICodes.Reset}");
Console.WriteLine($"Response: {Colors.Magenta}{task1AnswerResponse.content}{ANSICodes.Reset}");

Console.WriteLine("\n-----------------------------------\n");


//#### SECOND TASK 
// Fetch the details of the task from the server.
TaskManager.Task task2 = new TaskManager.Task();
task2.taskID = "KO1pD3";
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID); // Get the task from the server
task2 = JsonSerializer.Deserialize<TaskManager.Task>(task2Response.content);

Console.WriteLine($"Task 2: {ANSICodes.Effects.Bold}{Colors.Cyan}{task2.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task2.description}{ANSICodes.Reset}");
Console.WriteLine($"Parameter: {Colors.Green}{task2.parameters}{ANSICodes.Reset}");

// Parse the series from the parameters
string[] parameters = task2.parameters.Split(',');
int[] series = Array.ConvertAll(parameters, int.Parse);

// Calculate the difference between consecutive numbers
int difference = series[1] - series[0];

// Check if the difference is constant
for (int i = 2; i < series.Length; i++)
{
    if (series[i] - series[i - 1] != difference)
    {
        Console.WriteLine("The series is not an arithmetic sequence.");
        return;
    }
}

// Calculate the next number in the series
int nextNumber = series[^1] + difference;

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID, nextNumber.ToString());
Console.WriteLine($"Answer: {Colors.Green}{nextNumber}{ANSICodes.Reset}");
Console.WriteLine($"Response: {Colors.Magenta}{task2AnswerResponse.content}{ANSICodes.Reset}");
