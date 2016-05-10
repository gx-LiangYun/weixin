namespace LY.WeiXin.EFDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSysConfigItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysConfigItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        ItemValue = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysConfigItem");
        }
    }
}
