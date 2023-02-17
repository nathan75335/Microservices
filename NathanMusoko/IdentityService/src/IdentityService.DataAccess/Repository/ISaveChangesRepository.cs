namespace IdentityService.DataAccess.Repository
{
    /// <summary>
    /// Repository for saving the changes 
    /// </summary>
    public interface ISaveChangesRepository
    {
        /// <summary>
        /// Function to save changes to the database
        /// </summary>
        /// <param name="token">The cancellation token</param>
        /// <returns>A <see cref="Task"/></returns>
        Task SaveChangesAsync(CancellationToken token);
    }
}