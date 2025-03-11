using LMS.Domain.Entities;
using LMS.Infrastructure.Persistence;

namespace LMS.Infrastructure.Seeders
{
    public interface ILMSSeeder
    {
       
        Task Seed(LMSDBContext dbContext);
    }
}