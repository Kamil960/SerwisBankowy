#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankData.Data.Bank;

namespace BankData.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<BankData.Data.CMS.Art1> Art1 { get; set; }

        public DbSet<BankData.Data.CMS.Art2> Art2 { get; set; }

        public DbSet<BankData.Data.CMS.Art3> Art3 { get; set; }

        public DbSet<BankData.Data.Bank.Klient> Klient { get; set; }

        public DbSet<BankData.Data.CMS.Kontakt> Kontakt { get; set; }

        public DbSet<BankData.Data.CMS.ONas> ONas { get; set; }

        public DbSet<BankData.Data.CMS.Strony> Strony { get; set; }

        public DbSet<BankData.Data.CMS.Usluga> Usluga { get; set; }

        public DbSet<BankData.Data.Bank.UslugaSzczegolowa> UslugaSzczegolowa { get; set; }

        public DbSet<BankData.Data.Bank.KontoOsobiste> KontoOsobiste { get; set; }

        public DbSet<BankData.Data.Bank.KontoFirmowe> KontoFirmowe { get; set; }

        public DbSet<BankData.Data.Bank.Kredyt> Kredyt { get; set; }

        public DbSet<BankData.Data.Bank.Lokata> Lokata { get; set; }

        public DbSet<BankData.Data.Bank.Ubezpieczenie> Ubezpieczenie { get; set; }
    }
}
