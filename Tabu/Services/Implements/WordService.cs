using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Reflection.Emit;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Enums;
using Tabu.Exceptions.Language;
using Tabu.Exceptions.Word;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements;

public class WordService(TabuDbContext _context, IMapper _mapper) : IWordService
{
    public async Task<IEnumerable<WordGetDto>> GetAllAsync()
    {
        var word = await _context.Words.Include(x=> x.BannedWords).ToListAsync();
        return _mapper.Map<IEnumerable<WordGetDto>>(word);
    }
    public async Task CreateAsync(WordCreateDto dto)
    {
        if (await _context.Words.AnyAsync(x => x.LanguageCode == dto.LanguageCode && x.Text == dto.Text))
            throw new WordExistException();
        if(dto.BannedWords.Count() != (int)GameLevel.Hard)
            throw new InvalidBannedWordCountException();
        Word word = new Word
        {
            LanguageCode = dto.LanguageCode,
            Text = dto.Text,
            BannedWords = dto.BannedWords.Select(x => new BannedWord
            {
                Text = x
            }).ToList()
        };
        await _context.AddAsync(word);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(int id, WordUpdateDto dto)
    {
        var data = await _getById(id);
        if (data == null) throw new LanguageNotFoundException();
        data.LanguageCode = dto.LanguagCode;
        data.Text = dto.Text;
        data.BannedWords = dto.BannedWords.Select(x => new BannedWord
        {
            Text = x
        }).ToList();
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var data = await _getById(id);
        if (data == null) throw new LanguageNotFoundException();
        _context.Words.Remove(data);
        await _context.SaveChangesAsync();
    }
    async Task<Word?> _getById(int id)
    => await _context.Words.FindAsync(id);
}
