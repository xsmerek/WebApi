// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.AspNet.OData.Query
{
    /// <summary>
    /// This defines a custom distinct OData query option.
    /// </summary>
    public class DistinctQueryOption
    {

        /// <summary>
        /// Apply the custom distinct query to the given IQueryable.
        /// </summary>
        /// <param name="query">The original <see cref="IQueryable"/>.</param>
        /// <returns>The new <see cref="IQueryable"/> after the distinct query has been applied to.</returns>
        public IQueryable ApplyTo(IQueryable query)
        {
            Expression source = query.Expression;
            Type elementType = query.ElementType;

            MethodInfo distinctMethod;
            if (typeof(IQueryable).IsAssignableFrom(source.Type))
            {
                distinctMethod = ExpressionHelperMethods.QueryableDistinct.MakeGenericMethod(elementType);
            }
            else
            {
                distinctMethod = ExpressionHelperMethods.EnumerableDistinct.MakeGenericMethod(elementType);
            }

            Expression distinctQuery = Expression.Call(null, distinctMethod, new[] { source });

            MethodInfo genericDistinctMethod = ExpressionHelperMethods.CreateQueryGeneric.MakeGenericMethod(elementType);

            return genericDistinctMethod.Invoke(query.Provider, new[] { distinctQuery }) as IQueryable;
        }
    }
}
