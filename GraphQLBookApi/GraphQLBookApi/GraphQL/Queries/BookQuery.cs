using System;
using GraphQL;
using GraphQL.Types; 

using GraphQLBookApi.DAO;
using GraphQLBookApi.GraphQL.Types;
using System.Collections.Generic;
using GraphQLBookApi.Repository;
using System.Linq;  


namespace GraphQLBookApi.GraphQL.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(BookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>("books", resolve: context =>
            {
                return bookRepository.GetAll();
            });

            Field<BookType>("book"
                , arguments: GetArguments()
                , resolve: context =>
            {
                return bookRepository.GetById(context.GetArgument<int>("id"));
            });
        }

        private QueryArguments GetArguments()
        {
            var arguments = new QueryArguments();
            arguments.Add(new QueryArgument<IdGraphType>
            {
                Name = "id"
            });
            return arguments;  
        }
    }
}
