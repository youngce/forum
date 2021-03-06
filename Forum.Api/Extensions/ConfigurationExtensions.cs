﻿using ENode;
using Forum.Domain.Accounts;
using Forum.Domain.Repositories.MongoDB;

namespace Forum.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static Configuration MongoAccountRegistrationInfoRepository(this Configuration configuration, string connectionString, string accountCollectionName)
        {
            configuration.SetDefault<IAccountRegistrationInfoRepository, AccountRegistrationInfoRepository>(
                new AccountRegistrationInfoRepository(connectionString, accountCollectionName));
            return configuration;
        }
    }
}