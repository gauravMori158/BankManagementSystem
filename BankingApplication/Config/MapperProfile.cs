using AutoMapper;
using BankingApplication.Models;

namespace BankingApplication.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BankTransaction, BankAccountPosting>().ReverseMap();


            //CreateMap<BankTransaction, BankAccountPosting>().ForMember(
            //    des => des.BankAccountPostingId,
            //    opt => opt.MapFrom(src => src.BankTransactionId)
            //    );
        }
    }
}
