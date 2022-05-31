namespace DigitalWareBackEnd.Models.Dto
{
    public class ResponseDto
    {
        public bool Ok { get; set; } = true;
        public object Result { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
