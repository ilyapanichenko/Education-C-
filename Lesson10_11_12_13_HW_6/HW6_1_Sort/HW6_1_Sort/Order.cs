namespace HW6_1_Sort;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } // "Completed", "Cancelled", "Pending"

    public Order(int id, int customerId, DateTime orderDate, decimal totalAmount, string status)
    {
        Id = id;
        CustomerId = customerId;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
        Status = status;
    }
}