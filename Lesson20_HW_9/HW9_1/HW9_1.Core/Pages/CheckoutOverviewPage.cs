using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutOverviewPage : BasePage
{
    private readonly Label _title;
    private readonly Label _itemName;
    private readonly Label _paymentInfoLabel;
    private readonly Label _itemQuantityLabel;
    private readonly Label _paymentInfoValue;
    private readonly Label _shippingInfoLabel;
    private readonly Label _shippingInfoValue;
    private readonly Label _totalInfoLabel;
    private readonly Label _subtotalLabel;
    private readonly Label _taxLabel;
    private readonly Label _totalLabel;
    private readonly Button _finishButton; 
    #region Elements

    public CheckoutOverviewPage(IWebDriver driver, TestSettings settings) : base(driver,settings)
    {
    _title = ElementFactory.Create<Label>(By.CssSelector("[data-test='title']"));
    _itemName = ElementFactory.Create<Label>(By.CssSelector("[data-test='inventory-item-name']"));
    _paymentInfoLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='payment-info-label']"));
    _itemQuantityLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='item-quantity']"));
    _paymentInfoValue = ElementFactory.Create<Label>(By.CssSelector("[data-test='payment-info-value']"));
    _shippingInfoLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='shipping-info-label']"));
    _shippingInfoValue = ElementFactory.Create<Label>(By.CssSelector("[data-test='shipping-info-value']"));
    _totalInfoLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='total-info-label']"));
    _subtotalLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='subtotal-label']"));
    _taxLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='tax-label']"));
    _totalLabel = ElementFactory.Create<Label>(By.CssSelector("[data-test='total-label']"));
    _finishButton = ElementFactory.Create<Button>(By.CssSelector("[data-test='finish']"));
}

#endregion

    #region Methods

    public string GetTitle() => _title.GetText();
    public string GetItemName() => _itemName.GetText();
    public string GetItemQuantity() => _itemQuantityLabel.GetText();
    public string GetPaymentInfoLabel() => _paymentInfoLabel.GetText();
    public string GetPaymentInfoValue() => _paymentInfoValue.GetText();
    public string GetShippingInfoLabel() => _shippingInfoLabel.GetText();
    public string GetShippingInfoValue() => _shippingInfoValue.GetText();
    public string GetTotalInfoLabel() => _totalInfoLabel.GetText();
    public string GetSubtotal() => _subtotalLabel.GetText();
    public string GetTax() => _taxLabel.GetText();
    public string GetTotal() => _totalLabel.GetText();
    public bool IsFinishButtonPresent() => _finishButton.IsElementPresent();

    public CheckoutCompletePage CompleteOrder()
    {
        _finishButton.Click();
        WaitUntilUrlContains("checkout-complete");
        return new CheckoutCompletePage(Driver, Settings);
    }

    public override bool IsLoaded()
    { 
        return _title.IsElementPresent() && _title.GetText() == "Checkout: Overview";
    }

    public override CheckoutOverviewPage Load()
    {
        return new CheckoutInformationPage(Driver, Settings)
            .Load()
            .EnterFirstName("Ilia")
            .EnterLastName("Panichenko")
            .EnterPostalCode("12345678")
            .ClickContinue();
    }
    
    #endregion
}