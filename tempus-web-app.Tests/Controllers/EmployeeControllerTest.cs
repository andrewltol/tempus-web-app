using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TempusWebApp.Controllers;
using TempusWebApp.Models;
using TempusWebApp.Services;

namespace tempus_web_app.Tests.Controllers
{
  [TestClass]
  public class EmployeeControllerTest
  {
    private Employee _dummyEmployee = new Employee
    {
      Id = 1,
      FirstName = "Test",
      LastName = "Testerson",
      HireDate = new DateTime(1995, 1, 12)
    };

    private void SetupController(EmployeesController controller)
    {
      controller.Request = new HttpRequestMessage();
      controller.Configuration = new HttpConfiguration();
    }

    [TestMethod]
    public void Get_EmployeeExists_ReturnsEmployee()
    {
      // Arrange
      var mockEmployeeService = new Mock<IEmployeeService>();
      mockEmployeeService.Setup(es => es.Get(_dummyEmployee.Id)).ReturnsAsync(_dummyEmployee);
      var controller = new EmployeesController(mockEmployeeService.Object);
      SetupController(controller);

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
      var controller = new EmployeesController(mockEmployeeService.Object);
      SetupController(controller);

      // Act
      var result = controller.GetEmployee(_dummyEmployee.Id).Result as NotFoundResult;

      // Assert
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
  }
}
