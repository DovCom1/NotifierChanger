using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotifierChanger.Model.Entities;

namespace NotifierChanger.Infrastructure.Configuration;

public class CallEventConfiguration : IEntityTypeConfiguration<CallEvent>
{
    public void Configure(EntityTypeBuilder<CallEvent> builder)
    {
        builder.ToTable("CallEvents");
        builder.HasKey(e => e.Id);
        
        builder
            .Property(u => u.Id)
            .HasColumnName("id");
        
        builder
            .Property(u => u.SenderId)
            .HasColumnName("sender_id")
            .IsRequired();
        
        builder
            .Property(u => u.ReceiverId)
            .HasColumnName("receiver_id")
            .IsRequired();
        
        builder
            .Property(u => u.SenderName)
            .HasColumnName("sender_name")
            .IsRequired();
        
        builder
            .Property(u => u.ReceiverName)
            .HasColumnName("receiver_name")
            .IsRequired();
        
        builder
            .Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}