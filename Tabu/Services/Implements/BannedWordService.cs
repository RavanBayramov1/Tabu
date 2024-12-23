using AutoMapper;
using Tabu.DAL;
using Tabu.DTOs.BannedWords;
using Tabu.Exceptions.BannedWord;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements;

//public class BannedWordService(TabuDbContext _context , IMapper _mapper) : IBannedWordService
//{
//    public Task UpdateAsync(int id, BannedWordUpdateDto dto)
//    {
//        var data = _context.BannedWords.Any(x => x.Id == id);
//        if (data == null) throw new BannedWordNotFoundException();


//    }
//}
