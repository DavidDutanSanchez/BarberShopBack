namespace barbershop.model
{
    public class QueryParams
    {
        public string? search { get; set; }
        public int page { get; set; } = 1;
        private int _pageSize = 20;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > 500) ? 500: value;
            }
        }

        public bool isOrderByDescending { get; set; } = true;
        public string? orderBy { get; set; }
        public string? fechaInicio { get; set; }
        public string? fechaFin { get; set; }

    }
}
