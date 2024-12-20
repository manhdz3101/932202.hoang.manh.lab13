using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Result
    {
        [Required(ErrorMessage = "Ответ не указан")]
        public int Answer { get; set; } = -1;
        public int RightAnswersCount { get; set; } = 0;
        public int AnswersCount { get; set; } = 0;
        public List<string> ListResult { get; set; } = new List<string>();
        
    }
}
