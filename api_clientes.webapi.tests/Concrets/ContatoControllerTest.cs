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
    [Collection(Collections.ContatoCollection)]
    public class ContatoControllerTest
    {
        #region Variaveis
        readonly ContatoTestsFixture _contatoTestsFixture;
        Random rnd = new Random(); 
        #endregion

        #region Construtor
        public ContatoControllerTest(ContatoTestsFixture contatoTestsFixture)
        {
            _contatoTestsFixture = contatoTestsFixture;
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        [Fact(DisplayName = "Obter Contato com Sucesso")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_ObterContatoPorId_DeveRetornarContato()
        {
            // Arrange
            var contatoFake = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();

            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            
            iApplicationServiceContato.Setup(c => c.Obter(contatoFake.Id))
                                      .Returns(new ContatoDTO { Id = contatoFake.Id});

            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            // Act
            var contato = contatosController.Obter(contatoFake.Id.Value);

            // Assert 
            Assert.Equal(contatoFake.Id, contato.Id);
        }

        [Fact(DisplayName = "Obter Contato com Falha")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_ObterContatoPorId_DeveFalharDevidoIdInexistente()
        {
            // Arrange
            var contatoFake = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();
            var iApplicationServiceContato = new Mock<IContatoApplicationService>();

            iApplicationServiceContato.Setup(c => c.Obter(contatoFake.Id))
                                      .Returns(new ContatoDTO { Id = rnd.Next()});

            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            // Act
            var contato = contatosController.Obter(contatoFake.Id.Value);

            // Assert 
            Assert.NotEqual(contatoFake.Id, contato.Id);
        }
        #endregion

        #region Listar
        [Fact(DisplayName = "Listar Contatos com Sucesso")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_Listar_DeveRetornarContatos()
        {
            // Arrange
            int quantidade_contatos = 50;
            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            var contatosController = new ContatosController(iApplicationServiceContato.Object);
            iApplicationServiceContato.Setup(c => c.Listar()).Returns(_contatoTestsFixture.GerarContatos(quantidade_contatos, false, true));

            // Act
            var contatos = contatosController.Listar();

            // Assert 
            iApplicationServiceContato.Verify(c => c.Listar(), Times.Once);
            Assert.True(contatos.Count() == quantidade_contatos);
        }

        [Fact(DisplayName = "Listar Contatos com Falha")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_Listar_DeveFalhar()
        {
            // Arrange
            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            // Act
            var contatos = contatosController.BadRequest();

            // Assert 
            iApplicationServiceContato.Verify(r => r.Listar(), Times.Never);
        }
        #endregion

        #region Inserir
        [Fact(DisplayName = "Inserir Contato com Sucesso")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void Contato_AdicionarContato_DeveExecutarComSucesso()
        {
            //Arrange
            var contato = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();

            var iApplicationServiceContato = new Mock<IContatoApplicationService>();

            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            //Assert
            contatosController.Inserir(contato);

            // Assert 
            iApplicationServiceContato.Verify(c => c.Inserir(contato), Times.Once);
        }

        [Fact(DisplayName = "Inserir Contato com Falha")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void Contato_AdicionarContato_DeveFalharDevidoContatoInvalido()
        {
            //Arrange
            var contato = _contatoTestsFixture.GerarContatos(1, true, false).FirstOrDefault();

            var context = new ValidationContext(contato, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ContatoDTO), typeof(ContatoDTO)), typeof(ContatoDTO));

            // Act
            var isModelStateValid = Validator.TryValidateObject(contato, context, results, true);


            // Assert 
            Assert.False(isModelStateValid);
        }
        #endregion

        #region Alterar
        [Fact(DisplayName = "Alterar Contato com Sucesso")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void Contato_AlterarContato_DeveExecutarComSucesso()
        {
            //Arrange
            var contato = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();

            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            iApplicationServiceContato.Setup(m => m.Alterar(contato)).Verifiable();

            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            //Act
            contatosController.Alterar(contato);

            // Assert 
            iApplicationServiceContato.Verify(c => c.Alterar(contato), Times.Once);
        }

        [Fact(DisplayName = "Alterar Contato com Falha")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void Contato_AlterarContato_DeveFalharDevidoContatoInvalido()
        {
            //Arrange
            var contato = _contatoTestsFixture.GerarContatos(1, true, false).FirstOrDefault();

            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            iApplicationServiceContato.Setup(m => m.Alterar(contato)).Verifiable();

            var context = new ValidationContext(contato, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ContatoDTO), typeof(ContatoDTO)), typeof(ContatoDTO));

            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            //Act
            contatosController.NotFound(contato);
            var isModelStateValid = Validator.TryValidateObject(contato, context, results, true);


            // Assert 
            iApplicationServiceContato.Verify(c => c.Alterar(contato), Times.Never);
            Assert.False(isModelStateValid);
        }
        #endregion

        #region Excluir
        [Fact(DisplayName = "Excluir Contato com Sucesso")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_Excluir_DeveExecutarComSucesso()
        {
            // Arrange
            var contato = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();
            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            iApplicationServiceContato.Setup(c => c.Excluir(contato.Id));


            // Act
            var result = contatosController.Excluir(contato.Id.Value);

            // Assert 
            iApplicationServiceContato.Verify(c => c.Excluir(contato.Id.Value), Times.Once);
        }

        [Fact(DisplayName = "Excluir Contato com Falha")]
        [Trait("Categoria", "Contato Controller Mock Tests")]
        public void ContatoController_Excluir_DeveFalharDevidoIdInexistente()
        {
            // Arrange
            var contatoFake = _contatoTestsFixture.GerarContatos(1, false, true).FirstOrDefault();
            var iApplicationServiceContato = new Mock<IContatoApplicationService>();
            var contatosController = new ContatosController(iApplicationServiceContato.Object);

            iApplicationServiceContato.Setup(c => c.Excluir(contatoFake.Id));

            // Act
            var result = contatosController.NotFound();

            // Assert 
            iApplicationServiceContato.Verify(c => c.Excluir(contatoFake.Id), Times.Never);
        }
        #endregion
    }
}