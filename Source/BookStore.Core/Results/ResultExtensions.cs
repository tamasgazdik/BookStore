namespace BookStore.Core.Results
{
    public static class ResultExtensions
    {
        public static TOut Match<TResult, TOut>(
            this Result<TResult?> result,
            Func<Result<TResult?>, TOut> success,
            Func<Result<TResult?>, TOut> failure)
        {
            if (result.IsSuccess)
            {
                return success(result);
            }
            else
            {
                return failure(result);
            }
        }
    }
}
