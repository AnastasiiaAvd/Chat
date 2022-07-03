using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChat.Data.Models;

namespace TestChat.Data.ConfigurationBuilders
{
    public class ChatConfigurationBuilder : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats");
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.ChatOwner).WithMany(p => p.OwnerChats).HasForeignKey(p => p.ChatOwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ChatGuest).WithMany(p => p.GuestChats).HasForeignKey(p => p.ChatGuestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}