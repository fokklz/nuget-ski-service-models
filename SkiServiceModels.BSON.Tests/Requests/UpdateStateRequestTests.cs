﻿
using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Models;

namespace SkiServiceModels.BSON.Tests.Requests
{
    public class UpdateStateRequestTests
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

            var parsed = JsonConvert.DeserializeObject<UpdateStateRequest>(requestJson);
            var response = _mapper.Map<State>(parsed);

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.False(response.IsDeleted);
        }

        [Fact]
        public void ParseToState_IgnoresIdAndIncludesIsDeleted_ForAdmins()
        {
            var requestJson = @"{
                ""id"": ""5f9d7a9d9d9d9d9d9d9d9d9"",
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<UpdateStateRequest>(requestJson);
            var response = _mapper.Map<State>(parsed, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(response.Id, ObjectId.Empty);
            Assert.True(response.IsDeleted);
        }

        [Fact]
        public void MapToState_IncludeAllProperties_ForNoneAdmins()
        {
            var request = new UpdateStateRequest
            {
                IsDeleted = true,
                Name = "Test"
            };

            var mapped = _mapper.Map<State>(request);

            Assert.Equal(mapped.Name, request.Name);
            Assert.NotEqual(mapped.IsDeleted, request.IsDeleted);
        }

        [Fact]
        public void MapToState_IncludeAllProperties_ForAdmins()
        {
            var request = new UpdateStateRequest
            {
                IsDeleted = true,
                Name = "Test"
            };

            var mapped = _mapper.Map<State>(request, opts =>
            {
                opts.Items["IsAdmin"] = true;
            });

            Assert.Equal(mapped.Name, request.Name);
            Assert.Equal(mapped.IsDeleted, request.IsDeleted);
        }
    }
}
