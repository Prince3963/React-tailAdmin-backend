using MyDummyAPI.DTOs;
using MyDummyAPI.Models;

namespace MyDummyAPI.Services.Interfaces
{
    public interface IPartnerServices
    {
        Task<List<PartnerDTO>> getAllPartner();
        Task<PartnerDTO> addPartner(PartnerDTO partnerDTO);
    }
}
