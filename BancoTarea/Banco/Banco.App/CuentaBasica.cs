namespace Banco.Modelos
{
    public class CuentaBasica : CuentaBancaria
    {
        public CuentaBasica(decimal saldoInicial) : base(saldoInicial)
        {
            if (saldoInicial < 300)
                throw new ArgumentException("El saldo inicial no puede ser menor a $300 para una cuenta básica.");
        }

        public override void RealizarCorteMensual()
        {
            // No hay cargos ni intereses en la cuenta básica
        }
    }
}


