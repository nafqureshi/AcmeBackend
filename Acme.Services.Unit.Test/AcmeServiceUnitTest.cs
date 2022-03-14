using DbContext = Acme.Data.DBRepository.Concrete.DbContext;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Acme.Services.Repository.Entity;
using System;

namespace Acme.Services.Unit.Test
{
    public class Tests
    {
        private DbContext context;

        [SetUp]
        public void Setup()
        { }

        [Test]
        public void ActivitySignupService_Signup_Success()
        {
            //Setup
            context = new DbContext(new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase("ActivitySignupService_Success").Options);

            var expectedOutput = true;

            var input = new ActivitySignup()
            {
                Email = "abdun@xyz.com",
                FirstName = "Abdun",
                LastName = "Test",
                Activity = Shared.Enum.ActivityEnum.Running,
                YearsOfExperience = 5,
                StartDate = DateTime.Now.AddDays(5)
            };

            //Act
            var activitySignupService = new ActivitySignupService(context);
            var response = activitySignupService.Signup(input);

            //Assert
            Assert.AreEqual(expectedOutput, response);
        }

        [Test]
        public void ActivitySignupService_Signup_Failure()
        {
            //Setup
            context = new DbContext(new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase("ActivitySignupService_Failure").Options);

            var expectedOutput = false;

            var input = new ActivitySignup()
            {
                Email = "aaa",
                FirstName = "Abdun",
                LastName = "Test",
                Activity = Shared.Enum.ActivityEnum.Running,
                YearsOfExperience = 5,
                StartDate = DateTime.Now.AddDays(5)
            };

            //Act
            var activitySignupService = new ActivitySignupService(context);
            var response = activitySignupService.Signup(input);

            //Assert
            Assert.AreEqual(expectedOutput, response);
        }
    }
}