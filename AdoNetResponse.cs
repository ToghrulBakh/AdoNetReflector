namespace AdoNetReflector
{
    public abstract class AdoNetResponse
    {
        public string Message { get; set; } = "Succes";
        public int? ReturnValueSql { get; set; }
    }
}
