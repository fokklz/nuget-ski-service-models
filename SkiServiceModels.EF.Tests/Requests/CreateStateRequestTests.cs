﻿using SkiServiceModels.EF.DTOs.Requests;
using SkiServiceModels.EF.Models;

namespace SkiServiceModels.EF.Tests.Requests
{
    public class CreateStateRequestTests
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();

        [Fact]
        public void ParseToState_IgnoresIdAndIsDeleted_ForNoneAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateStateRequest>(requestJson);
            var response = _mapper.Map<State>(parsed);

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToState_IgnoresIdAndIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": 1,
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<CreateStateRequest>(requestJson);
            var response = _mapper.Map<State>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.NotEqual(1, response.Id);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void MapToState_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new CreateStateRequest
            {
                Name = "Test"
            };

            var mapped = _mapper.Map<State>(request);

            Assert.Equal(mapped.Name, request.Name);
        }

        [Fact]
        public void MapToState_IncludeAllProperties_ForAdmins()
        {
            var request = new CreateStateRequest
            {
                Name = "Test"
            };

            var mapped = _mapper.Map<State>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Name, request.Name);
        }
    }
}
