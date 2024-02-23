using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Red}{Constants.STARTING_ASSIGNMENT}{ANSICodes.Reset}");

// SETUP 
const string myPersonalID = Constants.MY_PERSONAL_ID;
const string baseURL = Constants.baseURL;
const string startEndpoint = Constants.START; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = Constants.TASK;   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### FIRST TASK 
// Fetch the details of the task from the server.
TaskManager.Task FirstTask = new TaskManager.Task
{
    taskID = TaskManager.Task.TASK_ID_ONE
};

Response FirstTaskResponse = await httpUtils.Get($"{baseURL}{taskEndpoint}{myPersonalID}/{FirstTask.taskID}"); // Get the task from the server
FirstTask = JsonSerializer.Deserialize<TaskManager.Task>(FirstTaskResponse.content);

// Calculate the answer to the task
string RomanNumber = FirstTask?.parameters;
int answerTaskOne = ConvertRomanToInt(RomanNumber);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_1}{FirstTask.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{FirstTask.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{FirstTask.parameters}{ANSICodes.Reset}");

static int ConvertRomanToInt(string s)
{
    Dictionary<char, int> RomanMap = new Dictionary<char, int>
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
Response FirstTaskAnswerResponse = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{FirstTask.taskID}", answerTaskOne.ToString());
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskOne}{ANSICodes.Reset}");

ConsoleUtils.PrintColorfulDivider();

//#### SECOND TASK 
// Fetch the details of the task from the server.
TaskManager.Task SecondTask = new TaskManager.Task
{
    taskID = TaskManager.Task.TASK_ID_TWO
};

Response SecondTaskResponse = await httpUtils.Get($"{baseURL}{taskEndpoint}{myPersonalID}/{SecondTask.taskID}"); // Get the task from the server
SecondTask = JsonSerializer.Deserialize<TaskManager.Task>(SecondTaskResponse.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_2}{SecondTask.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{SecondTask.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{SecondTask.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task 
string[] parameters = SecondTask.parameters.Split(',');
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
Response SecondTaskAnswerResponse = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{SecondTask.taskID}", answerTaskTwo.ToString());
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskTwo}{ANSICodes.Reset}");

ConsoleUtils.PrintColorfulDivider();

//#### THIRD TASK 
// Fetch the details of the task from the server.
TaskManager.Task ThirdTask = new TaskManager.Task
{
    taskID = TaskManager.Task.TASK_ID_THREE
};

Response ThirdTaskResponse = await httpUtils.Get($"{baseURL}{taskEndpoint}{myPersonalID}/{ThirdTask.taskID}"); // Get the task from the server
ThirdTask = JsonSerializer.Deserialize<TaskManager.Task>(ThirdTaskResponse.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_3}{ThirdTask.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{ThirdTask.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{ThirdTask.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
int number = int.Parse(ThirdTask.parameters);

string IsOddOrEven(int number)
{
    return number % 2 == 0 ? "even" : "odd";
}

string answerTaskThree = IsOddOrEven(number);

// Send the answer to the server
Response ThirdTaskAnswerResponse = await httpUtils.Post($"{baseURL}{taskEndpoint}{myPersonalID}/{ThirdTask.taskID}", answerTaskThree);
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskThree}{ANSICodes.Reset}");

ConsoleUtils.PrintColorfulDivider();

//#### FOURTH TASK 
// Fetch the details of the task from the server.
TaskManager.Task FourthTask = new TaskManager.Task
{
    taskID = TaskManager.Task.TASK_ID_FOUR
};

Response FourthTaskResponse = await httpUtils.Get($"{baseURL}{taskEndpoint}{myPersonalID}/{FourthTask.taskID}"); // Get the task from the server
FourthTask = JsonSerializer.Deserialize<TaskManager.Task>(FourthTaskResponse.content);

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Cyan}{Constants.TASK_4}{FourthTask.title}{ANSICodes.Reset}");
Console.WriteLine($"{Colors.Blue}{FourthTask.description}{ANSICodes.Reset}");
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.PARAMETER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{FourthTask.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
string[] words = FourthTask.parameters.Split(',');
string[] uniqueWords = words.Distinct().OrderBy(word => word).ToArray();
string answerTaskFour = string.Join(",", uniqueWords);

// Send the answer to the server
Response FourthTaskAnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + FourthTask.taskID, answerTaskFour);
Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Yellow}{Constants.ANSWER}{ANSICodes.Reset}{ANSICodes.Effects.Bold}{Colors.Green}{answerTaskFour}{ANSICodes.Reset}");

ConsoleUtils.PrintColorfulDivider();

Console.WriteLine($"{ANSICodes.Effects.Bold}{Colors.Red}{Constants.FINAL_MESSAGE}{ANSICodes.Reset}");