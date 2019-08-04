namespace AuthorUser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appclaim1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AppClaims", name: "ChildAppClaimId", newName: "SubClaimId");
            RenameIndex(table: "dbo.AppClaims", name: "IX_ChildAppClaimId", newName: "IX_SubClaimId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AppClaims", name: "IX_SubClaimId", newName: "IX_ChildAppClaimId");
            RenameColumn(table: "dbo.AppClaims", name: "SubClaimId", newName: "ChildAppClaimId");
        }
    }
}
