using api_clientes.application.Models;
using api_clientes.webapi.tests.collections;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using Xunit;

namespace api_clientes.webapi.tests.fixtures
{
    [CollectionDefinition(Collections.ClienteCollection)]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    { }

    public class ClienteTestsFixture : IDisposable
    {
        Random rnd = new Random();

        #region GerarClientes
        /// <summary>
        /// Gera uma lista de Clientes
        /// </summary>
        /// <param name="quantidade"></param>
        /// <param name="novo"></param>
        /// <returns></returns>
        public IEnumerable<ClienteDTO> GerarClientes(int quantidade, bool novo, bool valido)
        {
            var clientes = new Faker<ClienteDTO>("pt_BR");
            var genero = new Faker().PickRandom<Name.Gender>();

            if (!novo)
            {
                clientes.RuleFor(c => c.Id, (f, c) => rnd.Next());
            }

            if (genero.ToString() == "Male")
            {
                clientes.RuleFor(c => c.Sexo, (f, c) => c.Sexo = 'M');
            }

            if (valido)
            {
                clientes.RuleFor(c => c.Cpf, (f, c) => f.Person.Cpf());
                clientes.RuleFor(c => c.Sexo, (f, c) => c.Sexo = 'F');
            }

            clientes.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName(genero));
            clientes.RuleFor(c => c.Sobrenome, (f, c) => f.Name.LastName(genero));

            return clientes.Generate(quantidade);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
        }
        #endregion
    }
}