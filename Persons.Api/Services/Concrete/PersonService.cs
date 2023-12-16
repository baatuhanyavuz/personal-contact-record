﻿using Persons.Api.Context;
using Persons.Api.Dtos;
using Persons.Api.Entity;
using Persons.Api.Services.Abstract;

namespace Persons.Api.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _dbContext;
        public PersonService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPerson(PersonCreateDto data)
        {
            Person person = new Person()
            {
                Company = data.Company,
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
        }

    }
}