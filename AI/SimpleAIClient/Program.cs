using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ModelRunnerClient
{
    public class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string DockerModelRunnerApiUrl = "http://localhost:12434/engines/llama.cpp/v1/chat/completions";

        // Use this URL to connect to an AI running with LMStudio server
        // private const string DockerModelRunnerApiUrl = "http://192.168.4.34:1234/v1/chat/completions";
        public static async Task Main()
        {
            Console.WriteLine("Welcome to the Docker Model Runner .NET Client!");
            Console.WriteLine("This version works with Docker Model Runner's ai/smollm2 model.");
            Console.WriteLine("Type your prompt and press Enter (type 'exit' to quit):");

            // https://huggingface.co/collections/HuggingFaceTB/smollm2-6723884218bcda64b34d7db9

            while (true)
            {
                Console.Write("> ");
                string? prompt = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(prompt) || prompt.ToLower() == "exit")
                    break;

                // var modelUnderTest = "ai/smollm2";
                var modelUnderTest = "claude-3.7-sonnet-reasoning-gemma3-12b";

                var requestPayload = new
                {
                    model = modelUnderTest,
                    messages = new[]
                    {
                           new { role = "system", content = "You are a helpful coding assistant." },
                           new { role = "user", content = prompt }
                       }
                };

                try
                {
                    var response = await _httpClient.PostAsJsonAsync(DockerModelRunnerApiUrl, requestPayload);
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                    if (result?.choices?.Length > 0)
                    {
                        Console.WriteLine($"\nAI: {result!.choices[0]!.message!.content}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nAI: No response received.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                    Console.WriteLine("Make sure Docker Model Runner is enabled and TCP support is enabled.");
                    Console.WriteLine("Check if the service is running at http://localhost:12434\n");
                }
            }
        }
    }

    public class OpenAIResponse
    {
        public Choice[]? choices { get; set; }
        public int created { get; set; }
        public string? id { get; set; }
        public string? model { get; set; }
        public string? object_type { get; set; }
        public Usage? usage { get; set; }
    }

    public class Choice
    {
        public Message? message { get; set; }
        public int index { get; set; }
        public string? finish_reason { get; set; }
    }

    public class Message
    {
        public string? role { get; set; }
        public string? content { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}