namespace Visit.Contracts;

public class ApiResponse<T> : ApiResponse where T : class
{
    public T Result { get; set; }
}

public class ApiResponse
{
    public bool Success { get; set; }

    public string Error { get; set; }

    public int ErrorCode { get; set; }

    public static ApiResponse CreateSuccess() => new()
    {
        Success = true
    };
    
    public static ApiResponse<TResult> CreateSuccess<TResult>(TResult result) where TResult : class
    {
        var success = new ApiResponse<TResult>
        {
            Result = result,
            Success = true
        };
        return success;
    }
    
    public static ApiResponse<TResult> CreateFailure<TResult>(int errorCode = 400, string error = null) where TResult : class
    {
        var failure = new ApiResponse<TResult>
        {
            Success = false,
            ErrorCode = errorCode,
            Error = error,
        };
        return failure;
    }

    public static ApiResponse CreateFailure(int errorCode = 400, string error = null) => new()
    {
        Success = false,
        ErrorCode = errorCode,
        Error = error,
    };
}