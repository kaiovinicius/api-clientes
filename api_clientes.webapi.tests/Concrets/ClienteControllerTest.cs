using api_clientes.application.Abstracts;
using api_clientes.application.Models;
using api_clientes.webapi.Controllers;
using api_clientes.webapi.tests.collections;
using api_clientes.webapi.tests.fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace api_clientes.webapi.tests.concrets
{
    [Collection(Collections.ClienteCollection)]
    public class ClienteControllerTest
    {
        #region Variaveis
        readonly ClienteTestsFixture _clienteTestsFixture;
        Random rnd = new Random(); 
        #endregion

        #region Construtor
        public ClienteControllerTest(ClienteTestsFixture clientTestsFixture)
        {
            _clienteTestsFixture = clientTestsFixture;
        }
        #endregion

        #region Obter
        [Fact(DisplayName = "Obter Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_ObterClientePorId_DeveRetornarCliente()
        {
            // Arrange
            var clienteFake = _clienteTestsFixture.GerarClientes(1, false, true).FirstOrDefault();

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();

            iApplicationServiceCliente.Setup(c => c.Obter(clienteFake.Id))
                                      .Returns(new ClienteDTO { Id = clienteFake.Id });

            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            // Act
            var cliente = clientesController.Obter(clienteFake.Id.Value);

            // Assert 
            Assert.Equal(clienteFake.Id, cliente.Id);
        }

        [Fact(DisplayName = "Obter Cliente com Falha")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_ObterClientePorId_DeveFalharDevidoIdInexistente()
        {
            // Arrange
            var clienteFake = _clienteTestsFixture.GerarClientes(1, false, true).FirstOrDefault();

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();

            iApplicationServiceCliente.Setup(c => c.Obter(clienteFake.Id))
                                      .Returns(new ClienteDTO { Id = rnd.Next() });

            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            // Act
            var cliente = clientesController.Obter(clienteFake.Id.Value);

            // Assert 
            Assert.NotEqual(clienteFake.Id, cliente.Id);
        }
        #endregion

        #region Listar
        [Fact(DisplayName = "Listar Clientes com Sucesso")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_Listar_DeveRetornarClientes()
        {
            // Arrange
            int quantidade_clientes = 50;

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            var clientesController = new ClientesController(iApplicationServiceCliente.Object);
            
            iApplicationServiceCliente.Setup(c => c.Listar())
                .Returns(_clienteTestsFixture.GerarClientes(quantidade_clientes, false, true));

            // Act
            var clientes = clientesController.Listar();

            // Assert 
            iApplicationServiceCliente.Verify(c => c.Listar(), Times.Once);
            Assert.True(clientes.Count() == quantidade_clientes);
        }

        [Fact(DisplayName = "Listar Clientes com Falha")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_Listar_DeveFalhar()
        {
            // Arrange
            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            // Act
            var clientes = clientesController.BadRequest();

            // Assert 
            iApplicationServiceCliente.Verify(c => c.Listar(), Times.Never);
        }
        #endregion

        #region Inserir
        [Fact(DisplayName = "Inserir Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void Cliente_AdicionarCliente_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClientes(1, true, true).FirstOrDefault();

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();

            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            //Assert
            clientesController.Inserir(cliente);

            // Assert 
            iApplicationServiceCliente.Verify(c => c.Inserir(cliente), Times.Once);
        }

        [Fact(DisplayName = "Inserir Cliente com Falha")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void Cliente_AdicionarCliente_DeveFalharDevidoClienteInvalido()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClientes(1, true, false).FirstOrDefault();

            var context = new ValidationContext(cliente, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ClienteDTO), typeof(ClienteDTO)), typeof(ClienteDTO));

            // Act
            var isModelStateValid = Validator.TryValidateObject(cliente, context, results, true);


            // Assert 
            Assert.False(isModelStateValid);
        }
        #endregion

        #region Alterar
        [Fact(DisplayName = "Alterar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void Cliente_AlterarCliente_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClientes(1, false, true).FirstOrDefault();

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            iApplicationServiceCliente.Setup(m => m.Alterar(cliente)).Verifiable();

            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            //Act
            clientesController.Alterar(cliente);

            // Assert 
            iApplicationServiceCliente.Verify(c => c.Alterar(cliente), Times.Once);
        }

        [Fact(DisplayName = "Alterar Cliente com Falha")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void Cliente_AlterarCliente_DeveFalharDevidoClienteInvalido()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClientes(1, true, false).FirstOrDefault();

            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            iApplicationServiceCliente.Setup(c => c.Alterar(cliente)).Verifiable();

            var context = new ValidationContext(cliente, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ClienteDTO), typeof(ClienteDTO)), typeof(ClienteDTO));

            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            //Act
            clientesController.NotFound(cliente);
            var isModelStateValid = Validator.TryValidateObject(cliente, context, results, true);


            // Assert 
            iApplicationServiceCliente.Verify(c => c.Alterar(cliente), Times.Never);
            Assert.False(isModelStateValid);
        }
        #endregion

        #region Excluir
        [Fact(DisplayName = "Excluir Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_Excluir_DeveExecutarComSucesso()
        {
            // Arrange
            var clienteFake = _clienteTestsFixture.GerarClientes(1, false, true).FirstOrDefault();
            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            iApplicationServiceCliente.Setup(c => c.Excluir(clienteFake.Id));

            // Act
            var result = clientesController.Excluir(clienteFake.Id.Value);

            // Assert 
            iApplicationServiceCliente.Verify(r => r.Excluir(clienteFake.Id.Value), Times.Once);
        }

        [Fact(DisplayName = "Excluir Cliente com Falha")]
        [Trait("Categoria", "Cliente Controller Mock Tests")]
        public void ClienteController_Excluir_DeveFalharDevidoIdInexistente()
        {
            // Arrange
            var clienteFake = _clienteTestsFixture.GerarClientes(1, false, true).FirstOrDefault();
            var iApplicationServiceCliente = new Mock<IClienteApplicationService>();
            var clientesController = new ClientesController(iApplicationServiceCliente.Object);

            iApplicationServiceCliente.Setup(c => c.Excluir(clienteFake.Id));

            // Act
            var result = clientesController.NotFound();

            // Assert 
            iApplicationServiceCliente.Verify(c => c.Excluir(clienteFake.Id), Times.Never);
        }
        #endregion
    }
}