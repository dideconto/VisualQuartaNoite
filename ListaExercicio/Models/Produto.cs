namespace ListaExercicio.Models
{
    public class Produto
    {
        public Produto()
        {
            Nome = "XYZ";
        }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

    }
}