namespace Whatssapp_31
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public Contato Destinario { get; set; }

        public string Enviar(Contato ctt){
            return $"to: {ctt.Nome}\n msg: {Texto}";
        }
    }
}