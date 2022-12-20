using AutoFixture;
using Employee.Business.Interface;
using Employee.Business.Model;
using Employee.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employee.UnitTesting.Controller
{
    public class EmployeeControllerTest : ApiUnitTestBase<EmployeeController>
    {
        private Mock<IEmployee> mockEmpRepository;

        public override void TestSetup()
        {
            mockEmpRepository = this.CreateAndInjectMock<IEmployee>();
            Target = new EmployeeController(mockEmpRepository.Object);
        }

        public override void TestTearDown()
        {
            mockEmpRepository.VerifyAll();
        }

        [Fact]
        public void GetEmployeeDetailById_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employees>();
            emp.Id = id;
            this.mockEmpRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);

            //Act
            var result = Target.GetEmployeeDetailById(id) as ObjectResult;

            //Assert
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEmpRepository.Verify(m => m.GetEmployeeDetailById(id), Times.Once);
        }

        [Fact]
        public void GetEmployeeDetailById_BadRequest()
        {
            //Arrange
            Employees emp = null;
            var id = Fixture.Create<int>();
            this.mockEmpRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);

            //Act
            var result = Target.GetEmployeeDetailById(id) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockEmpRepository.Verify(m => m.GetEmployeeDetailById(id), Times.Once);
        }

        [Fact]
        public void GetActiveEmployee_Ok()
        {
            //Arrange
            var emp = Fixture.Create<List<Employees>>();
            this.mockEmpRepository.Setup(c => c.GetActiveEmployee()).Returns(emp);

            //Act
            var result = Target.GetActiveEmployee() as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEmpRepository.Verify(m => m.GetActiveEmployee(), Times.Once);
        }

        [Fact]
        public void GetActiveEmployee_BadRequest()
        {
            //Arrange
            List<Employees> emp = null;
            this.mockEmpRepository.Setup(c => c.GetActiveEmployee()).Returns(emp);

            //Act
            var result = Target.GetActiveEmployee() as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockEmpRepository.Verify(m => m.GetActiveEmployee(), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employees>();
            emp.Id = id;
            this.mockEmpRepository.Setup(c => c.DeleteEmployee(id)).Returns(emp);

            //Act
            var result = Target.DeleteEmployee(id);

            //Assert
            Assert.NotNull(result);
            this.mockEmpRepository.Verify(m => m.DeleteEmployee(id), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_BadRequest()
        {
            //Arrange
            var id = Fixture.Create<int>();
            Employees emp = null;
            this.mockEmpRepository.Setup(c => c.DeleteEmployee(id)).Returns(emp);

            //Act
            var result = Target.DeleteEmployee(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockEmpRepository.Verify(m => m.DeleteEmployee(id), Times.Once);
        }

        [Fact]
        public void UpdateEmployeeDetail_Ok()
        {
            //var id = Fixture.Create<int>();
            var emp = Fixture.Create<Employees>();
            //emp.Id = id;
            //this.mockEmpRepository.Setup(c => c.GetEmployeeDetailById(id)).Returns(emp);
            this.mockEmpRepository.Setup(c => c.UpdateEmployeeDetail(emp)).Returns(emp);

            //Act
            var result = Target.UpdateEmployeeDetail(emp) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            //mockEmpRepository.Verify(c => c.GetEmployeeDetailById(id), Times.Once);
            mockEmpRepository.Verify(c => c.UpdateEmployeeDetail(emp), Times.Once);
        }

        [Fact]
        public void UpdateEmployeeDetail_BadRequest()
        {
            //Arrange
            Employees emp = null;

            //Act
            var result = Target.UpdateEmployeeDetail(emp) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void CreateEmployeeDetail_Ok()
        {
            var emp = Fixture.Create<Employees>();
            this.mockEmpRepository.Setup(c => c.CreateEmployeeDetail(emp)).Returns(emp);

            //Act
            var result = Target.CreateEmployeeDetail(emp) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.True(result.Value != null && result.Value is Employees);
            mockEmpRepository.Verify(c => c.CreateEmployeeDetail(emp), Times.Once);
        }

        [Fact]
        public void CreateEmployeeDetail_BadRequest()
        {
            //Arrange
            Employees emp = null;

            //Act
            var result = Target.CreateEmployeeDetail(emp) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
