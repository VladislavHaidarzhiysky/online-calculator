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

app.MapPut("/expression", (Expression expression) =>
{
    if (expression == null)
    {
        return Results.BadRequest("Incorrect data");
    }
    else
    {
        var calculatorService = app.Services.GetService<ICalculator>();
        return Results.Json(calculatorService.ReceivingAnswer(expression.Exp));
    }
});

app.Run();