using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class spGetRealtedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure dbo.spGetRealtedIds
                                        @id int 
                                        as 
                                        begin 
                                        set nocount on;

                                        ;with cte as(
                                        select Id,[ParentId],[Name] from [dbo].[Categories]
                                        where Id=@id
                                        union ALL
                                        select c.Id, c.[ParentId], c.[Name]
                                        from [dbo].[Categories] c
                                        join cte p on p.Id=c.ParentId
                                        )

                                        select Id from cte;
                                        end "
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.spGetRealtedIds");
        }
    }
}
