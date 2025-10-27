using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implementation of the unit of work pattern using Entity Framework Core.
/// </summary>
/// <param name="context">The database context.</param>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    /// <summary>
    /// Asynchronously completes the unit of work, committing all changes made within the transaction.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}