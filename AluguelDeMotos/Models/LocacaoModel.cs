using AluguelDeMotos.Enums;
using AluguelDeMotos.Models.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models
{
    public class LocacaoModel
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        [Required(ErrorMessage = "Selecione a data para devolução")]
        public DateTime DataDevolucao { get; set; }
        public DateTime PrevisaoDevolucao { get; set; }
        public decimal ValorPorDia { get; set; }
        public decimal Multa { get; set; } //pode tirar essas prop
        public decimal ValorTotal { get; set; }
        [Required(ErrorMessage = "Selecione o plano para locação")]
        public PlanoEnum Plano { get; set; }
        public int MotoId { get; set; }
        public MotoModel Moto { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        public void DefinirValorLocacao()
        {
            switch (Plano)
            {
                case PlanoEnum.seteDias:

                    var diasEfetivos = DataDevolucao.Subtract(DataLocacao);
                    TimeSpan diasPlano = new TimeSpan(7, 0, 0, 0);
                    PrevisaoDevolucao = DataLocacao + diasPlano;
                    ValorPorDia = 30m;
                    decimal taxa = 0.20m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.quinzeDias:

                    diasEfetivos = DataDevolucao.Subtract(DataLocacao);
                    diasPlano = new TimeSpan(15, 0, 0, 0);
                    PrevisaoDevolucao = DataLocacao + diasPlano;
                    ValorPorDia = 28m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.trintaDias:

                    diasEfetivos = DataDevolucao.Subtract(DataLocacao);
                    diasPlano = new TimeSpan(30, 0, 0, 0);
                    PrevisaoDevolucao = DataLocacao + diasPlano;
                    ValorPorDia = 22m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.quarentaECincoDias:

                    diasEfetivos = DataDevolucao.Subtract(DataLocacao);
                    diasPlano = new TimeSpan(45, 0, 0, 0);
                    PrevisaoDevolucao = DataLocacao + diasPlano;
                    ValorPorDia = 20m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.cinquentaDias:

                    diasEfetivos = DataDevolucao.Subtract(DataLocacao);
                    diasPlano = new TimeSpan(50, 0, 0, 0);
                    PrevisaoDevolucao = DataLocacao + diasPlano;
                    ValorPorDia = 18m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
            }
        }

        private void DiferencaEntreDias(TimeSpan diasEfetivos, TimeSpan diasPlano, decimal taxa)
        {
            if (diasEfetivos < diasPlano)
            {
                ValorTotal = EfetivosMenorQuePlano(diasEfetivos, diasPlano, taxa);
            }
            else if (diasEfetivos > diasPlano)
            {
                ValorTotal = EfetivosMaiorQuePlano(diasEfetivos, diasPlano);
            }
            else
            {
                ValorTotal = EfetivosIgualAoPlano(diasPlano);
            }
        }

        private decimal EfetivosMenorQuePlano(TimeSpan diasEfetivos, TimeSpan diasPlano, decimal taxa)
        {
            var diasNaoEfetivos = diasPlano - diasEfetivos;

            var valorEfetivos = diasEfetivos.Days * ValorPorDia;
            Multa = (diasNaoEfetivos.Days * ValorPorDia) * taxa;

            return valorEfetivos + Multa;
        }

        private decimal EfetivosMaiorQuePlano(TimeSpan diasEfetivos, TimeSpan diasPlano)
        {
            var diasAdicionais = diasEfetivos - diasPlano;

            var valorEfetivos = diasPlano.Days * ValorPorDia;
            Multa = diasAdicionais.Days * 50m;

            return valorEfetivos + Multa;
        }

        private decimal EfetivosIgualAoPlano(TimeSpan diasPlano)
        {
            return diasPlano.Days * ValorPorDia;
        }
    }
}
