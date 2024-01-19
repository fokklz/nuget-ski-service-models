﻿using MongoDB.Bson;
using SkiServiceModels.BSON.DTOs.Request.Base;
using SkiServiceModels.BSON.Interfaces;

namespace SkiServiceModels.BSON.Tests.Requests.Base
{
    public class UpdateRequestTests
    {
        [Fact]
        public void ParseAlwaysIgnoresIdAndIncludesIsDeleted()
        {
            var rawJson = @"
            {
                ""id"": ""5f7b1c3b9b3b2d0d9c9f1b1a"",
                ""is_deleted"": true,
                ""name"": ""Test""
            }";

            var parsed = JsonConvert.DeserializeObject<UpdateRequest>(rawJson);

            Assert.Equal((parsed as IModel)?.Id, ObjectId.Empty);
            Assert.True((parsed as IModel)?.IsDeleted);
        }
    }
}