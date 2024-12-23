namespace Tabu.DTOs.Words;

public class WordUpdateDto
{
    public string Text { get; set; }
    public string LanguagCode { get; set; }
    public IEnumerable<string> BannedWords { get; set; }
}
