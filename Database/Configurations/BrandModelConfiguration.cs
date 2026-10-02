using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BrandModelEntity = Marketplacesellerportal.Models.BrandModel;

namespace Marketplacesellerportal.Database.Configurations
{
    public class BrandModelConfiguration : IEntityTypeConfiguration<BrandModelEntity>
    {
        public void Configure(EntityTypeBuilder<BrandModelEntity> builder)
        {
            builder.ToTable("BrandModels");
            builder.HasKey(x => x.BrandModelId);
            builder.Property(x => x.BrandModelId).ValueGeneratedOnAdd();

            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(200);

            // If your BrandModels SQL has these - keep them, if not - change to Ignore
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);

            // DB doesn't have ModelCode - generate in code
            builder.Ignore(x => x.ModelCode);
            builder.Ignore(x => x.ModelCode);
            builder.Ignore(x => x.Barcode);
            builder.Ignore(x => x.BarcodeType);
            builder.Ignore(x => x.BarcodeImageUrl);
            builder.Ignore(x => x.IsBarcodeVerified);
            builder.Ignore(x => x.BarcodeVerifiedDate);
            builder.Ignore(x => x.ChannelModelId);
            builder.Ignore(x => x.ChannelCode);
            builder.Ignore(x => x.ChannelProductId);
            builder.Ignore(x => x.BatchId);
            builder.Ignore(x => x.SellerId);
            builder.Ignore(x => x.CustomerId);
            builder.Ignore(x => x.ProductId);
            builder.Ignore(x => x.SKU);
            builder.Ignore(x => x.IsCodeMatch);
            builder.Ignore(x => x.IsChannelCodeMatch);
            builder.Ignore(x => x.IsChannelSynced);
            builder.Ignore(x => x.LastChannelSyncDate);
            builder.Ignore(x => x.ChannelSyncStatus);
            builder.Ignore(x => x.SpecificationsJson);
            builder.Ignore(x => x.Product);

            builder.HasOne(x => x.Brand)
                   .WithMany(x => x.BrandModels)
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}