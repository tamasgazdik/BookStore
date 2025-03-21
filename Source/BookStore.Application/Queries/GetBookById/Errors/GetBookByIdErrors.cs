namespace BookStore.Application.Queries.GetBookById.Errors
{
    public static class GetBookByIdErrors
    {
        public static readonly string EmptyId = $"{nameof(GetBookByIdErrors)}.{nameof(EmptyId)}";
        public static readonly string NotFound = $"{nameof(GetBookByIdErrors)}.{nameof(NotFound)}";
    }
}
