using GraphQLBookApi.DAO;
using GraphQL;
using GraphQL.Types; 

namespace GraphQLBookApi.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(f => f.Id).Name("id");
            Field(f => f.Name).Name("name");
        }

    }
}
