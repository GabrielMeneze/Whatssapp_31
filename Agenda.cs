using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whatssapp_31
{
    public class Agenda : IAgenda
    {
        public List<Contato> contatos;
        private const string PATH = "Database/Contatos.CSV";

        public void Cadastrar(Contato ctt)
        {
            string[] Linha = { PrepararLinhaCSV(ctt) };
            File.AppendAllLines(PATH, Linha);
        }

        public void Excluir(Contato ctt)
        {
             List<string> linhas = new List<string>();

             using(StreamReader file = new StreamReader(PATH))
            {
            
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            
            }

           linhas.RemoveAll(x => x.Contains(ctt.Nome));
           
        }

        public List<Contato> Listar()
        {
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas)
            {
                string[] dado = linha.Split(";");
                Contato c = new Contato(
                dado[0],
                dado[1]
                );
                contatos.Add(c);
            }
            contatos = contatos.OrderBy(z => z.Nome).ToList();
            return contatos;
        }

        public string PrepararLinhaCSV(Contato ctt){
            return $"{ctt.Nome};{ctt.Telefone}";
        }

    }
}