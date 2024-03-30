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
```C#
public class Gyms
{
    public int GymId;
    public string GymName;
    public string GymAddress;
}
```

Пользователь
```C#
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
```C#
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
```C#
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

## Методы работы онлайн-сервиса(REST API)

### `POST /registration` – Регистрация пользователя
Тело запроса: POST


Request:
```json
{
  "name": "Иван",
  "last_name": "Иванов",
  "surname": "Иванович",
  "email": "ivanov2000@mail.ru",
  "phone": "9999999999",
  "password": "qwerty"
}
```
Response:
```json
{
  "status": "200",
  "message": "User registered successfully"
}
```


### `POST /login` - Авторизация пользователя
Тело запроса: POST


Request:
```json
{
  "email": "email@email.com",
  "password": "qwerty"
}
```
Response:
```json
{
  "userId": "123",
  "Message": "You have successfully logged in!",
  "access token": "123lfweo1234K"
}
```

### `GET /profile` - Личный кабинет пользователя
Тело запроса: GET


Request:
```json
{
  "userId": "123"
}
```
Response:
```json
{
  "name": "Иван",
  "last_name": "Иванов",
  "surname": "Иванович",
  "email": "ivanov2000@mail.ru",
  "phone": "9999999999",
  "subscription_date": "1111-11-11 11:11",
  "subscription_info": "something"
}
```

### `PUT /profile/change-data` - Изменение информации о пользователе
Тело запроса: PUT


Request:
```json
{
  "new_user_info": "info"
}
```
Response:
```json
{
  "status": "success",
  "message": "Account info changed successfully!"
}
```

### `POST /payment` - Оплата
Тело запроса: GET


Request:
```json
{
  "subscription_id": 123,
  "user_id": 456,
  "payment_method": "credit_card",
  "amount": 15000
}
```
Response:
```json
{
  "status": "success",
  "message": "Payment was successful!"
}
```

### `POST /payment` - Оплата
Тело запроса: GET


Request:
```json
{
  "subscription_id": 123,
  "user_id": 456,
  "payment_method": "credit_card",
  "amount": 15000
}
```
Response:
```json
{
  "status": "success",
  "message": "Payment successful"
}
```

### `GET /subscriptions` - Список абонементов
Тело запроса: GET


Response:
```json
{
   "subscriptions": [
     {
       "id": 123,
       "type": "multicard",
       "price": 50.00,
       "description": "legendary subscription"
     }, 
     {
       "id": 124,
       "type": "annual", 
       "price": 500.00,
       "description": "Not bad subscription"
     }]
}
```

### `/profile/freeze-subscription` - Заморозка абонемента
Тело запроса: GET


Request:
```json
{
  "userId": 123,
  "freezeDuration": "1 month",
  "isActive": false
}
```
Response:
```json
{
  "status": "success",
  "message": "Subscription was frozen for 1 month!"
}
```

## Интерфейсы
```C#
public interface IGymRepository
{
    Gym GetGymById(int gymId);
    IEnumerable<Gym> GetAllGyms();
    IEnumerable<Gym> GetAllGymsByAddress(string GymAddress);
    void AddGym(Gym gym);
    void UpdateGym(Gym gym);
    void DeleteGym(int gymId);
}
```

```C#
public interface ISubscriptionRepository
{
    Subscription GetSubscriptionById(int subscriptionId);
    IEnumerable<Subscription> GetAllSubscriptions();
    IEnumerable<Subscription> GetSubscriptionsByGymId(int gymId);
    void AddSubscription(Subscription subscription);
    void UpdateSubscription(Subscription subscription);
    void DeleteSubscription(int subscriptionId);
}
```

```C#
public interface IUserRepository
{
    User GetUserById(int userId);
    User GetUserByPhone(string Phone);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
```

```C#
public interface IUserSubscriptionRepository
{
    IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(int userId);
    IEnumerable<UserSubscription> GetActiveUserSubscriptionsByUserId(int userId);
    void AddUserSubscription(UserSubscription userSubscription);
    void UpdateUserSubscription(UserSubscription userSubscription);
    void DeleteUserSubscription(int userSubscriptionId);
}
```

## ERD Diagramm
![image](https://github.com/AlexeyKonoplia/gym_oop_2024/assets/112964950/b1cddf13-de94-44e8-af31-80392d5498d6)
ERD диаграмма  
