﻿using Newtonsoft.Json;
using SkiServiceModels.Attributes;
using SkiServiceModels.BSON.DTOs.Response.Base;
using SkiServiceModels.BSON.Interfaces;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces;
using SkiServiceModels.Interfaces.Models;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceModels.BSON.DTOs.Response
{
    public class UserResponse : ModelResponse, IUser, IResponseDTO
    {
        [AllowNull, NotNull]
        public string Username { get; set; }

        // Specially implemented properties to allow for null values and parsing

        [AdminOnly]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Locked { get; set; } = null;

        bool IUserBase.Locked
        {
            get => Locked ?? false;
            set => Locked = value;
        }

        [OwnerOrAdminOnly]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Role { get; set; }
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
}