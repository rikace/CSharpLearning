using System;
using System.IO;
using System.Threading.Tasks;
using AsyncExamples;

public class Program
{
    public static async Task Main()
    {
        await Program.CreateFileAsync("test.txt");
    }

    static void RunAsyncSearch()
    {
        var names = new List<string> { "Joe", "May", "Chris" };
        Task<UserInfo> userTask = new UserSearch().GetUserInfoAsync("M", names);
        UserInfo info = userTask.Result;

        Console.WriteLine($"User Address: {info.Address}");
        Console.ReadKey();
    }
    public static async Task CreateFileAsync(string filename)
    {
        using (StreamWriter writer = File.CreateText(filename))
            await writer.WriteAsync("This is a test.");
    }

    public async Task<string> ReturnGreeting()
    {
        await Task.Delay(1000);
        return "Hello";
    }

    public async void SayGreeting()
    {
        await Task.Delay(1000);
        Console.WriteLine("Hello");
    }
}