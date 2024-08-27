using DailyPlanner.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyPlanner.Data.Mapping
{
    public class SignUpModelMap : IEntityTypeConfiguration<SignUpModel>
    {
        public void Configure(EntityTypeBuilder<SignUpModel> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
