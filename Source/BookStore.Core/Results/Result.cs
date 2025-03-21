namespace BookStore.Core.Results
{
    public class Result
    {
        public IEnumerable<Error>? Errors { get; init; }
        public bool IsSuccess { get; init; }

        private Result(IEnumerable<Error>? errors = default, bool isSuccess = false)
        {
            Errors = errors ?? Enumerable.Empty<Error>();
            IsSuccess = isSuccess;
        }

        public static Result Success()
        {
            return new Result(isSuccess: true);
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return new Result<TValue>(isSuccess: true, value: value);
        }

        public static Result Failure(IEnumerable<Error> errors)
        {
            return new Result(errors, isSuccess: false);
        }

        public static Result Failure(params Error[] errors)
        {
            return new Result(errors, isSuccess: false);
        }

        public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors, TValue value = default)
        {
            return new Result<TValue>(errors, isSuccess: false, value);
        }
        
        public static Result<TValue> Failure<TValue>(params Error[] errors)
        {
            return new Result<TValue>(errors, isSuccess: false);
        }

        public static Result Failure(Result failure)
        {
            if (failure.IsSuccess)
            {
                throw new InvalidOperationException("Cannot convert Result type Success to Failure.");
            }
            return new Result
            {
                Errors = failure.Errors,
                IsSuccess = failure.IsSuccess
            };
        }       

        public static Result<TValue> Failure<TValue>(Result<TValue> error)
        {
            if (error.IsSuccess)
            {
                throw new InvalidOperationException("Cannot convert Result type Success to Error.");
            }
            return new Result<TValue>
            {
                Errors = error.Errors,
                IsSuccess = error.IsSuccess
            };
        }
    }

    public class Result<TValue>
    {
        public IEnumerable<Error> Errors { get; init; }
        public bool IsSuccess { get; init; }
        public TValue? Value { get; init; }

        internal Result(IEnumerable<Error>? errors = default, bool isSuccess = false, TValue? value = default)
        {
            Errors = errors ?? [];
            IsSuccess = isSuccess;
            Value = value;
        }
    }
}
