using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Red}{Constants.STARTING_ASSIGNMENT}{ANSICodes.Reset}");

// SETUP 
const string myPersonalID = "671d17d680b222051ca8593eb0cf836d57df720db5d08e026316d0c72fb753b9";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = Constants.START; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = Constants.TASK;   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### FIRST TASK 
// Fetch the details of the task from the server.
TaskManager.Task task1 = new TaskManager.Task();
task1.taskID = TaskManager.Task.TASK_ID_ONE;
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task1.taskID); // Get the task from the server
task1 = JsonSerializer.Deserialize<TaskManager.Task>(task1Response.content);

// Calculate the answer to the task
string RomanNumber = task1?.parameters;
int answerTaskOne = ConvertRomanToInt(RomanNumber);
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_1}{task1.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task1.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{task1.parameters}{ANSICodes.Reset}");

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

    int answerTaskOne = 0;

    for (int i = 0; i < s.Length; i++)
    {
        if (i + 1 < s.Length && RomanMap[s[i]] < RomanMap[s[i + 1]])
        {
            answerTaskOne -= RomanMap[s[i]];
        }
        else
        {
            answerTaskOne += RomanMap[s[i]];
        }
    }
    return answerTaskOne;
}

// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task1.taskID, answerTaskOne.ToString());
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskOne}{ANSICodes.Reset}");
//Console.WriteLine($"{Constants.RESPONSE}{Colors.Magenta}{task1AnswerResponse.content}{ANSICodes.Reset}");

Console.WriteLine(Constants.CONSOLE_DIVIDER);


//#### SECOND TASK 
// Fetch the details of the task from the server.
TaskManager.Task task2 = new TaskManager.Task();
task2.taskID = TaskManager.Task.TASK_ID_TWO;
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID); // Get the task from the server
task2 = JsonSerializer.Deserialize<TaskManager.Task>(task2Response.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_2}{task2.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task2.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{task2.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task 
string[] parameters = task2.parameters.Split(',');
int[] series = Array.ConvertAll(parameters, int.Parse);

int difference = series[1] - series[0];

for (int i = 2; i < series.Length; i++)
{
    if (series[i] - series[i - 1] != difference)
    {
        Console.WriteLine("The series is not an arithmetic sequence.");
        return;
    }
}

int answerTaskTwo = series[^1] + difference;

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task2.taskID, answerTaskTwo.ToString());
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskTwo}{ANSICodes.Reset}");
//Console.WriteLine($"{Constants.RESPONSE}{Colors.Magenta}{task2AnswerResponse.content}{ANSICodes.Reset}");

Console.WriteLine(Constants.CONSOLE_DIVIDER);

//#### THIRD TASK 
// Fetch the details of the task from the server.
TaskManager.Task task3 = new TaskManager.Task();
task3.taskID = TaskManager.Task.TASK_ID_THREE;
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task3.taskID); // Get the task from the server
task3 = JsonSerializer.Deserialize<TaskManager.Task>(task3Response.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_3}{task3.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task3.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{task3.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
int number = int.Parse(task3.parameters);
string OddOrEven(int number)
{
    if (number % 2 == 0)
    {
        return "even";
    }
    else
    {
        return "odd";
    }
}
string answerTaskThree = OddOrEven(number);

// Send the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task3.taskID, answerTaskThree);
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskThree}{ANSICodes.Reset}");
//Console.WriteLine($"{Constants.RESPONSE}{Colors.Magenta}{task3AnswerResponse.content}{ANSICodes.Reset}");

Console.WriteLine(Constants.CONSOLE_DIVIDER);

//#### FOURTH TASK
// Fetch the details of the task from the server.
TaskManager.Task task4 = new TaskManager.Task();
task4.taskID = TaskManager.Task.TASK_ID_FOUR;
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + task4.taskID); // Get the task from the server
task4 = JsonSerializer.Deserialize<TaskManager.Task>(task4Response.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_4}{task4.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{task4.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{task4.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
string[] words = task4.parameters.Split(',');
string[] uniqueWords = words.Distinct().OrderBy(word => word).ToArray();
string answerTaskFour = string.Join(",", uniqueWords);

// Send the answer to the server
Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + task4.taskID, answerTaskFour);
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskFour}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Red}{Constants.FINAL_MESSAGE}{ANSICodes.Reset}");
//Console.WriteLine($"{Constants.RESPONSE}{Colors.Magenta}{task4AnswerResponse.content}{ANSICodes.Reset}");