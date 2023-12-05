

namespace CompanyApi.Tests
{
    public class DepartmentsControllerTests
    {
        [Fact]
        public async Task GetDepartments_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.GetAllDepartmentsAsync()).ReturnsAsync(new List<Department>());
            var controller = new DepartmentsController(mockService.Object);

            // Act
            var result = await controller.GetDepartments();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetDepartment_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.GetDepartmentByIdAsync(It.IsAny<int>())).ReturnsAsync(new Department());
            var controller = new DepartmentsController(mockService.Object);

            // Act
            var result = await controller.GetDepartment(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task PostDepartment_ReturnsCreatedAtAction()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.AddDepartmentAsync(It.IsAny<Department>()));
            var controller = new DepartmentsController(mockService.Object);

            // Act
            var result = await controller.PostDepartment(new Department());

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task PutDepartment_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.UpdateDepartmentAsync(It.IsAny<Department>()));
            var controller = new DepartmentsController(mockService.Object);
            var departmentId = 1;

            // Act
            var result = await controller.PutDepartment(departmentId, new Department { Id = departmentId });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutDepartment_ReturnsBadRequestResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.UpdateDepartmentAsync(It.IsAny<Department>()));
            var controller = new DepartmentsController(mockService.Object);
            var departmentId = 1;

            // Act
            var result = await controller.PutDepartment(departmentId, new Department { Id = departmentId + 1 });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteDepartment_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.DeleteDepartmentAsync(It.IsAny<int>()));
            var controller = new DepartmentsController(mockService.Object);

            // Act
            var result = await controller.DeleteDepartment(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task QueryDepartments_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IDepartmentService>();
            mockService.Setup(service => service.GetAllDepartmentsAsync()).ReturnsAsync(new List<Department>());
            var controller = new DepartmentsController(mockService.Object);

            // Act
            var result = await controller.QueryDepartments(5);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }

}