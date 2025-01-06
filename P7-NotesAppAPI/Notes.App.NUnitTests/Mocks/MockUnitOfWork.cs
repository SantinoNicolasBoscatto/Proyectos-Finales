using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NotesApp.Application.Contracts.Repositories;
using NotesApp.Application.Contracts.UnitOfWork;
using NotesApp.Application.Mapper;
using NotesApp.Data;
using NotesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.NUnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            // Creo la BD en Memoria y me aseguro de que este vacia
            Guid Id = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DbContextNotes>()
                .UseInMemoryDatabase(databaseName: $"DbContext-{Guid.NewGuid()}").Options;
            var dbContextFake = new DbContextNotes(options);
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            var mapper = mapConfig.CreateMapper();

            var mockUnitOfWork = new Mock<UnitOfWork>(dbContextFake, mapper);
            return mockUnitOfWork;
        }
    }
}
