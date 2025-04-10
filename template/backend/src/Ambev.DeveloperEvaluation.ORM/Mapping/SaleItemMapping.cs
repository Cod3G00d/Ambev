using Ambev.DeveloperEvaluation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemMapping : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("sale_items");

            builder.HasKey(x => x.SaleItemId);
            
            builder.Property(x => x.SaleItemId)
                .HasColumnName("sale_item_id")
                .UseIdentityColumn();

            builder.Property(x => x.SaleId)
                .HasColumnName("sale_id")
                .IsRequired();

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(x => x.ProductName)
                .HasColumnName("product_name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnName("discount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TotalItemAmount)
                .HasColumnName("total_item_amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasOne(x => x.Sale)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 