namespace tarea14
{
    public class Program
    {
        static void Main(String[] args)
        {
            Console.Clear();
            Baraja baraja = new Baraja(initCardObjets());
            bool salir = false;
            while(!salir)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("*************************************************");
                Console.WriteLine("*\t\tNaipes Españoles\t\t*");
                Console.WriteLine("*************************************************");
                Console.WriteLine("1 - Barajar");
                Console.WriteLine("2 - Mostrar la siguiente carta");
                Console.WriteLine("3 - Mostrar cartas disponibles");
                Console.WriteLine("4 - Dar cartas");
                Console.WriteLine("5 - Mostrar cartas del montón");
                Console.WriteLine("6 - Mostrar baraja entera");
                Console.WriteLine("7 - Salir");

                string userElection = Console.ReadLine();
                int userElectionChecked;
                if(int.TryParse(userElection, out userElectionChecked))
                {
                    switch(userElectionChecked)
                    {
                        case 1:
                            Console.Clear();
                            baraja.barajar();
                            Console.WriteLine("la baraja a sido mezclada con exito");
                            Console.WriteLine("¿cual será la siguiente elección?...\n\n");
                        break;
                        case 2:
                            Console.Clear();
                            baraja.siguienteCarta();
                        break;
                        case 3:
                            Console.Clear();
                            baraja.cartasDisponibles();
                        break;
                        case 4:
                            Console.Clear();
                            bool reparto = false;
                            while(!reparto)
                            {
                                Console.WriteLine("cuantas le gustaría recibir?", baraja.cartasDisponibles());
                                string userElectionReparto = Console.ReadLine();
                                int userElectionRepartoChecked;
                                if(int.TryParse(userElectionReparto, out userElectionRepartoChecked))
                                {
                                    reparto = baraja.darCartas(userElectionRepartoChecked, reparto);
                                }
                                else
                                {
                                    Console.WriteLine("por favor, solo numeros!\n");
                                }
                            }
                        break;
                        case 5:
                            Console.Clear();
                            baraja.cartasMonton();
                        break;
                        case 6:
                            Console.Clear();
                            baraja.MostrarTodas();
                        break;
                        case 7:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("esto fue un trabajo para el polo tecnológico de Mina Clavero" + 
                            "\nMuchas gracias!");
                            Console.ForegroundColor = ConsoleColor.White;
                            salir = true;
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                     Console.WriteLine("por favor, ingresar solo uno de los numeros habilitados\n");
                }

            }
        }

        /*-------------------------------------------------------*/
        /* construcción del mazo de 40 cartas */
        static List<Carta> initCardObjets()
        {
            int idCounter = 0;
            int cardCounter =1;
            List<Carta> Cartas= new List<Carta>();

            for(int i = 0; i < 40; i ++)
            {
                cardCounter = cardCounter == 8 ? 10 : cardCounter;
                cardCounter = cardCounter == 13 ? 1 : cardCounter;
                string palo = i < 10 ? "ESPADA" : i < 20 ? "BASTO" : i < 30 ? "COPA" : "ORO"; 
                Cartas.Add(new Carta(idCounter, cardCounter, palo));
                idCounter++;
                cardCounter++;
            }
            return Cartas;
        }
    }
}