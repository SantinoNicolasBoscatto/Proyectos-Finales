using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NascarPage;
using NascarPage.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarPageTests
{
    public class BasePruebas
    {
        protected Negocio ConstruirContext (string nombreBD)
        {
            var opt = new DbContextOptionsBuilder<Negocio>()
                      .UseInMemoryDatabase(nombreBD).Options;
            return new Negocio(opt);
        }

        protected IMapper ConfigurarMapper()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapperProfile());
            });
            return config.CreateMapper();
        }

    }
}
