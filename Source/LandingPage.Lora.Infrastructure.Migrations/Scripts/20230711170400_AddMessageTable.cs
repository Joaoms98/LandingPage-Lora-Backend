using FluentMigrator;

namespace LandingPage.Lora.Infrastructure.Migrations.Scripts;

[Migration(20221031153152000)]
public class AddMessageTable : Migration
{
    public const string TableName = "Message";

    public override void Up()
    {
        Create.Table(TableName)
            .WithColumn("Id")
                .AsGuid()
                .PrimaryKey()
            .WithColumn("PersonId")
                .AsGuid()
                .ForeignKey("Person" , "Id")
            .WithColumn("Content")
                .AsString(1024)
                .NotNullable()
            .WithColumn("CreatedAt")
                .AsDateTime()
                .NotNullable();
    }

    public override void Down()
    {
        Delete.Table(TableName);
    }
}