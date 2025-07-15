namespace agroWebSitreAPI.Application.ViewModel
{
    public class AnalysisViewModelPut
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }

        public string pH { get; set; }
        public string MO { get; set; }
        public string CO { get; set; }
        public string P { get; set; }
        public string K { get; set; }
        public string Ca { get; set; }
        public string Mg { get; set; }
        public string S { get; set; }
        public string B { get; set; }
        public string Zn { get; set; }
        public string Cu { get; set; }
        public string Mn { get; set; }
        public string Fe { get; set; }
        public string Al { get; set; }
        public string CTC { get; set; }
        public string V_ { get; set; } // "V%" convertido para nome válido
        public string H_Al { get; set; } // "H+Al" convertido para nome válido
    }
}
