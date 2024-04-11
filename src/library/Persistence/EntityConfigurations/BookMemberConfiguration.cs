using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BookMemberConfiguration : IEntityTypeConfiguration<BookMember>
{
    public void Configure(EntityTypeBuilder<BookMember> builder)
    {
        builder.ToTable("BookMembers").HasKey(bm => bm.Id);

        builder.Property(bm => bm.Id).HasColumnName("Id").IsRequired();
        builder.Property(bm => bm.BookId).HasColumnName("BookId");
        builder.Property(bm => bm.MemberId).HasColumnName("MemberId");
        builder.Property(bm => bm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bm => bm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bm => bm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bm => !bm.DeletedDate.HasValue);
    }
}