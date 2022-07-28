using FluentValidation;

namespace AlphaCentauri.Model;

public static class Validators
{
    public static IRuleBuilderOptions<T, DateTime> Birthday<T>(this IRuleBuilder<T, DateTime> builder)
    {
        return builder.LessThan(DateTime.UtcNow);
    }
}
