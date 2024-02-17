using Bigon.Application.Repositories;
using Bigon.Domain.Models.Dtos;
using Bigon.Domain.Models.Entities;
using Bigon.Domain.Models.Stables;
using Bigon.Infrastructure.Constracts;
using Bigon.Infrastructure.Extensions;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class CategoryRepository : AsyncRepository<Category>, ICatagoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<RelatedCategoryIds>> GetRelatedIds(int id)
        {
            var parameters = new DynamicParameters();
             parameters.Add("@id", id);
            return await db.QueryAsync<RelatedCategoryIds>("dbo.spGetRelatedIds", parameters);
        }

        public async Task<IEnumerable<Category>> GetSafeCategories(int id,CategoryType type)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@type", (int)type);
            return await db.QueryAsync<Category>("[dbo].[spGetAllSafeCategories]", parameters);
        }
    }
}
    