### Задание по коллекциям лямбдам и LINQ

У вас есть две коллекции: список заказов и список клиентов. Вам нужно сформировать отчет по продажам за определенный
период.
public class Customer
{
public int Id { get; set; }
public string Name { get; set; }
public string City { get; set; }
public DateTime RegistrationDate { get; set; }
}

public class Order
{
public int Id { get; set; }
public int CustomerId { get; set; }
public DateTime OrderDate { get; set; }
public decimal TotalAmount { get; set; }
public string Status { get; set; } // "Completed", "Cancelled", "Pending"
}

Задание 1. Фильтрация (Where + лямбда)
Выведите все завершенные (Completed) заказы на сумму больше 2000.

Задание 2. Проекция (Select + анонимный тип)
Создайте список, содержащий имена клиентов и их общую сумму заказов.

Задание 3. Группировка (GroupBy)
Сгруппируйте заказы по городу клиента. Для каждого города выведите:
Количество заказов
Общую сумму продаж

Задание 4*. Фильтрация + Проекция + Сортировка
Составьте топ-3 клиентов по сумме заказов за февраль 2024. Выведите имя клиента и общую сумму.

Задание 5*. Join
Создайте отчет: список заказов с именем клиента. Отсортируйте по дате заказа (от новых к старым).