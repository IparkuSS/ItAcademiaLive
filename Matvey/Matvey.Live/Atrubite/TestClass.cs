namespace Matvey.Live.Atrubite { 
[DisplayName("Пользователь")]
public class User
{
    [DisplayName("Идентификатор")]
    public int Id { get; set; }

    [DisplayName("Имя пользователя")]
    public string Username { get; set; }

    [DisplayName("Электронная почта")]
    public string Email { get; set; }

    [DisplayName("Дата регистрации")]
    public DateTime RegistrationDate { get; set; }

    [DisplayName("Активен")]
    public bool IsActive { get; set; }

    public int Age;
}

[DisplayName("Точка")]
public struct Point
{
    [DisplayName("Координата X")]
    public int X { get; set; }

    [DisplayName("Координата Y")]
    public int Y { get; set; }
}

[DisplayName("Заказ")]
public class Order
{
    [DisplayName("Номер заказа")]
    public string OrderNumber { get; set; }

    [DisplayName("Сумма заказа", Description = "Общая стоимость заказа", Order = 1)]
    public decimal TotalAmount { get; set; }

    [DisplayName("Дата создания")]
    public DateTime CreatedAt { get; set; }

    [DisplayName("Статус")]
    public string Status { get; set; }
}
}
