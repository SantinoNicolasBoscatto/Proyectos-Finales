using Microsoft.EntityFrameworkCore;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Data.DataSeeding
{
    public static class NotesAppSeeding
    {
        public static void GenerateData(ModelBuilder builder)
        {
            builder.Entity<CategoryModel>().HasData(new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name ="Cotidiano"},
                new CategoryModel { Id = 2, Name ="Trabajo"},
                new CategoryModel { Id = 3, Name ="Hogar"},
                new CategoryModel { Id = 4, Name ="Estudio"},
                new CategoryModel { Id = 5, Name ="Juegos"},
                new CategoryModel { Id = 6, Name ="Diario"}
            });

            builder.Entity<StatusModel>().HasData(new List<StatusModel>
            {
                new StatusModel { Id = 1, Name ="Pendiente"},
                new StatusModel { Id = 2, Name ="Expirado"},
                new StatusModel { Id = 3, Name ="Terminado"},
            });

            builder.Entity<PriorityModel>().HasData(new List<PriorityModel>
            {
                new PriorityModel { Id = 1, Name ="Baja"},
                new PriorityModel { Id = 2, Name ="Media"},
                new PriorityModel { Id = 3, Name ="Alta"},
            });
        }
    }
}
