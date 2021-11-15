// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NewNet6Features;

Console.WriteLine("Hello, World!");

//Trig();

//SourceGeneratorLogging();

//ChunkyLinq();

//DefaultLinq();

//HotDates();

//JsonSerializerSourceGeneration();

//ReflectionNullability();

//UnsafeNativeMemory();


#region Maths

void Trig()
{
    var (s, c) = Math.SinCos(0.5);

    Console.WriteLine($"Sin {s}, Cos {c}");
}

#endregion

#region Source Generator logging

void SourceGeneratorLogging()
{
    var services = new ServiceCollection();
    services.AddLogging(builder => builder.AddConsole())
        .AddTransient<InstanceLoggingExample>();

    var provider = services.BuildServiceProvider();

    var loggingExample = provider.GetRequiredService<InstanceLoggingExample>();

    loggingExample.MethodThatLogs();
}

#endregion

#region Chunks
// Linq Chunk
void ChunkyLinq()
{
    var chunks = Enumerable.Range(0, 15).Chunk(3);
    foreach (var chunk in chunks)
    {
        Console.Write(chunk[0]);

        if (chunk.Length > 1)
        {
            Console.Write($", {chunk[1]}");
        }

        if (chunk.Length > 2)
        {
            Console.Write($",{chunk[2]}");
        }
        Console.WriteLine();
    }

}
#endregion

#region Linq default

void DefaultLinq()
{
    var result = Enumerable.Empty<int>().SingleOrDefault(); //-1);

    Console.WriteLine(result);
}

#endregion

#region Dates and Time zones

void HotDates()
{
    // DateOnly
    var date = new DateOnly(2021, 11, 7);
    Console.WriteLine(date);

    TimeZoneInfo.TryConvertIanaIdToWindowsId("Australia/Adelaide", out var windowsTimeZoneId);
    Console.WriteLine(windowsTimeZoneId);
}

#endregion

#region JSON source generator

void JsonSerializerSourceGeneration()
{
    var message = new JsonMessage()
    {
        Message = "Hi there from in here"
    };

    var serialized = JsonSerializer.Serialize(message, JsonContext.Default.JsonMessage);
    Console.WriteLine(serialized);
}

#endregion

#region Reflection Nullability

void ReflectionNullability()
{
    var nullabilityInfoContext = new NullabilityInfoContext();
    var propertyInfo1 = typeof(JsonMessage).GetProperty(nameof(JsonMessage.Message))!;
    var propertyInfo2 = typeof(JsonMessage).GetProperty(nameof(JsonMessage.NotNullableMessage))!;

    var nullabilityInfo = nullabilityInfoContext.Create(propertyInfo1);
    Console.WriteLine(nullabilityInfo.WriteState);
    nullabilityInfo = nullabilityInfoContext.Create(propertyInfo2);
    Console.WriteLine(nullabilityInfo.WriteState);
}

#endregion

#region Native Memory

void UnsafeNativeMemory()
{
    //unsafe
    //{
    //    byte* buffer = (byte*) NativeMemory.Alloc(100);

    //    NativeMemory.Free(buffer);
    //}
}

#endregion