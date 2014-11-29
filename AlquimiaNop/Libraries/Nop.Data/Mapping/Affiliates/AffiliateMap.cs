using System.Data.Entity.ModelConfiguration;
using Nop.Core.Domain.Affiliates;

namespace Nop.Data.Mapping.Affiliates
{
    public partial class AffiliateMap : EntityTypeConfiguration<Affiliate>
    {
        public AffiliateMap()
        {
            this.ToTable("Affiliate");
            this.HasKey(a => a.Id);

            this.HasRequired(a => a.Address).WithMany().HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);

            // This code maps a column in the database to the new property we created above
            // This creates a nullable nvarchar with a length of 255 characters 
            // in the Affiliate SQL table
            this.Property(m => m.AffiliateWebSite).HasMaxLength(255).IsOptional();	
        }
    }
}