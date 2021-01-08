namespace MDC.Escudeiro.Domain.Abstract
{
    public abstract class ControleAbstract
    {
        protected int VolumeMaximo = 100;
        protected int VolumeMinimo = 0;
        protected int CanalMaximo = 1000;
        protected int CanalMinimo = 0;

        public int Volume { get; private set; }
        public int Canal { get; private set; }

        public void DefinirVolume(int volume)
        {
            if (volume >= VolumeMaximo)
            {
                Volume = VolumeMaximo;
            }
            else if (volume <= VolumeMinimo)
            {
                Volume = VolumeMinimo;
            }
            else
            {
                Volume = volume;
            }
        }

        public void DefinirCanal(int canal)
        {
            if (canal >= CanalMaximo)
            {
                Canal = CanalMaximo;
            }
            else if (canal <= CanalMinimo)
            {
                Canal = CanalMinimo;
            }
            else
            {
                Canal = canal;
            }
        }

        public virtual void AumentarVolume()
        {
            Volume++;
            DefinirVolume(Volume);
        }

        public virtual void DecrementarCanal()
        {
            Canal--;
            DefinirCanal(Canal);
        }

        public virtual void DiminuirVolume()
        {
            Volume--;
            DefinirVolume(Volume);
        }

        public virtual void IncrementarCanal()
        {
            Canal++;
            DefinirCanal(Canal);
        }

        public virtual void IrParaCanal(int numeroCanal)
        {
            DefinirCanal(numeroCanal);
        }
    }
}