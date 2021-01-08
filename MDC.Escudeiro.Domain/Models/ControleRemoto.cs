using MDC.Escudeiro.Domain.Abstract;

namespace MDC.Escudeiro.Domain.Models
{
    public class ControleRemoto : ControleAbstract
    {
        private readonly Televisao _televisao;

        public ControleRemoto(Televisao televisao)
        {
            _televisao = televisao;
        }

        public override void AumentarVolume()
        {
            var volume = _televisao.Volume;
            _televisao.DefinirVolume(++volume);
        }

        public override void DecrementarCanal()
        {
            var canal = _televisao.Canal;
            _televisao.DefinirCanal(--canal);
        }

        public override void DiminuirVolume()
        {
            var volume = _televisao.Volume;
            _televisao.DefinirVolume(--volume);
        }

        public override void IncrementarCanal()
        {
            var canal = _televisao.Canal;
            _televisao.DefinirCanal(++canal);
        }

        public override void IrParaCanal(int numeroCanal)
        {
            _televisao.DefinirCanal(numeroCanal);
        }
    }
}
