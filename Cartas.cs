namespace tarea14
{
    public class Carta
    {
        private int id;
        private int cardNumber;
        private string cardTipe;

        public Carta(int id, int cardNumber, string cardTipe)
        {
            this.id = id;
            this.cardNumber = cardNumber;
            this.cardTipe = cardTipe;
        }
        public void Ver()
        {
            Console.WriteLine(" " + cardNumber+ " de " + cardTipe);
        }
        public int Id()
        {
            return id;
        }
    }
}