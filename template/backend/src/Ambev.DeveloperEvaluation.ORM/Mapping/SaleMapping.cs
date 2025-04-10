using Ambev.DeveloperEvaluation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sales");

            builder.HasKey(x => x.SaleId);
            
            builder.Property(x => x.SaleId)
                .HasColumnName("sale_id")
                .UseIdentityColumn();

            builder.Property(x => x.SaleDate)
                .HasColumnName("sale_date")
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(x => x.CustomerName)
                .HasColumnName("customer_name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.BranchId)
                .HasColumnName("branch_id")
                .IsRequired();

            builder.Property(x => x.BranchName)
                .HasColumnName("branch_name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.IsCancelled)
                .HasColumnName("is_cancelled")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Sale)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 