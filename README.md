# gym_oop_2024
# Лабораторная работа 1
## Команда 25 
Тема: Онлайн-система для покупки абонементов в спортивный зал

### Состав:
Джаватов Ильяс Абдурахманович  
Цыпандин Алексей Петрович  
Конопля Алексей Константинович  
Гусев Никита Сергеевич  
Брылев Максим Иванович  

## Доменные сущности:
Зал
```
public class Gyms
{
    public int GymId;
    public string GymName;
    public string GymAddress;
}
```

Пользователь
```
public class User
{
    public int UserId;
    public string Name;
    public string LastName;
    public string Surname;
    public string Email;
    public string Phone;
}
```
Абонемент
```
public class Suscription
{
    public int SubscriptionId;
    public string GymId; // foreign
    public string SubscriptionName;
    public double SubscriptionPrice;
    public string SubscriptionDescription;
    public int DefaultDurationInMonths;
}
```

Подписка пользователя
```
public class UserSubscription
{
    public int UserSubscriptionId;
    public int SubscriptionId; // foreign
    public int UserId; // foreign
    public bool IsActive;
    public bool IsMulticard;
    public DateTime StartDate;
    public DateTime EndDate;
}
```
## ERD Diagramm
![image](https://github.com/AlexeyKonoplia/gym_oop_2024/assets/112964950/b1cddf13-de94-44e8-af31-80392d5498d6)
ERD диаграмма  
