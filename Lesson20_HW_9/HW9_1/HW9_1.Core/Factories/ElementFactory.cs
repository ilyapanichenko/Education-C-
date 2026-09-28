using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Factories;

public class ElementFactory
{
    private readonly IWebDriver _driver;

    public ElementFactory(IWebDriver driver)
    {
        _driver = driver;
    }

    public T Create<T>(By locator)
        where T : BaseElement
    {
        return (T)Activator.CreateInstance(
            typeof(T),
            _driver,
            locator
        )!;
    }
}