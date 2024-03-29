# SkiServiceModels.EF

This package contains the EF models for the SkiService project.

## Installation

```bash
dotnet add package SkiServiceModels.EF
```

## Contents

<!--TOC-->
- [SkiServiceModels.EF](#skiservicemodelsef)
  - [Installation](#installation)
  - [Contents](#contents)
  - [DTOs/Requests](#dtosrequests)
    - [CreateOrderRequest](#createorderrequest)
    - [CreatePriorityRequest](#createpriorityrequest)
    - [CreateServiceRequest](#createservicerequest)
    - [CreateStateRequest](#createstaterequest)
    - [CreateUserRequest](#createuserrequest)
    - [UpdateOrderRequest](#updateorderrequest)
    - [UpdatePriorityRequest](#updatepriorityrequest)
    - [UpdateServiceRequest](#updateservicerequest)
    - [UpdateStateRequest](#updatestaterequest)
    - [UpdateUserRequest](#updateuserrequest)
    - [Base](#base)
      - [CreateRequest](#createrequest)
      - [UpdateRequest](#updaterequest)
  - [DTOs/Responses](#dtosresponses)
    - [LoginResponse](#loginresponse)
    - [OrderResponse](#orderresponse)
    - [PriorityResponse](#priorityresponse)
    - [ServiceResponse](#serviceresponse)
    - [StateResponse](#stateresponse)
    - [UserResponse](#userresponse)
    - [Base](#base-1)
      - [ModelResponse](#modelresponse)
  - [Interfaces](#interfaces)
    - [IOrder](#iorder)
    - [IPriority](#ipriority)
    - [IService](#iservice)
    - [IState](#istate)
    - [IUser](#iuser)
    - [Base](#base-2)
      - [IModel](#imodel)
  - [Models](#models)
    - [Order](#order)
    - [Priority](#priority)
    - [Service](#service)
    - [State](#state)
    - [User](#user)
    - [Refresh Result](#refresh-result)
    - [Base](#base-3)
      - [Model](#model)
<!--/TOC-->


## DTOs/Requests

### CreateOrderRequest
[back up](#contents)
```csharp
public class CreateOrderRequest : CreateRequest, IOrder
{
    [JsonProperty("priority_id")]
    public int PriorityId { get; set; }

    [JsonProperty("service_id")]
    public int ServiceId { get; set; }

    [JsonProperty("state_id")]
    public int StateId { get; set; }

    [JsonProperty("user_id")]
    public int? UserId { get; set; }

    [JsonProperty("email")]
    public required string Email { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("note")]
    public string? Note { get; set; }

    [JsonProperty("phone")]
    public required string Phone { get; set; }

    // Hidden properties since they are not allowed to be updated

    DateTime IOrderBase.Created { get; set; }

    IUser? IOrder.User { get; set; }
    [AllowNull]
    IState IOrder.State { get; set; }
    [AllowNull]
    IPriority IOrder.Priority { get; set; }
    [AllowNull]
    IService IOrder.Service { get; set; }
}
```


### CreatePriorityRequest
[back up](#contents)
```csharp
public class CreatePriorityRequest : CreateRequest, IPriority
{
    [JsonProperty("days")]
    public int Days { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }
}
```


### CreateServiceRequest
[back up](#contents)
```csharp
public class CreateServiceRequest : CreateRequest, IService
{

    [JsonProperty("description")]
    public required string Description { get; set; }


    [JsonProperty("name")]
    public required string Name { get; set; }


    [JsonProperty("price")]
    public int Price { get; set; }
}
```


### CreateStateRequest
[back up](#contents)
```csharp
public class CreateStateRequest : CreateRequest, IState
{
    [JsonProperty("name")]
    public required string Name { get; set; }
}
```


### CreateUserRequest
[back up](#contents)
```csharp
public class CreateUserRequest : CreateRequest, IUser
{
    [JsonProperty("role")]
    public RoleNames Role { get; set; } = RoleNames.User;

    [JsonProperty("username")]
    public required string Username { get; set; }

    // Hidden properties since they are not allowed to be updated

    int IUserBase.LoginAttempts { get; set; }
    string? IUserBase.RefreshToken { get; set; }
    [AllowNull]
    byte[] IUserBase.PasswordHash { get; set; }
    [AllowNull]
    byte[] IUserBase.PasswordSalt { get; set; }
    bool IUserBase.Locked { get; set; }
}
```


### UpdateOrderRequest
[back up](#contents)
```csharp
public class UpdateOrderRequest : UpdateRequest, IOrder
{
    [JsonProperty("priority_id")]
    public int? PriorityId { get; set; } = null;

    [JsonProperty("service_id")]
    public int? ServiceId { get; set; } = null;

    [JsonProperty("state_id")]
    public int? StateId { get; set; } = null;

    [JsonProperty("user_id")]
    public int? UserId { get; set; } = null;

    int IOrder.PriorityId
    {
        get => PriorityId ?? 0;
        set => PriorityId = value;
    }
    int IOrder.ServiceId
    {
        get => ServiceId ?? 0;
        set => ServiceId = value;
    }
    int IOrder.StateId
    {
        get => StateId ?? 0;
        set => StateId = value;
    }
    int? IOrder.UserId
    {
        get => UserId ?? 0;
        set => UserId = value;
    }

    [AllowNull]
    [JsonProperty("email")]
    public string Email { get; set; } = null;

    [AllowNull]
    [JsonProperty("name")]
    public string Name { get; set; } = null;

    [JsonProperty("note")]
    public string? Note { get; set; } = null;

    [AllowNull]
    [JsonProperty("phone")]
    public string Phone { get; set; } = null;

    // Hidden properties since they are not allowed to be updated

    DateTime IOrderBase.Created { get; set; }

    IUser? IOrder.User { get; set; }
    [AllowNull]
    IState IOrder.State { get; set; }
    [AllowNull]
    IPriority IOrder.Priority { get; set; }
    [AllowNull]
    IService IOrder.Service { get; set; }
}
```


### UpdatePriorityRequest
[back up](#contents)
```csharp
public class UpdatePriorityRequest : UpdateRequest, IPriority
{
    [JsonProperty("days")]
    public int? Days { get; set; } = null;

    [AllowNull]
    [JsonProperty("name")]
    public string Name { get; set; } = null;

    // Implemented properties but with allowed null values

    int IPriorityBase.Days
    {
        get => Days ?? 0;
        set => Days = value;
    }
}
```


### UpdateServiceRequest
[back up](#contents)
```csharp
public class UpdateServiceRequest : UpdateRequest, IService
{
    [AllowNull]
    [JsonProperty("description")]
    public string Description { get; set; } = null;

    [AllowNull]
    [JsonProperty("name")]
    public string Name { get; set; } = null;

    [JsonProperty("price")]
    public int? Price { get; set; } = null;

    // Implemented properties but with allowed null values

    int IServiceBase.Price
    {
        get => Price ?? 0;
        set => Price = value;
    }
}
```


### UpdateStateRequest
[back up](#contents)
```csharp
public class UpdateStateRequest : UpdateRequest, IState
{
    [AllowNull]
    public string Name { get; set; } = null;
}
```


### UpdateUserRequest
[back up](#contents)
```csharp
public class UpdateUserRequest : UpdateRequest, IUser
{
    public RoleNames? Role { get; set; } = null;

    [AllowNull]
    public string Username { get; set; } = null;

    public bool? Locked { get; set; } = null;

    // Implemented properties but with allowed null values

    bool IUserBase.Locked
    {
        get => Locked ?? false;
        set => Locked = value;
    }

    RoleNames IUserBase.Role
    {
        get => Role ?? RoleNames.User;
        set => Role = value;
    }

    // Hidden properties since they are not allowed to be updated

    int IUserBase.LoginAttempts { get; set; }
    string? IUserBase.RefreshToken { get; set; }
    [AllowNull]
    byte[] IUserBase.PasswordHash { get; set; }
    [AllowNull]
    byte[] IUserBase.PasswordSalt { get; set; }
}
```


### Base

#### CreateRequest
[back up](#contents)
```csharp
public class CreateRequest : IModel, ICreateDTO
{
    // Hidden properties since they are not allowed to be set when creating
    bool IModelBase.IsDeleted { get; set; }
    int IModel.Id { get; set; }
}
```


#### UpdateRequest
[back up](#contents)
```csharp
public class UpdateRequest : IModel, IUpdateDTO
{
    [JsonProperty("is_deleted")]
    public bool? IsDeleted { get; set; } = null;

    // Implemented properties but with allowed null values

    bool IModelBase.IsDeleted
    {
        get => IsDeleted ?? false;
        set => IsDeleted = value;
    }

    // Hidden properties since they are not allowed to be updated

    int IModel.Id { get; set; }
}
```


## DTOs/Responses

### LoginResponse
[back up](#contents)
```csharp
public class LoginResponse : UserResponse
{
    public required TokenData Auth { get; set; }
}
```


### OrderResponse
[back up](#contents)
```csharp
public class OrderResponse : ModelResponse, IOrder, IResponseDTO
{
    public UserResponse? User { get; set; }

    [AllowNull, NotNull]
    public ServiceResponse Service { get; set; }

    [AllowNull, NotNull]
    public StateResponse State { get; set; }

    [AllowNull, NotNull]
    public PriorityResponse Priority { get; set; }

    public DateTime Created { get; set; }

    [AllowNull, NotNull]
    public string Email { get; set; }
    [AllowNull, NotNull]
    public string Name { get; set; }
    public string? Note { get; set; }
    [AllowNull, NotNull]
    public string Phone { get; set; }

    IState IOrder.State
    {
        get => State;
        set => State = (value as StateResponse)!;
    }
    IPriority IOrder.Priority
    {
        get => Priority;
        set => Priority = (value as PriorityResponse)!;
    }
    IService IOrder.Service
    {
        get => Service;
        set => Service = (value as ServiceResponse)!;
    }
    IUser? IOrder.User
    {
        get => User;
        set => User = value as UserResponse;
    }

    int IOrder.PriorityId
    {
        get => Priority.Id;
        set => Priority.Id = value;
    }
    int IOrder.ServiceId
    {
        get => Service.Id;
        set => Service.Id = value;
    }
    int IOrder.StateId
    {
        get => State.Id;
        set => State.Id = value;
    }
    int? IOrder.UserId
    {
        get => User == null ? null : User.Id;
        set
        {
            if (User != null && value != null)
                User.Id = value ?? 0;
        }
    }

}
```


### PriorityResponse
[back up](#contents)
```csharp
public class PriorityResponse : ModelResponse, IPriority, IResponseDTO
{
    [AllowNull, NotNull]
    public string Name { get; set; }
    public int Days { get; set; }
}
```


### ServiceResponse
[back up](#contents)
```csharp
public class ServiceResponse : ModelResponse, IService, IResponseDTO
{
    [AllowNull, NotNull]
    public string Description { get; set; }
    [AllowNull, NotNull]
    public string Name { get; set; }
    public int Price { get; set; }
}
```


### StateResponse
[back up](#contents)
```csharp
public class StateResponse : ModelResponse, IState, IResponseDTO
{
    [AllowNull, NotNull]
    public string Name { get; set; }
}
```


### UserResponse
[back up](#contents)
```csharp
public class UserResponse : ModelResponse, IUser, IResponseDTO
{
    [AllowNull, NotNull]
    public string Username { get; set; }
    public bool? Locked { get; set; }
    public string? Role { get; set; }

    // Specially implemented properties to allow for null values and parsing

    bool IUserBase.Locked
    {
        get => Locked ?? false;
        set => Locked = value;
    }

    RoleNames IUserBase.Role
    {
        get => Role == null ? RoleNames.User : (RoleNames)Enum.Parse(typeof(RoleNames), Role);
        set => Role = value.ToString();
    }

    // Hidden properties since they are not allowed to be displayed

    [AllowNull]
    byte[] IUserBase.PasswordHash { get; set; }
    [AllowNull]
    byte[] IUserBase.PasswordSalt { get; set; }
    string? IUserBase.RefreshToken { get; set; }
    int IUserBase.LoginAttempts { get; set; }
}
```


### Base

#### ModelResponse
[back up](#contents)
```csharp

```


## Interfaces

### IOrder
[back up](#contents)
```csharp
public interface IOrder : IModel, IOrderBase
{
    // Foreign keys
    int ServiceId { get; set; }
    int PriorityId { get; set; }
    int StateId { get; set; }
    int? UserId { get; set; }

    // Navigation properties
    IUser? User { get; set; }
    IService Service { get; set; }
    IPriority Priority { get; set; }
    IState State { get; set; }
}
```


### IPriority
[back up](#contents)
```csharp
public interface IPriority : IModel, IPriorityBase
{
}
```


### IService
[back up](#contents)
```csharp
public interface IService : IModel, IServiceBase
{
}
```


### IState
[back up](#contents)
```csharp
public interface IState : IModel, IStateBase
{
}
```


### IUser
[back up](#contents)
```csharp
public interface IUser : IModel, IUserBase
{
}
```


### Base

#### IModel
[back up](#contents)
```csharp
public interface IModel : IModelBase
{
    int Id { get; set; }
}
```


## Models

### Order
[back up](#contents)
```csharp
public class Order : Model, IOrder
{
    // Foreign keys
    public int ServiceId { get; set; }
    public int PriorityId { get; set; }
    public int StateId { get; set; }
    public int? UserId { get; set; } = null;

    // Navigation properties
    public virtual User? User { get; set; }
    [AllowNull, NotNull]
    public virtual Service Service { get; set; }
    [AllowNull, NotNull]
    public virtual Priority Priority { get; set; }
    [AllowNull, NotNull]
    public virtual State State { get; set; }

    public DateTime Created { get; set; }

    [StringLength(50)]
    [AllowNull, NotNull]
    public string Email { get; set; }

    [StringLength(50)]
    [AllowNull, NotNull]
    public string Name { get; set; }

    [StringLength(50)]
    [AllowNull, NotNull]
    public string Phone { get; set; }

    [StringLength(1000)]
    public string? Note { get; set; }

    IUser? IOrder.User { 
        get => User; 
        set => User = value as User; }
    IService IOrder.Service { 
        get => Service; 
        set => Service = (value as Service)!;
    }
    IPriority IOrder.Priority { 
        get => Priority; 
        set => Priority = (value as Priority)!; 
    }
    IState IOrder.State { 
        get => State; 
        set => State = (value as State)!; 
    }
}
```


### Priority
[back up](#contents)
```csharp
public class Priority : Model, IPriority
{
    public int Days { get; set; }

    [StringLength(20)]
    public required string Name { get; set; }
}
```


### Service
[back up](#contents)
```csharp
public class Service : Model, IService
{
    [StringLength(1000)]
    public required string Description { get; set; }

    [StringLength(50)]
    public required string Name { get; set; }

    public int Price { get; set; }
}
```


### State
[back up](#contents)
```csharp
public class State : Model, IState
{
    [StringLength(20)]
    public required string Name { get; set; }
}
```


### User
[back up](#contents)
```csharp
public class User : Model, IUser
{

    [StringLength(50)]
    [AllowNull, NotNull]
    public string Username { get; set; }
    public int LoginAttempts { get; set; } = 0;
    [AllowNull, NotNull]
    public byte[] PasswordHash { get; set; }
    [AllowNull, NotNull]
    public byte[] PasswordSalt { get; set; }
    public string? RefreshToken { get; set; } = null;
    [OwnerOrAdminOnly]
    public RoleNames Role { get; set; } = RoleNames.User;
    [AdminOnly]
    public bool Locked { get; set; } = false;
}
```


### Refresh Result
[back up](#contents)
```csharp
public class RefreshResult : IRefreshRequest<User>
{
    [AllowNull, NotNull]
    public User User { get; set; }
    [AllowNull, NotNull]
    public TokenData TokenData { get; set; }
}
```


### Base

#### Model
[back up](#contents)
```csharp
public class Model : IModel
{
    [Key]
    public int Id { get; set; }

    [AdminOnly]
    public bool IsDeleted { get; set; }
}
```

