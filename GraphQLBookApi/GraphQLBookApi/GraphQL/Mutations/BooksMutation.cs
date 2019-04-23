using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLBookApi.Repository;
using GraphQLBookApi.DAO;

using GraphQLBookApi.GraphQL.Types;  

namespace GraphQLBookApi.GraphQL.Mutations
{
    public class BooksMutation : ObjectGraphType
    {
        public BooksMutation(BookRepository bookRepository)
        {
            Name = "mutation";
            Field<BookType>("createBook"
                , arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" })
                , resolve: context =>
                {
                    var book = context.GetArgument<Book>("book");
                    return bookRepository.AddBook(book);
                });
        }
    }
}
