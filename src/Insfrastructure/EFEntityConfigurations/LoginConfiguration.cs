using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.EFEntityConfigurations;
public class LoginConfiguration : IEntityTypeConfiguration<LoginModel>
{
    public void Configure(EntityTypeBuilder<LoginModel> builder)
    {
        builder.ToCollection("logins");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasBsonRepresentation(MongoDB.Bson.BsonType.String);
        builder.Property(x => x.Password).HasBsonRepresentation(MongoDB.Bson.BsonType.String);
    }
}
