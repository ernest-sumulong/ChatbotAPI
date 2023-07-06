using System;
using Microsoft.EntityFrameworkCore;
using ChatbotAPI.Models;

namespace ChatbotAPI.Data
{
    public class ChatbotAPIContext : DbContext
    {
        public ChatbotAPIContext(DbContextOptions<ChatbotAPIContext> options) :base(options){ }

        public DbSet<Procedure> Procedures { get; set; }
    }
}
