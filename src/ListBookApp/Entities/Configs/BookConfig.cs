using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListBookApp.Entites.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            
            builder.HasKey(x=>x.IdBook);
            
            builder.Property(x=>x.ISBN)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(16);
                
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(200);           
        }
    }
}