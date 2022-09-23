namespace tarea14
{
    public class Baraja
    {
        private Carta[] _mazoCartasPares = new Carta[25];
        private Carta[] _mazoCartasImpares = new Carta[25];
        private List<Carta> _mazo = new List<Carta>();
        private Random rnd = new Random();
        private List<Carta> _monton = new List<Carta>();

        public Baraja ( List<Carta> mazo)
        {
            this._mazo = mazo;
        }
/*--------------------------------------------------------------------*/
/* @ metodos solicitados por el ejercicio*/
        public void barajar()
        {
            int vueltas = rnd.Next(2, 6);
            for(int v = 0; v < vueltas; v++)
            {
                MezclaPorCorte(_mazo);
                int counter_mazoCartasPares = 0;
                int counter_mazoCartasImpares = 0;
                int tamañoMazo = _mazo.Count;
                /* mezcla por ojeo */
                for(int i = 0; i < tamañoMazo; i++)
                {                    
                    if(i%2 == 0)
                    {
                        _mazoCartasPares[counter_mazoCartasPares] = _mazo[i];
                        counter_mazoCartasPares++;
                    }
                    else
                    {
                        _mazoCartasImpares[counter_mazoCartasImpares] = _mazo[i];
                        counter_mazoCartasImpares++;
                    }
                }
                counter_mazoCartasPares = 0;
                for(int i = 0; i < tamañoMazo; i++)
                {
                    if(i < tamañoMazo/2)
                    {
                        _mazo[i] = _mazoCartasImpares[i];
                    }
                    else
                    {
                        _mazo[i] = _mazoCartasPares[counter_mazoCartasPares];
                        counter_mazoCartasPares++;
                    }
                }
                MezclaPorCorte(_mazo);
            }
        }
        public void siguienteCarta()
        {
            if(_mazo.Count > 0)
            {
                Console.WriteLine("se entrega la siguiente carta: ");
                _mazo[0].Ver();
                _monton.Add(_mazo[0]);
                _mazo.RemoveAt(0);
                if(_mazo.Count == 0)
                {
                    Console.WriteLine("todas las cartas fueron dadas");
                }
            }
            else
            {
                Console.WriteLine("todas las cartas fueron dadas");
            }

        }
        public int cartasDisponibles()
        {
            int counter = _mazo.Count;
            if(counter > 1)
            Console.WriteLine($"quedan por repartir {counter} cartas");
            else if (counter == 1)
            {
                Console.WriteLine($"queda por repartir esta ultima carta:");
                _mazo[0].Ver();
            }
            else
            {
                Console.WriteLine("ya no quedan mas cartas disponibles en el mazo.\n");
            }
            return counter;
        }
        public bool darCartas(int election, bool reparto)
        {
            if(_mazo.Count >= election)
            {
                Console.WriteLine($"\n*) se entregan las siguientes {election} cartas: ");
                for(int i = 0; i < election; i++)
                {
                    _mazo[0].Ver();
                    _monton.Add(_mazo[0]);
                    _mazo.RemoveAt(0);
                }
                Console.WriteLine($"\n{election} cartas fueron entregadas.\n");
                if(_mazo.Count == 0)
                {
                    Console.WriteLine("todas las cartas fueron dadas");
                }
                reparto = true;

            }
            else
            {
                Console.WriteLine($"no puedo entregar esa cantidad de cartas, como máximo puedo dar {_mazo.Count}\n");
                reparto = false;
            }
            return reparto;
        }
        public void cartasMonton()
        {
            int counter = _monton.Count;
            if(counter > 0)
            {
                Console.WriteLine("las siguientes cartas corresponden al montón ya descartado del mazo:");
                for(int i=0; i<counter; i++)
                {
                    _monton[i].Ver();
                }
                Console.WriteLine($"\nen total {counter} cartas del montón fueron presentadas. \n");
            }
            else
            {
                Console.WriteLine($"\nAún no se ha descartado ninguna carta.\n");
            }
        }

/*--------------------------------------------------------------------*/
/* @ Metodos propios*/
        private void MezclaPorCorte(List<Carta> mazo)
        {
            int tamañoMazo = _mazo.Count;
            if(tamañoMazo > 5)
            {
                int corte1 = rnd.Next(2, tamañoMazo);
                int corte2 = rnd.Next(2, tamañoMazo);
                bool bloqueEnCola1 = false;
                bool bloqueEnCola2 = false;
                if(corte2 < corte1)
                {
                    int aux = corte1;
                    corte1 = corte2;
                    corte2 = aux;
                }
                if(corte1 == corte2 || corte1 + 1 == corte2)
                {
                    corte1--;
                    corte2++;
                }
                int auxCorte = _mazo.Count;
                Queue<Carta> OrdenadorDeMazo = new Queue<Carta>();
                int counter = 0;

                for(int i = corte2; i < auxCorte; i++)
                {
                    OrdenadorDeMazo.Enqueue(mazo[i]);
                    if(i == auxCorte-1)
                    {
                        if(bloqueEnCola1 == false)
                        {
                            i = corte1;
                            auxCorte = corte2;
                            bloqueEnCola1 = true;
                        }
                        else if(bloqueEnCola1 == true && bloqueEnCola2 == false)
                        {
                            i = -1;
                            auxCorte = corte1+1;
                            bloqueEnCola2 = true;
                        }
                    }
                    counter++;
                }
                for(int i = 0; i < tamañoMazo; i++)
                {
                    mazo[i] = OrdenadorDeMazo.Dequeue();
                }
            }

        
        }
        public void Mostrar1(int x)
        {
            _mazo[x].Ver();
        }
        public void MostrarTodas()
        {
            int counter = _mazo.Count;
            if(counter>0)
            {
                Console.WriteLine($"se presentan las {counter} cartas dispoibles en el mazo: ");
                for(int i = 0; i < counter; i++)
                {
                    _mazo[i].Ver();
                }
                Console.WriteLine($"\nse presentaron las {counter} cartas dispoibles. \n");
            }
            else
            {
                Console.WriteLine($"se presentan las {counter} cartas dispoibles en el mazo: ");
            foreach(Carta carta in _mazo)
            {
                carta.Ver();
            }
                Console.WriteLine($"\nya no quedan cartas en el mazo\n");
            }
        }
    }
}
