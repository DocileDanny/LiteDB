﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LiteDB
{
    public partial class LiteEngine
    {
        /// <summary>
        /// Return new QueryBuilder to run search over collection
        /// </summary>
        public QueryBuilder Query(string collection)
        {
            if (string.IsNullOrWhiteSpace(collection)) throw new ArgumentNullException(nameof(collection));

            // test if is an virtual collection
            if (collection.StartsWith("$") && _virtualCollections.TryGetValue(collection, out var factory))
            {
                return new QueryBuilder(collection, this, factory());
            }

            return new QueryBuilder(collection, this);
        }
    }
}