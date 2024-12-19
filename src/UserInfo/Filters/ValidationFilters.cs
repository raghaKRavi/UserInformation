using FluentValidation;

namespace UserInfo.Filters;

public class ValidationFilters<TRequest>(IValidator<TRequest> validator) : IEndpointFilter
{
    private readonly IValidator<TRequest> _validator = validator;
    
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        //var request = context.Arguments.OfType<TRequest>(0);
        var request = context.GetArgument<TRequest>(0);

        var result = await validator.ValidateAsync(request, context.HttpContext.RequestAborted);

        if (!result.IsValid)
        {
            return TypedResults.ValidationProblem(result.ToDictionary());
        }

        return await next(context);
    }
}