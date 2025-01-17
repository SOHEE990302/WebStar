using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OpenAI;
using System.ClientModel;
using System.Text;

namespace WebStar.Pages;

public class AIModel : PageModel
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly ChatHistory _chat;

    public string? UserQuestion { get; set; }
    public string? AIResponse { get; set; }

    public AIModel(IConfiguration configuration)
    {
        var modelId = configuration["AI:Model"]!;
        var uri = configuration["AI:Endpoint"]!;
        var githubPAT = configuration["AI:PAT"]!;

        var client = new OpenAIClient(
            new ApiKeyCredential(githubPAT),
            new OpenAIClientOptions { Endpoint = new Uri(uri) }
        );

        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(modelId, client);
        var kernel = builder.Build();

        _chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        _chat = new ChatHistory(@"
            You are an AI assistant that helps people find information.
            The response must be brief and should not exceed one paragraph.
            If you do not know the answer then simply say 'I do not know the answer.'");
    }

    public async Task OnPostAsync(string userQuestion)
    {
        UserQuestion = userQuestion;
        _chat.AddUserMessage(userQuestion);

        var strBuilder = new StringBuilder();
        await foreach (var message in _chatCompletionService.GetStreamingChatMessageContentsAsync(_chat))
        {
            strBuilder.Append(message.Content);
        }

        AIResponse = strBuilder.ToString();
        _chat.AddAssistantMessage(AIResponse);
    }
}
