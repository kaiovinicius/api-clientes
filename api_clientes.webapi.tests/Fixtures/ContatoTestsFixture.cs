using api_clientes.application.Models;
using api_clientes.webapi.tests.collections;
using Bogus;
using System;
using System.Collections.Generic;
using Xunit;

namespace api_clientes.webapi.tests.fixtures
{
    [CollectionDefinition(Collections.ContatoCollection)]
    public class ContatoCollection : ICollectionFixture<ContatoTestsFixture>
    { }

    public class ContatoTestsFixture : IDisposable
    {
        Random rnd = new Random();

        #region GerarContatos
        /// <summary>
        /// Gera uma lista de Contatos
        /// </summary>
        /// <param name="quantidade"></param>
        /// <param name="novo"></param>
        /// <returns></returns>
        public IEnumerable<ContatoDTO> GerarContatos(int quantidade, bool novo, bool valido)
        {
            var contatos = new Faker<ContatoDTO>("pt_BR");

            if (!novo)
            {
                contatos.RuleFor(c => c.Id, (f, c) => rnd.Next());
            }

            if (valido)
            {
                contatos.RuleFor(c => c.IdCliente, (f, c) => rnd.Next());
                contatos.RuleFor(c => c.Ddd, (f, c) => new Randomizer().Replace("##"));
                contatos.RuleFor(c => c.Numero, (f, c) => f.Phone.PhoneNumber("#########"));
                contatos.RuleFor(c => c.Email, (f, c) => f.Internet.Email());
            }

            return contatos.Generate(quantidade);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        } 
        #endregion
    }
}
