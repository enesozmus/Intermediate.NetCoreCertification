using AutoMapper;
using Intermediate.Application.Features.ApartmentsOperations;
using Intermediate.Application.Features.ApartmentTypesOperations;
using Intermediate.Application.Features.AuthenticationOperations;
using Intermediate.Application.Features.BillsOperations;
using Intermediate.Application.Features.BlocksOperations;
using Intermediate.Application.Features.MessagesOperations;
using Intermediate.Application.Features.ProfilesOperations;
using Intermediate.Application.Features.ResidentsOperations;
using Intermediate.Domain.Entities;

namespace Intermediate.Application.Mappings;

public class MappingProfile : Profile
{
     public MappingProfile()
     {
          #region Admin

          CreateMap<AppUser, CreateResidentCommandRequest>().ReverseMap();
          CreateMap<AppUser, UpdateResidentCommandRequest>().ReverseMap();
          CreateMap<AppUser, GetResidentsQueryResponse>();
          CreateMap<AppUser, GetResidentNamesQueryResponse>();
          CreateMap<AppUser, GetResidentDetailQueryResponse>();

          #endregion,

          #region Auth

          CreateMap<AppUser, LoginCommandResponse>().ReverseMap();
          CreateMap<AppUser, GetUserQueryResponse>().ReverseMap();
          //.ForMember(d => d.Image, o => o.MapFrom(s => s.AppUserPhotos.FirstOrDefault(x => x.IsMain).Url));

          #endregion

          #region Profiles

          CreateMap<Bill, GetUserBillsQueryResponse>();
          CreateMap<Apartment, GetUserApartmentsQueryResponse>()
               .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Block.BlockName))
                .ForMember(dest => dest.ApartmentType, opt => opt.MapFrom(src => src.ApartmentType.Type));

          #endregion

          #region Messages

          CreateMap<Message, GetSentMessagesQueryResponse>();
          CreateMap<Message, GetMessageDetailQueryResponse>();
          CreateMap<Message, GetIncomingMessagesQueryResponse>();
          CreateMap<SendMessageCommandRequest, Message>();
          CreateMap<UpdateMessageCommandRequest, Message>();

          #endregion

          #region Blocks

          CreateMap<Block, GetBlocksQueryResponse>();
          CreateMap<CreateBlockCommandRequest, Block>();
          CreateMap<UpdateBlockCommandRequest, Block>();

          #endregion

          #region ApartmentTypes

          CreateMap<ApartmentType, GetApartmentTypesQueryResponse>();
          CreateMap<CreateApartmentTypeCommandRequest, ApartmentType>();
          CreateMap<UpdateApartmentTypeCommandRequest, ApartmentType>();

          #endregion

          #region Apartment

          CreateMap<Apartment, GetApartmentsQueryResponse>()
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser.FirstName + " " + src.AppUser.LastName))
                .ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Block.BlockName))
                .ForMember(dest => dest.ApartmentType, opt => opt.MapFrom(src => src.ApartmentType.Type));


          CreateMap<CreateApartmentCommandRequest, Apartment>();
          CreateMap<UpdateApartmentCommandRequest, Apartment>();

          #endregion

          #region Bill

          CreateMap<Bill, GetBillsQueryResponse>()
               .ForMember(dest => dest.Payer, opt => opt.MapFrom(src => src.AppUser.FirstName + " " + src.AppUser.LastName));


          CreateMap<CreateBillCommandRequest, Bill>();
          CreateMap<UpdateBillCommandRequest, Bill>();

          #endregion
     }
}
