﻿using CorDosOlhos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorDosOlhos.Data
{
    public class Contexto : DbContext
    //esta classe vai herdar DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            // opitionsBuilder.UseSqlServer("Data Source=LAPTOP-DU1D5PMO\\MSSQLSERVER01;Initial Catalog=CorDosOlhos;Integrated Security=True");
            opitionsBuilder.UseSqlServer("Server=tcp:cordosolhos.database.windows.net,1433;Initial Catalog=CorDosOlhos;Persist Security Info=False;User ID=admCor;Password=Internet*1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<Cadastro> Cadastros { get; set; }
        //vai setar a class Cliente e vai chamar a propiedade de Clientes

        //este medoto e para a string de conecção com o bd
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Contato> Contatos { get; set; }


        //este metodo OnModelCreateing() recebe um obj da classe ModelBuilder chamada 
        //modelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cadastro>(table => {
                table.ToTable("Cadastros");
                table.HasKey(prop => prop.IdC);
                table.Property(prop => prop.NomeC).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.SobrenomeC).HasColumnType("varchar(50)").IsRequired();
                table.Property(prop => prop.NasC).HasColumnType("date");
                table.Property(prop => prop.CPFC).HasColumnType("char(11)").IsRequired();
                table.Property(prop => prop.Etnia).HasConversion<String>().HasMaxLength(9);
                table.Property(prop => prop.Genero).HasConversion<String>().HasMaxLength(9);
                table.Property(prop => prop.CidadeC).HasColumnType("varchar(50)");
                table.Property(prop => prop.UFC).HasColumnType("char(2)");

                table.Property(prop => prop.CEPC).HasColumnType("char(8)");
                table.Property(prop => prop.BairroC).HasColumnType("varchar(50)");
                table.Property(prop => prop.EnderecoC).HasColumnType("varchar(50)");
                table.Property(prop => prop.NumeroC).HasColumnType("char(7)");
                table.Property(prop => prop.TelefoneC).HasColumnType("char(13)");
                table.Property(prop => prop.EmailC).HasColumnType("varchar(50)");

                //IsRequired = para n deixar o valor nulo

            });


            modelBuilder.Entity<Registro>(table => {
                table.ToTable("Registros");
                table.HasKey(prop => prop.IdRegistro);
                table.Property(prop => prop.CidadeRegistro).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.CEPRegistro).HasColumnType("char(8)");
                table.Property(prop => prop.BairroRegistro).HasColumnType("varchar(50)");
                table.Property(prop => prop.EnderecoRegistro).HasColumnType("varchar(50)").IsRequired();
                table.Property(prop => prop.NumeroRegistro).HasColumnType("char(7)");
                table.Property(prop => prop.PontoRefRegistro).HasColumnType("varchar(50)");
                table.Property(prop => prop.DescricaoRegistro).HasColumnType("varchar(MAX)");

            });
            modelBuilder.Entity<Contato>(table => {
                table.ToTable("Contatos");
                table.HasKey(prop => prop.IdContato);
                table.Property(prop => prop.NomeContato).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.EmailContato).HasColumnType("varchar(50)").IsRequired();
                table.Property(prop => prop.MsgContato).HasColumnType("varchar(MAX)");

            });


        }
        //modelBuilder =obj   
        // e acessa metodo=Entity
        //Cliente mapear o modelo Cliente
        // o nome vai ser Clientes
        ////////////////////////destino/////////////////////////////


    }

}

