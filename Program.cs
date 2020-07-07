using System;
using System.Collections.Generic;

namespace Whatssapp_31
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato jao = new Contato("Joao", "+55 11 98134-3262");
             Contato Bruna = new Contato("Bruna", "+55 11 78632-43262");
             Contato tony = new Contato("Bruna", "+55 11 78632-43262");
            Agenda agenda = new Agenda();


            agenda.Cadastrar(jao);
            agenda.Cadastrar(Bruna);
            agenda.Cadastrar(tony);
            agenda.Excluir(tony);

            foreach(Contato c in agenda.Listar())
            {
                Console.WriteLine($"Nome: {c.Nome} - Numero: {c.Telefone}");
            }

            Mensagem msg = new Mensagem();
            msg.Destinario = jao;
            msg.Texto = "slv men"+jao.Nome;
            Console.WriteLine(msg.Enviar());
            

            


        }
    }
}
