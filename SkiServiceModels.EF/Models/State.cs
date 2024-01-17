﻿using SkiServiceModels.EF.Interfaces;
using SkiServiceModels.EF.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SkiServiceModels.EF.Models
{
    public class State : Model, IState
    {
        [StringLength(20)]
        public string Name { get; set; }
    }
}