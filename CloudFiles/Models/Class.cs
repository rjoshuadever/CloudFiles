namespace CloudFiles.Models
{
    public class ConversionResult
    {
        public ConversionResult(bool IsConverstionSucceeded, Object Result) { }

        public bool IsConversionSucceeded { get; set; }
        public Object Result { get; set; }
    }
}
