namespace HW6_1_Sort;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Customer> customers = new()
        {
            new Customer(1, "Иван", "Балашиха", new DateTime(2024, 1, 10)),
            new Customer(2, "Илья", "Реутов", new DateTime(2024, 1, 15)),
            new Customer(3, "Валентина", "Реутов", new DateTime(2024, 2, 1)),
            new Customer(4, "Стивен", "Лондон", new DateTime(2024, 2, 5))
        };

        List<Order> orders = new()
        {
            new Order(1, 1, new DateTime(2024, 2, 5), 400, "Pending"),
            new Order(2, 2, new DateTime(2024, 2, 10), 2500, "Completed"),
            new Order(3, 3, new DateTime(2024, 2, 15), 3700, "Completed"),
            new Order(4, 4, new DateTime(2024, 3, 4), 4000, "Cancelled")
        };
        //Задание 1
        IEnumerable<Order> completedOrders = orders.Where(o => o.Status == "Completed" && o.TotalAmount > 2000);
        Console.WriteLine($"Все завершенные (Completed) заказы на сумму больше 2000:");
        foreach (Order order in completedOrders)
        {
            Console.WriteLine
            ($"Id заказа: {order.Id} " +
             $"Id покупателя: {order.CustomerId} " +
             $"Дата заказа: {order.OrderDate:d} " +
             $"Итоговая сумма: {order.TotalAmount}р. " +
             $"Статус заказа: {order.Status}");
        }

        //Задание 2 
        Console.WriteLine($"Список, содержащий имена клиентов и их общую сумму заказов:");
        var customerTotals = customers.Select(customer => new
        {
            customer.Name,
            TotalAmount = orders
                .Where(order => order.CustomerId == customer.Id)
                .Sum(order => order.TotalAmount)
        });

        foreach (var customer in customerTotals)
        {
            Console.WriteLine(
                $"{customer.Name} — общая сумма: {customer.TotalAmount} р."
            );
        }

        //Задание 3
        Console.WriteLine("Заказы по городу клиента: ");
        var ordersWithCity = orders.Join(
            customers,
            order => order.CustomerId,
            customer => customer.Id,
            (order, customer) => new
            {
                Order = order,
                City = customer.City
            });
        var result = ordersWithCity.GroupBy(item => item.City).Select(group => new
        {
            City = group.Key,
            OrderCount = group.Count(),
            TotalSales = group.Sum(item => item.Order.TotalAmount)
        });
        foreach (var item in result)
        {
            Console.WriteLine(
                $"Город - {item.City}; Количество заказов: {item.OrderCount}; Общая сумма продаж:{item.TotalSales} р.");
        }

        //Задание 4
        Console.WriteLine("Топ-3 клиентов по сумме заказов за февраль 2024:");
        var februaryOrders = orders
            .Where(order =>
                order.OrderDate >= new DateTime(2024, 2, 1) &&
                order.OrderDate < new DateTime(2024, 3, 1));
        var customersWithFebruaryOrders = februaryOrders.Join(
            customers,
            order => order.CustomerId,
            customer => customer.Id,
            (order, customer) => new
            {
                Customer = customer,
                Order = order
            });
        var resultTop = customersWithFebruaryOrders
            .GroupBy(item => new
            {
                item.Customer.Id,
                item.Customer.Name
            })
            .Select(group => new
            {
                CustomerName = group.Key.Name,
                TotalAmount = group.Sum(item => item.Order.TotalAmount)
            })
            .OrderByDescending(item => item.TotalAmount)
            .Take(3);
        int place = 1;
        foreach (var customer in resultTop)
        {
            Console.WriteLine(
                $"{place}) {customer.CustomerName} — {customer.TotalAmount} р."
            );
            place++;
        }

        //Здание 5
        Console.WriteLine("Список заказов с именами клиентов:");
        var report = orders
            .Join(
                customers,
                order => order.CustomerId,
                customer => customer.Id,
                (order, customer) => new
                {
                    Order = order,
                    CustomerName = customer.Name
                })
            .OrderByDescending(item => item.Order.OrderDate);
        foreach (var customer in report)
        {
            Console.WriteLine(
                $"Имя клиента: {customer.CustomerName}, " +
                $"Id заказа: {customer.Order.Id}, " +
                $"дата: {customer.Order.OrderDate:d}, " +
                $"сумма: {customer.Order.TotalAmount} р., " +
                $"статус: {customer.Order.Status}"
            );
        }
    }
}