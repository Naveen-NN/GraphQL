using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using GraphQL;
using GraphQL.Types;
using GraphQLBookApi.GraphQL.Queries;
using GraphQLBookApi.GraphQL.Mutations;  

namespace GraphQLBookApi.GraphQL.Schemas
{
    public class BookSchema : Schema
    {
        public BookSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
            Mutation = resolver.Resolve<BooksMutation>();
        }
    }
}
