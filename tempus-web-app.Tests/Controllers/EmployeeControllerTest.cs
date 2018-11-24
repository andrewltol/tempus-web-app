using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TempusWebApp.Controllers;
using TempusWebApp.Models;
using TempusWebApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TempusWebApp.Tests.Controllers
{
  [TestClass]
  public class EmployeeControllerTest
  {
    private readonly Employee _dummyEmployee = new Employee
    {
      Id = 1,
      FirstName = "Test",
      LastName = "Testerson",
      HireDate = new DateTime(1995, 1, 12)
    };

    private EmployeesController CreateEmployeeController(Mock<IEmployeeService> mockEmployeeService)
    {
      var controller = new EmployeesController(mockEmployeeService.Object);
      controller.Request = new HttpRequestMessage();
      controller.Configuration = new HttpConfiguration();

      return controller;
    }

    [TestMethod]
    public void Delete_EmployeeExists_RemovesEmployee()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Get(_dummyEmployee.Id)).ReturnsAsync(_dummyEmployee);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.DeleteEmployee(_dummyEmployee.Id).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Employee>));
      mockEmployeeService.Verify(es => es.Delete(_dummyEmployee));
    }

    [TestMethod]
    public void Delete_EmployeeDoesNotExist_ReturnsNotFound()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Get(_dummyEmployee.Id)).ReturnsAsync((Employee)null);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.DeleteEmployee(_dummyEmployee.Id).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
      mockEmployeeService.Verify(es => es.Delete(_dummyEmployee), Times.Never);
    }

    [TestMethod]
    public void Get_EmployeeExists_ReturnsEmployee()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Get(_dummyEmployee.Id)).ReturnsAsync(_dummyEmployee);
      var controller = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = controller.GetEmployee(_dummyEmployee.Id).Result as OkNegotiatedContentResult<Employee>;

      // Assert
      Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Employee>));
      Assert.AreEqual(_dummyEmployee, result.Content);
    }

    [TestMethod]
    public void Get_EmployeeDoesNotExist_ReturnsNotFound()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Get(_dummyEmployee.Id)).ReturnsAsync((Employee)null);
      var controller = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = controller.GetEmployee(_dummyEmployee.Id).Result as NotFoundResult;

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(5)]
    [DataRow(50)]
    public void GetAll_EmployeesFound_ReturnsList(int listSize)
    {
      // Arrange
      var testEmployees = new List<Employee>();
      for (var i = 0; i < listSize; ++i)
      {
        testEmployees.Add(new Employee
        {
          Id = i + 1,
          FirstName = "Alfred",
          LastName = "Employee family",
          HireDate = new DateTime(2000, 1, 1)
        });
      }

      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.GetAll()).ReturnsAsync(testEmployees);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.GetEmployees().Result as List<Employee>;

      // Assert
      CollectionAssert.AreEquivalent(result, testEmployees);
    }

    [TestMethod]
    public void Post_CreationSuccessful_ReturnsOk()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Add(_dummyEmployee)).Returns(Task.CompletedTask);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.PostEmployee(_dummyEmployee).Result as CreatedAtRouteNegotiatedContentResult<Employee>;

      // Assert
      Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<Employee>));
      Assert.AreEqual(result.Content, _dummyEmployee);
    }

    [TestMethod]
    public void Post_CreationErrors_ThrowsException()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Add(_dummyEmployee)).ThrowsAsync(new Exception("Any exception"));

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.PostEmployee(_dummyEmployee).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(ExceptionResult));
    }

    [TestMethod]
    public void Put_EmployeeExists_UpdatesEmployee()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Exists(_dummyEmployee.Id)).ReturnsAsync(true);
      mockEmployeeService.Setup(es => es.Update(_dummyEmployee)).Returns(Task.CompletedTask);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.PutEmployee(_dummyEmployee.Id, _dummyEmployee).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
      mockEmployeeService.Verify(es => es.Update(_dummyEmployee), Times.Once);
    }

    [TestMethod]
    public void Put_EmployeeDoesNotExist_ThrowsException()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Exists(_dummyEmployee.Id)).ReturnsAsync(false);

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.PutEmployee(_dummyEmployee.Id, _dummyEmployee).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void Put_UpdateErrors_ThrowsException()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Exists(_dummyEmployee.Id)).ReturnsAsync(true);
      mockEmployeeService.Setup(es => es.Update(_dummyEmployee)).ThrowsAsync(new Exception("Any exception"));

      var employeeController = CreateEmployeeController(mockEmployeeService);

      // Act
      var result = employeeController.PutEmployee(_dummyEmployee.Id, _dummyEmployee).Result;

      // Assert
      Assert.IsInstanceOfType(result, typeof(ExceptionResult));
    }
  }
}
