# SkiServiceModels

This is a collection of models used by the SkiService project. It is divided into multiple modules for easier management.

[`SkiServiceModels.EF`](../SkiServiceModels.EF) for a Entity Framework Core implementation of the models, 
see [`SkiServiceModels.BSON`](../SkiServiceModels.BSON) for a MongoDB implementation of the models.

This project contains everything not related to a specific database implementation. And is not meant to be used on its own.


## Contents

<!--TOC-->
  - [DTOs](#dtos)
    - [ErrorData](#errordata)
    - [TokenData](#tokendata)
  - [DTOs/Requests](#dtosrequests)
    - [LoginRequest](#loginrequest)
    - [RefreshRequest](#refreshrequest)
  - [Enums](#enums)
    - [RoleNames](#rolenames)
  - [Interfaces](#interfaces)
    - [IAuthRequest](#iauthrequest)
    - [ICreateDTO](#icreatedto)
    - [IDTO](#idto)
    - [IRequestDTO](#irequestdto)
    - [IRequestDTO](#irequestdto)
    - [IUpdateDTO](#iupdatedto)
    - [Base](#base)
      - [IModelBase](#imodelbase)
    - [Models](#models)
      - [IOrderBase](#iorderbase)
      - [IPriorityBase](#iprioritybase)
      - [IServiceBase](#iservicebase)
      - [IStateBase](#istatebase)
      - [IUserBase](#iuserbase)
<!--/TOC-->

## DTOs

### ErrorData
[back up](#contents)
```csharp
public class ErrorData : IDTO
{
    public required string Code { get; set; }

    public required string Message { get; set; }
}
```


### TokenData
[back up](#contents)
```csharp
public class TokenData : IDTO
{
    public required string Token { get; set; }
    public string? RefreshToken { get; set; }
    public string TokenType { get; set; } = "Bearer";
    public DateTime Issued { get; set; } = DateTime.UtcNow;
    public DateTime Expires { get; set; }
}
```


## DTOs/Requests

### LoginRequest
[back up](#contents)
```csharp
public class LoginRequest : IAuthRequest
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    public bool RememberMe { get; set; } = false;
}
```


### RefreshRequest
[back up](#contents)
```csharp
public class RefreshRequest : IAuthRequest
{
    [Required]
    public required string Token { get; set; }

    [Required]
    public required string RefreshToken { get; set; }
}
```


## Enums

### RoleNames
[back up](#contents)
```csharp
public enum RoleNames
{
    User,
    SuperAdmin
}
```


## Interfaces

### IAuthRequest
[back up](#contents)
```csharp
public interface IAuthRequest
{
}
```


### ICreateDTO
[back up](#contents)
```csharp
public interface ICreateDTO : IRequestDTO
{
}
```


### IDTO
[back up](#contents)
```csharp
public interface IDTO
{
}
```


### IRequestDTO
[back up](#contents)
```csharp
public interface IRequestDTO : IDTO
{
}
```


### IRequestDTO
[back up](#contents)
```csharp
public interface IRequestDTO : IDTO
{
}
```


### IUpdateDTO
[back up](#contents)
```csharp
public interface IUpdateDTO : IRequestDTO
{
}
```


### Base

#### IModelBase
[back up](#contents)
```csharp
public interface IModelBase
{
    bool IsDeleted { get; set; }
}
```


### Models

#### IOrderBase
[back up](#contents)
```csharp
public interface IOrderBase : IModelBase
{
    DateTime Created { get; set; }
    string Email { get; set; }
    string Name { get; set; }
    string? Note { get; set; }
    string Phone { get; set; }
}
```


#### IPriorityBase
[back up](#contents)
```csharp
public interface IPriorityBase : IModelBase
{
    int Days { get; set; }
    string Name { get; set; }
}
```


#### IServiceBase
[back up](#contents)
```csharp
public interface IServiceBase : IModelBase
{
    string Description { get; set; }
    string Name { get; set; }
    int Price { get; set; }
}
```


#### IStateBase
[back up](#contents)
```csharp
public interface IStateBase : IModelBase
{
    string Name { get; set; }
}
```


#### IUserBase
[back up](#contents)
```csharp
public interface IUserBase : IModelBase
{
    bool Locked { get; set; }
    int LoginAttempts { get; set; }
    byte[] PasswordHash { get; set; }
    byte[] PasswordSalt { get; set; }
    string? RefreshToken { get; set; }
    RoleNames Role { get; set; }
    string Username { get; set; }
}
```

