using Newtonsoft.Json;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("preco")]
        public decimal Preco { get; set; }
        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public string PrecoFormatado => $"R$ {Preco}";

        public string PrecoTotalFormatado =>
            $"Valor Total: R${Preco + (TemFreioAbs ? FREIO_ABS : 0) + (TemArCondicionado ? AR_CONDICIONADO : 0) + (TemMP3Player ? MP3_PLAYER : 0)}";
    }
}