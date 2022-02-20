using DomainDTO.EFTables;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyDBContext
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            
        }
        public virtual DbSet<SysOUsEFTables> SysOUsEFTables { get; set; }
        public virtual DbSet<DomainDTO.EFTables.SysOUMembersEFTables> SysOUMembersEFTables { get; set; }
        public virtual DbSet<DomainDTO.EFTables.SysOURoleMembersEFTables> SysOURoleMembersEFTables { get; set; }
        public virtual DbSet<DomainDTO.EFTables.SysOURolesEFTables> SysOURolesEFTables { get; set; }
        public virtual DbSet<DomainDTO.EFTables.SysUsersEFTables> SysUsersEFTables { get; set; }
    }
}
