﻿using SkiServiceModels.Interfaces.Base;

namespace SkiServiceModels.Interfaces.Models
{
    public interface IStateBase : IModelBase
    {
        string Name { get; set; }
    }
}