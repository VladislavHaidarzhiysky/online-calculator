using OnlineCalculator.Solutions;
using OnlineCalculator;
using OnlineCalculator.CalculatorTemplate;
using OnlineCalculator.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalculator, StandardCalculator>()
                .AddSingleton<IOperation, StandardOperation>()
                .AddSingleton<IRegexExpression, RegexExpression>();

var app = builder.Build();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Add("content.html"); 
app.UseDefaultFiles(options);
app.UseStaticFiles();

app.Map("/expression", async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    try
    {
        var expression = await request.ReadFromJsonAsync<Expression>();
        if (expression == null)
        {
            throw new Exception();
        }
        else
        {
            var calculatorService = app.Services.GetService<ICalculator>();
            await response.WriteAsJsonAsync(calculatorService.ReceivingAnswer(expression.Exp));
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync("Incorrect data");
    }
});

app.Run();