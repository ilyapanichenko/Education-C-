using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class CheckoutOverviewPage(IWebDriver driver) : BasePage(driver)
{
    #region Elements

    private readonly Label _title = new(driver, By.CssSelector("[data-test='title']"));
    private readonly Label _itemName = new(driver, By.CssSelector("[data-test='inventory-item-name']"));
    private readonly Label _paymentInfoLabel = new(driver, By.CssSelector("[data-test='payment-info-label']"));
    private readonly Label _itemQuantityLabel = new(driver, By.CssSelector("[data-test='item-quantity']"));
    private readonly Label _paymentInfoValue = new(driver, By.CssSelector("[data-test='payment-info-value']"));
    private readonly Label _shippingInfoLabel = new(driver, By.CssSelector("[data-test='shipping-info-label']"));
    private readonly Label _shippingInfoValue = new(driver, By.CssSelector("[data-test='shipping-info-value']"));
    private readonly Label _totalInfoLabel = new(driver, By.CssSelector("[data-test='total-info-label']"));
    private readonly Label _subtotalLabel = new(driver, By.CssSelector("[data-test='subtotal-label']"));
    private readonly Label _taxLabel = new(driver, By.CssSelector("[data-test='tax-label']"));
    private readonly Label _totalLabel = new(driver, By.CssSelector("[data-test='total-label']"));
    private readonly Button _finishButton = new(driver, By.CssSelector("[data-test='finish']"));

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
        return new CheckoutCompletePage(Driver);
    }

    #endregion
}