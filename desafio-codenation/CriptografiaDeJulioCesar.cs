namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CriptografiaDeJulioCesar
    {
        [JsonProperty("numero_casas")]
        public long NumeroCasas { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("cifrado")]
        public string Cifrado { get; set; }

        [JsonProperty("decifrado")]
        public string Decifrado { get; set; }

        [JsonProperty("resumo_criptografico")]
        public string ResumoCriptografico { get; set; }
    }
}
