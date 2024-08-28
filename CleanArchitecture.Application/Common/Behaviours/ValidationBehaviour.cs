using System.Collections;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Application.Common.Behaviours;
public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    // Doğrulayıcıları dependency injection yoluyla al

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Doğrulayıcı yoksa sonraki işleme geç
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        // Tüm doğrulayıcıları paralel olarak çalıştır
        var validationTasks = validators.Select(v => v.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);

        // Hataları topla
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToArray();

        // Hata varsa exception fırlat
        if (failures.Any())
            throw new ValidationException(failures);

        // Hata yoksa sonraki işleme geç
        return await next();
    }
}
