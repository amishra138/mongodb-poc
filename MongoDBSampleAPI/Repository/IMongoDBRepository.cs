﻿using System.Collections.Generic;

namespace MongoDBSampleAPI.Repository
{
    public interface IMongoDBRepository
    {
        IEnumerable<object> GetAll();

        bool Insert(string item);
    }
}
