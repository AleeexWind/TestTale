# TestTale

### What purpose does it serve? ###
 
 Has it ever happened to you that you want to understand the main point by looking
at the tests, but it takes some time to understand what's going on in it? 
 
If it is true, it would be great to filter the code from unnecessary details and leave the most important information for understanding the purpose of the code.
It is similar to our discussions. You don't tell absolutely all the details in your story. For example, you talk about your weekend. You say something like this: "I spent the weekend travelling by the sea. The weather was warm and sunny, we rented a boat and went to the island". Are there any unnecessary details? No, your tell only as much as was necessary to understand your story, you don't tell what you had for breakfast or whether you took a shower. It was part of your weekend, but not the main point of your story. If you start talking about everything that happend to you over the weekend, it will take a long time, and the listener will get tired of listening.

The same things happens in the code. By the project you can emphasize the main point of the tests, trying to describe what you are testing without unnecessary details

Look at the next examples.  
The first example expose all of the details and it took some time to understand it.

```csharp
    [Fact]
    public async Task Successful_metric_shoud_be_sent()
    {
        Mock<IWeatherForecastRepository> forecastRepositoryMock = new();
        Mock<ILogger<ForecastProvider>> loggerMock = new();
        Mock<IForecastMetricsHandler> forecastMetricsHandlerMock = new();
        ForecastProvider sut = new(
            forecastRepositoryMock.Object,
            loggerMock.Object,
            forecastMetricsHandlerMock.Object);

        WeatherForecast returnedWeatherForecast = new()
        {
            Date = default,
            TimeOfDay = default,
            Region= new Region()
            {
                Id = 1,
                Name = "London"
            },
            Summary = "Sunny",
            TemperatureC = 22
        };

        forecastRepositoryMock
            .Setup(x => x.GetWeatherForecast(
                It.IsAny<int>(),
                It.IsAny<DateRequest>(),
                It.IsAny<TimeOfDay>()))
            .ReturnsAsync(returnedWeatherForecast);

        var result = await sut.ProvideForecastAsync(It.IsAny<int>(), It.IsAny<DateRequest>(), It.IsAny<TimeOfDay>());

        forecastMetricsHandlerMock.Verify(x => x.IncreaseSuccessfulProvidedForecast(), Times.Once);
    }
```
The second example tests the same functionality but all the details are not disclosed, and only the main thing remains.

```csharp
    [Fact]
    public async Task Successful_metric_shoud_be_sent()
    {
        await TestClient
            .Attempts(new GetForecast())
            .Using(new ForecastProviderDependencies())
            .WithAnyParameters()
            .WithSituation(new WhenProvidedForecastIsNotNull())
            .Then(new SeeSuccessfulMetric())
            .RunAsync();
    }
```
I hope that it will be much more convinient to read the second example, because it explains step by step how the test is configured and what is you expect from passing the test. Another advantage is that this code can be understood not only by programmers but also by business people.
