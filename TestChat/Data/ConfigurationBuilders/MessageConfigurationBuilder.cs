using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChat.Data.Models;

namespace TestChat.Data.ConfigurationBuilders
{
    public class MessageConfigurationBuilder : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.ChatId).IsUnique(false);
            builder.HasOne(p => p.Chat).WithMany(p => p.Messages).HasForeignKey(p => p.ChatId);

            builder.HasIndex(p => p.MessageAuthorId).IsUnique(false);
            builder.HasOne(p => p.MessageAuthor).WithMany(p => p.Messages).HasForeignKey(p => p.MessageAuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            ;
        }
    }
}