using System;
using System.Linq;

namespace VerificaPlacas
{
    public class Placa : IComparable<Placa>
    {
        public readonly string Identificador;
        public readonly string Lote;
        public readonly string Numerando;

        private readonly string _placa;

        public static Placa VerificarPlacaJalisco(string placa)
        {
            string[] placaDividida;

            if (!((placaDividida = placa.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)).Length == 3))
                return null;

            string inicial = placaDividida[0];
            if (!(inicial.Length == 3 && inicial.All(c => char.IsUpper(c)) && (inicial[0] == 'H' || inicial[0] == 'J')))
                return null;

            string segundo = placaDividida[1];
            if (!(segundo.Length == 2 && segundo.All(c => char.IsDigit(c))))
                return null;

            string tercero = placaDividida[2];
            if (!(tercero.Length == 2 && tercero.All(c => char.IsDigit(c))))
                return null;

            return new Placa(placa);
        }

        private Placa(string placa)
        {
            _placa = placa;
            Identificador = placa.Substring(0, 3);
            Lote = placa.Substring(4, 2);
            Numerando = placa.Substring(7, 2);
        }
        public override string ToString()
        {
            return _placa;
        }
        public int CompareTo(Placa other)
        {
            return _placa.CompareTo(other.ToString());
        }
    }
}
