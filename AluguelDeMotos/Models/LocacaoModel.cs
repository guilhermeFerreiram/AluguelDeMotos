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

                    var ts = DataDevolucao.Subtract(DataLocacao);
                    var diasEfetivos = (int)Math.Ceiling(ts.TotalDays);

                    Console.WriteLine("AQUIIIIIII " + diasEfetivos);
                    int diasPlano = 7;
                    PrevisaoDevolucao = DataLocacao + new TimeSpan(diasPlano, 0, 0, 0);
                    ValorPorDia = 30m;
                    decimal taxa = 0.20m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.quinzeDias:

                    ts = DataDevolucao.Subtract(DataLocacao);
                    diasEfetivos = (int)Math.Ceiling(ts.TotalDays);
                    diasPlano = 15;
                    PrevisaoDevolucao = DataLocacao + new TimeSpan(diasPlano, 0, 0, 0);
                    ValorPorDia = 28m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.trintaDias:

                    ts = DataDevolucao.Subtract(DataLocacao);
                    diasEfetivos = (int)Math.Ceiling(ts.TotalDays);
                    diasPlano = 30;
                    PrevisaoDevolucao = DataLocacao + new TimeSpan(diasPlano, 0, 0, 0);
                    ValorPorDia = 22m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.quarentaECincoDias:

                    ts = DataDevolucao.Subtract(DataLocacao);
                    diasEfetivos = (int)Math.Ceiling(ts.TotalDays);
                    diasPlano = 45;
                    PrevisaoDevolucao = DataLocacao + new TimeSpan(diasPlano, 0, 0, 0);
                    ValorPorDia = 20m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
                case PlanoEnum.cinquentaDias:

                    ts = DataDevolucao.Subtract(DataLocacao);
                    diasEfetivos = (int)Math.Ceiling(ts.TotalDays);
                    diasPlano = 50;
                    PrevisaoDevolucao = DataLocacao + new TimeSpan(diasPlano, 0, 0, 0);
                    ValorPorDia = 18m;
                    taxa = 0.40m;

                    DiferencaEntreDias(diasEfetivos, diasPlano, taxa);

                    break;
            }
        }

        private void DiferencaEntreDias(int diasEfetivos, int diasPlano, decimal taxa)
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

        private decimal EfetivosMenorQuePlano(int diasEfetivos, int diasPlano, decimal taxa)
        {
            var diasNaoEfetivos = diasPlano - diasEfetivos;

            var valorEfetivos = diasEfetivos * ValorPorDia;
            Multa = (diasNaoEfetivos * ValorPorDia) * taxa;

            return valorEfetivos + Multa;
        }

        private decimal EfetivosMaiorQuePlano(int diasEfetivos, int diasPlano)
        {
            var diasAdicionais = diasEfetivos - diasPlano;

            var valorEfetivos = diasPlano * ValorPorDia;
            Multa = diasAdicionais * 50m;

            return valorEfetivos + Multa;
        }

        private decimal EfetivosIgualAoPlano(int diasPlano)
        {
            return diasPlano * ValorPorDia;
        }
    }
}
