using System.Collections.Generic;

namespace Whatssapp_31
{
    public interface IAgenda
    {
        void Cadastrar(Contato ctt);
        void Excluir(string excl);
        List<Contato> Listar();
    }
}