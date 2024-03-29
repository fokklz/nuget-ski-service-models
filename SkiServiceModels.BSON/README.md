# SkiServiceModels.BSON

This package contains the BSON models for the SkiService project.

## Installation

```bash
dotnet add package SkiServiceModels.BSON
```

## Contents

<!--TOC-->
- [SkiServiceModels.BSON](#skiservicemodelsbson)
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
    public required string PriorityId { get; set; }

    [JsonProperty("service_id")]
    public required string ServiceId { get; set; }

    [JsonProperty("state_id")]
    public required string StateId { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    ObjectId IOrder.PriorityId
    {
        get => ObjectId.Parse(PriorityId);
        set => PriorityId = value.ToString();
    }
    ObjectId IOrder.ServiceId
    {
        get => ObjectId.Parse(ServiceId);
        set => ServiceId = value.ToString();
    }
    ObjectId IOrder.StateId
    {
        get => ObjectId.Parse(StateId);
        set => StateId = value.ToString();
    }
    ObjectId? IOrder.UserId
    {
        get => ObjectId.Parse(UserId);
        set => UserId = value?.ToString();
    }

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
    public RoleNames Role { get; set; }

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
    public string? PriorityId { get; set; } = null;

    [JsonProperty("service_id")]
    public string? ServiceId { get; set; } = null;

    [JsonProperty("state_id")]
    public string? StateId { get; set; } = null;

    [JsonProperty("user_id")]
    public string? UserId { get; set; } = null;

    ObjectId IOrder.PriorityId
    {
        get => ObjectId.Parse(PriorityId);
        set => PriorityId = value.ToString();
    }
    ObjectId IOrder.ServiceId
    {
        get => ObjectId.Parse(ServiceId);
        set => ServiceId = value.ToString();
    }
    ObjectId IOrder.StateId
    {
        get => ObjectId.Parse(StateId);
        set => StateId = value.ToString();
    }
    ObjectId? IOrder.UserId
    {
        get => ObjectId.Parse(UserId);
        set => UserId = value?.ToString();
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
    ObjectId IModel.Id { get; set; }
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

    ObjectId IModel.Id { get; set; }
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

    ObjectId IOrder.PriorityId
    {
        get => ObjectId.Parse(Priority.Id);
        set => Priority.Id = value.ToString();
    }
    ObjectId IOrder.ServiceId
    {
        get => ObjectId.Parse(Service.Id);
        set => Service.Id = value.ToString();
    }
    ObjectId IOrder.StateId
    {
        get => ObjectId.Parse(State.Id);
        set => State.Id = value.ToString();
    }
    ObjectId? IOrder.UserId
    {
        get => User == null ? null : ObjectId.Parse(User.Id);
        set
        {
            if (User != null && value != null)
                User.Id = value.ToString()!;
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
    ObjectId PriorityId { get; set; }
    ObjectId ServiceId { get; set; }
    ObjectId StateId { get; set; }
    ObjectId? UserId { get; set; }

    IUser? User { get; set; }
    IState State { get; set; }
    IPriority Priority { get; set; }
    IService Service { get; set; }

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
    ObjectId Id { get; set; }
}
```


## Models

### Order
[back up](#contents)
```csharp
public class Order : Model, IOrder
{
    [BsonElement("name")]
    [AllowNull, NotNull]
    public string Name { get; set; }

    [BsonElement("email")]
    [AllowNull, NotNull]
    public string Email { get; set; }

    [BsonElement("phone")]
    [AllowNull, NotNull]
    public string Phone { get; set; }

    [BsonElement("priority_id")]
    public ObjectId PriorityId { get; set; }

    [BsonElement("service_id")]
    public ObjectId ServiceId { get; set; }

    [BsonElement("state_id")]
    public ObjectId StateId { get; set; }

    [BsonElement("user_id")]
    public ObjectId? UserId { get; set; } = null;

    [BsonElement("priority")]
    [AllowNull, NotNull]
    public virtual IPriority Priority { get; set; }
    public bool ShouldSerializePriority() => false;

    [BsonElement("service")]
    [AllowNull, NotNull]
    public virtual IService Service { get; set; }
    public bool ShouldSerializeService() => false;

    [BsonElement("state")]
    [AllowNull, NotNull]
    public virtual IState State { get; set; }
    public bool ShouldSerializeState() => false;

    [BsonElement("user")]
    public virtual IUser? User { get; set; }
    public bool ShouldSerializeUser() => false;

    [BsonElement("created")]
    public DateTime Created { get; set; } = DateTime.Now;

    [BsonElement("note")]
    public string? Note { get; set; }
}
```


### Priority
[back up](#contents)
```csharp
public class Priority : Model, IPriority
{
    [BsonElement("days")]
    public int Days { get; set; }

    [BsonElement("name")]
    [AllowNull, NotNull]
    public string Name { get; set; }
}
```


### Service
[back up](#contents)
```csharp
public class Service : Model, IService
{
    [BsonElement("description")]
    [AllowNull, NotNull]
    public string Description { get; set; }

    [BsonElement("name")]
    [AllowNull, NotNull]
    public string Name { get; set; }

    [BsonElement("price")]
    public int Price { get; set; }
}
```


### State
[back up](#contents)
```csharp
public class State : Model, IState
{
    [BsonElement("name")]
    [AllowNull, NotNull]
    public string Name { get; set; }
}
```


### User
[back up](#contents)
```csharp
public class User : Model, IUser
{

    [BsonElement("username")]
    [AllowNull, NotNull]
    public string Username { get; set; }

    [BsonElement("password_hash")]
    [AllowNull, NotNull]
    public byte[] PasswordHash { get; set; }

    [BsonElement("password_salt")]
    [AllowNull, NotNull]
    public byte[] PasswordSalt { get; set; }

    [BsonElement("locked")]
    [AdminOnly]
    public bool Locked { get; set; } = false;

    [BsonElement("role")]
    [BsonRepresentation(BsonType.String)]
    [OwnerOrAdminOnly]
    public RoleNames Role { get; set; } = RoleNames.User;

    [BsonElement("login_attempts")]
    public int LoginAttempts { get; set; } = 0;

    [BsonElement("refresh_token")]
    public string? RefreshToken { get; set; } = null;
}
```


### Refresh Result
[back up](#contents)
```csharp
public class RefreshResult : IRefreshRequest<User>
{
    public required User User { get; set; }
    public required TokenData TokenData { get; set; }
}
```


### Base

#### Model
[back up](#contents)
```csharp
public class Model : IModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("is_deleted")]
    [AdminOnly]
    public bool IsDeleted { get; set; } = false;
}
```

