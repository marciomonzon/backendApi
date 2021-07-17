using System.Collections.Generic;

namespace Api.Models.DTO
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> Errors { get; set; }
    }
}
