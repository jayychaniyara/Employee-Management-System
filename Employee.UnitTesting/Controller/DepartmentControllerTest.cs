using AutoFixture;
using Employee.Business.Interface;
using Employee.Business.Model;
using Employee.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Employee.UnitTesting.Controller
{
    public class DepartmentControllerTest : ApiUnitTestBase<DepartmentController>
    {
        private Mock<IDepartment> mockDeptRepository;
        public override void TestSetup()
        {
            mockDeptRepository = this.CreateAndInjectMock<IDepartment>();
            Target = new DepartmentController(mockDeptRepository.Object);
        }

        public override void TestTearDown()
        {
            mockDeptRepository.VerifyAll();
        }

        [Fact]
        public void GetDepartments_Ok()
        {
            //Arrange
            //var id = Fixture.Create<int>();
            var dept = Fixture.Create<List<Department>>();
            this.mockDeptRepository.Setup(c => c.GetDepartments()).Returns(dept);
            //Act
            var result = Target.GetDepartments() as ObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetDepartments(), Times.Once);
        }

        [Fact]
        public void GetDepartments_BadRequest()
        {
            //Arrange
            List<Department> dept = null;
            this.mockDeptRepository.Setup(c => c.GetDepartments()).Returns(dept);
            //Act
            var result = Target.GetDepartments() as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetDepartments(), Times.Once);
        }

        [Fact]
        public void GetActiveDepartments_Ok()
        {
            //Arrange
            var dept = Fixture.Create<List<Department>>();
            this.mockDeptRepository.Setup(c => c.GetActiveDepartments()).Returns(dept);
            //Act
            var result = Target.GetActiveDepartments() as ObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetActiveDepartments(), Times.Once);
        }

        [Fact]
        public void GetActiveDepartments_BadRequest()
        {
            //Arrange
            List<Department> dept = null;
            this.mockDeptRepository.Setup(c => c.GetActiveDepartments()).Returns(dept);
            //Act
            var result = Target.GetActiveDepartments() as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetActiveDepartments(), Times.Once);
        }

        [Fact]
        public void GetDepartmentDetailById_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var dept = Fixture.Create<Department>();
            dept.Id = id;
            this.mockDeptRepository.Setup(c => c.GetDepartmentDetailById(id)).Returns(dept);
            //Act
            var result = Target.GetDepartmentDetailById(id) as ObjectResult;
            //Assert
            Assert.Equal(dept, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetDepartmentDetailById(id), Times.Once);
        }



        [Fact]
        public void GetDepartmentDetailById_BadRequest()
        {
            //Arrange
            Department dept = null;
            var id = Fixture.Create<int>();
            this.mockDeptRepository.Setup(c => c.GetDepartmentDetailById(id)).Returns(dept);
            //Act
            var result = Target.GetDepartmentDetailById(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetDepartmentDetailById(id), Times.Once);
        }

        [Fact]
        public void GetAllEmployeeByDepartment_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var emp = Fixture.Create<List<Employees>>();
            this.mockDeptRepository.Setup(c => c.GetAllEmployeeByDepartment(id)).Returns(emp);
            //Act
            var result = Target.GetAllEmployeeByDepartment(id) as ObjectResult;
            //Assert
            //Assert.NotNull(result);
            Assert.Equal(emp, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetAllEmployeeByDepartment(id), Times.Once);
        }

        [Fact]
        public void GetAllEmployeeByDepartment_BadRequest()
        {
            //Arrange
            List<Employees> emp = null;
            var id = Fixture.Create<int>();
            this.mockDeptRepository.Setup(c => c.GetAllEmployeeByDepartment(id)).Returns(emp);
            //Act
            var result = Target.GetAllEmployeeByDepartment(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            //Assert.Equal(product, result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.GetAllEmployeeByDepartment(id), Times.Once);
        }

        [Fact]
        public void DeleteDepartment_Ok()
        {
            //Arrange
            var id = Fixture.Create<int>();
            var dept = Fixture.Create<Department>();
            dept.Id = id;
            this.mockDeptRepository.Setup(c => c.DeleteDepartment(id)).Returns(dept);
            //Act
            var result = Target.DeleteDepartment(id);
            //Assert
            Assert.NotNull(result);
            this.mockDeptRepository.Verify(m => m.DeleteDepartment(id), Times.Once);
        }

        [Fact]
        public void DeleteDepartment_BadRequest()
        {
            //Arrange
            var id = Fixture.Create<int>();
            Department dept = null;
            this.mockDeptRepository.Setup(c => c.DeleteDepartment(id)).Returns(dept);
            //Act
            var result = Target.DeleteDepartment(id) as StatusCodeResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            this.mockDeptRepository.Verify(m => m.DeleteDepartment(id), Times.Once);
        }
    }
}
